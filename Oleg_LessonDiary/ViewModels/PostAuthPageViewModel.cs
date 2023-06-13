using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly SubscriptionService _subscriptionService;
        private readonly KursService _kursService;
        #region Свойства
        [ObservableProperty]
        private bool isUser = false;
        [ObservableProperty]
        private bool isTeacher = false;
        [ObservableProperty]
        private ObservableCollection<Lplan> learnplanList;
        [ObservableProperty]
        private Lplan selectedPlan;
        [ObservableProperty]
        private List<Kur> kursList;
        [ObservableProperty]
        private Kur selectedKurs;
        #endregion
        public PostAuthPageViewModel(PageService pageService, LearnplanService learnplanService, SubscriptionService subscriptionService, KursService kursService)
        {
            _pageService = pageService;
            _learnplanService = learnplanService;
            _subscriptionService = subscriptionService;
            _kursService = kursService;

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
            KursList = await _kursService.GetAllKursesAsync();
            LearnplanList = await _learnplanService.GetAllPlansAsync();
        }
        [RelayCommand]
        private void Subscribe()
        {
            _subscriptionService.Subscribe(selectedPlan.IdLearnPlan);
            Update();
        }
        [RelayCommand]
        private void CreatePlan()
        {

        }
    }
}
