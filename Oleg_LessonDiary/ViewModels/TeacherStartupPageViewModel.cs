using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class TeacherStartupPageViewModel : ObservableObject
    {
        private readonly PageService _pageService;
        private readonly KursService _kursService;

        [ObservableProperty]
        private List<Kur> kursList = new();
        public TeacherStartupPageViewModel(PageService pageService, KursService kursService) 
        {
            _pageService = pageService;
            _kursService = kursService;
        }
        private async void UpdateAll()
        {
            KursList = await _kursService.GetAllKursesAsync();
        }
    }
}
