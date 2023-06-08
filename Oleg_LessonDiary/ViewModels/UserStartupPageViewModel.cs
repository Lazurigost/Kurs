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

        public UserStartupPageViewModel(PageService pageService)
        {
            _pageService = pageService;

            UpdateLists();
        }
        public async void UpdateLists()
        {
        }
        [RelayCommand]
        private void EditLesson()
        {
        }
    }
}
