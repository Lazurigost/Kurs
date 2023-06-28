using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class AddKursPageViewModel : ObservableValidator
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
        private int duration;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private DateTime startDate;
        [ObservableProperty]
        private DateTime today;
        public AddKursPageViewModel(PageService pageService, KursService kursService, GuitarService guitarService) 
        {
            _pageService = pageService;
            _kursService = kursService;
            _guitarService = guitarService;

            Update();
        }
        private async void Update()
        {
            StartDate = DateTime.Now;
            Today = DateTime.Now;
            GuitarList = await _guitarService.GetGuitarTypesAsync();
        }
        [RelayCommand]
        private void GoBack()
        {
            _pageService.ChangePage(new PostAuthPage());
        }
        [RelayCommand]
        private void ConfirmAdd()
        {
            ValidateAllProperties();

            _kursService.AddNewKurs(new Kur
            {
                KursName = Name,
                KursIdGuitar = SelectedGuitar.IdGuitar,
                KursDuration = Duration,
                KursStartDate = StartDate
            });
            MessageBox.Show("Добавление прошло успешно!");
        }
    }
}
