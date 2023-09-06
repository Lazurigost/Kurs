using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Oleg_LessonDiary.Models;
using iText.Bouncycastleconnector;

namespace Oleg_LessonDiary.Services
{
    public class DocumentService
    {
        private readonly NewlearnContext _tradeContext;
        private readonly LearnplanService _learnplanService;

        public DocumentService(NewlearnContext tradeContext, LearnplanService learnplanService)
        {
            _tradeContext = tradeContext;

            _learnplanService = learnplanService;
        }
        //Функция создания и записи документа
        public async void CreateDocument(User order, string path)
        {
            ObservableCollection<Lplan> learnplanList = new();
            if (Global.user != null)
            {
                learnplanList = await _learnplanService.GetAllSubs(Global.user);
            }
            else
            {
                //KursList = await _kursService.GetMyPlansAsync(Global.teacher);
            }

            PdfWriter writer = new($"{path}//Подписки от {DateOnly.FromDateTime(DateTime.Now).ToString("D")}.pdf");
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            PdfFont font = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\Arial.ttf", PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_NOT_EMBEDDED);

            var content = new Paragraph($"ООО Одинсон-лёрн")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFont(font)
                .SetFontSize(16);

            document.Add(content);

            content = new Paragraph($"Ученик - {order.UsersName + " " + order.UsersSurname}")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFont(font)
                .SetFontSize(14);

            document.Add(content);

            content = new Paragraph($"Текущие подписки")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFont(font)
                .SetFontSize(14)
                .SetBold();

            document.Add(content);

            Table table = new(4);
            table.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM);
            table.SetFont(font);
            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);

            table.AddCell("Название");
            table.AddCell("Преподаватель");
            table.AddCell("Продолжительность");
            table.AddCell("Дата начала");

            foreach (var product in learnplanList)
            {
                table.AddCell(product.LearnPlanIdKursNavigation.KursName);
                table.AddCell(product.LearnPlanIdTeacherNavigation.IdTeacherNavigation.UsersName + " " + product.LearnPlanIdTeacherNavigation.IdTeacherNavigation.UsersSurname);
                table.AddCell($"{product.LearnPlanIdKursNavigation.KursDuration.ToString() + " недель"}");
                table.AddCell(product.LearnPlanIdKursNavigation.KursStartDate.ToString());
            }

            document.Add(table);


            document.Close();
        
        }
    }
}
