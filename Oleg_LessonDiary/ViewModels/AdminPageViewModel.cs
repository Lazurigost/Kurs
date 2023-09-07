using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class AdminPageViewModel : ObservableObject
    {
        private readonly PageService _pageService;
        private readonly KursService _kursService;

        [ObservableProperty]
        private List<Kur> kursList;
        [ObservableProperty]
        private Kur selectedKurs;

        public AdminPageViewModel(PageService pageService, KursService kursService) 
        {
            _pageService = pageService;
            _kursService = kursService;

            Update();
        }
        public async void Update()
        {
            KursList = await _kursService.GetAllKursesAsync();
        }
        //[RelayCommand]
        //private async void DeletePlan()
        //{
        //    await 
        //}
        [RelayCommand]
        private void AddKurs()
        {
            _pageService.ChangePage(new AddKursPage());
        }
        [RelayCommand]
        private void ChangeKurs()
        {
            if (SelectedKurs != null)
            {
                Global.kurs = SelectedKurs;
                _pageService.ChangePage(new ChangeKursPage());
            }
        }
        [RelayCommand]
        private void DeleteKurs()
        {
            if (SelectedKurs != null)
            {
                _kursService.DeleteKurs(SelectedKurs);
                MessageBox.Show("Удаление прошло успешно!");
                _pageService.ChangePage(new AdminPage());
            }
        }
    }
}
