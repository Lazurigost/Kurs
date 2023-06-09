using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class PostAuthPageViewModel : ObservableObject
    {
        private readonly PageService _pageService;
        private readonly LearnplanService _learnplanService;
        #region Свойства
        [ObservableProperty]
        private bool isUser = false;
        [ObservableProperty]
        private bool isTeacher = false;
        [ObservableProperty]
        private List<Lplan> learnplanList;
        [ObservableProperty]
        private Lplan selectedPlan;
        #endregion
        public PostAuthPageViewModel(PageService pageService, LearnplanService learnplanService) 
        {
            _pageService = pageService;
            _learnplanService = learnplanService;

            if (Global.user != null)
            {
                IsUser = true;
                Update();
            }
            else if (Global.teacher != null)
            {
                IsTeacher = true;
            }
            
        }
        private async void Update()
        {
            LearnplanList = await _learnplanService.GetAllPlansAsync();
        }
        [RelayCommand]
        private void Subscribe()
        {
            MessageBox.Show("Aboba");
        }
    }
}
