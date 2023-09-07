using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class ChangeKursPageViewModel : ObservableValidator
    {
        private readonly PageService _pageService;
        private readonly KursService _kursService;
        private readonly GuitarService _guitarService;

        [ObservableProperty]
        private List<Guitar> guitarList = new();
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string name;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private Guitar selectedGuitar;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private int? duration;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private DateTime startDate;
        [ObservableProperty]
        private DateTime today;
        [ObservableProperty]
        private int selectedId;

        public ChangeKursPageViewModel(PageService pageService, KursService kursService, GuitarService guitarService) 
        {
            _pageService = pageService;
            _kursService = kursService;
            _guitarService = guitarService;
            if (Global.kurs != null)
            {
                Update();
            }
        }
        private async void Update()
        {
            Name = Global.kurs.KursName;
            SelectedId = Global.kurs.KursIdGuitar;
            Duration = Global.kurs.KursDuration;
            StartDate = Global.kurs.KursStartDate;
            Today = DateTime.Now;
            GuitarList = await _guitarService.GetGuitarTypesAsync();
        }
        [RelayCommand]
        private void ConfirmChange()
        {
            ValidateAllProperties();

            _kursService.ChangeKurs(new Kur
            {
                IdKurs = Global.kurs.IdKurs,
                KursName = Name,
                KursIdGuitar = SelectedGuitar.IdGuitar,
                KursDuration = Duration,
                KursStartDate = StartDate
            });
            MessageBox.Show("Изменение прошло успешно!");

            _pageService.ChangePage(new AdminPage());
        }
        [RelayCommand]
        private void GoBack()
        {
            _pageService.ChangePage(new AdminPage());
        }
    }
}
