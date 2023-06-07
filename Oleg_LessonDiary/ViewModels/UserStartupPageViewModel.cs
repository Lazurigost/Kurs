using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class UserStartupPageViewModel : ObservableObject
    {
        private readonly PageService _pageService;
        private readonly JournalService _journalService;

        [ObservableProperty]
        public List<Journal> userLessons = new();
        [ObservableProperty]
        private Journal selectedPlan;

        public UserStartupPageViewModel(PageService pageService,JournalService journalService)
        {
            _pageService = pageService;
            _journalService = journalService;

            UpdateLists();
        }
        public async void UpdateLists()
        {
            UserLessons = await _journalService.GetAllJournalsAsync();
        }
        [RelayCommand]
        private void EditLesson()
        {
            if (SelectedPlan != null)
            {
                Global.journal = SelectedPlan;
                _pageService.ChangePage(new UserChangeLesson());
            }
        }
    }
}
