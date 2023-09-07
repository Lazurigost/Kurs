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
        [ObservableProperty]
        private string planOrKurs;
        [ObservableProperty]
        private string mySubsOrKurs;
        #endregion
        public PostAuthPageViewModel(PageService pageService, LearnplanService learnplanService, SubscriptionService subscriptionService, KursService kursService)
        {
            _pageService = pageService;
            _learnplanService = learnplanService;
            _subscriptionService = subscriptionService;
            _kursService = kursService;

            if (Global.user != null)
            {
                MySubsOrKurs = "подписки";
                PlanOrKurs = "Планы";
                IsUser = true;
                Update();
            }
            else if (Global.teacher != null)
            {
                MySubsOrKurs = "планы";
                PlanOrKurs = "Курсы";
                IsTeacher = true;
                Update();
            }
            
        }
        private async void Update()
        {
            
            if(Global.user != null)
            {
                LearnplanList = await _learnplanService.GetUserPlan(Global.user);
            }
            else
            {
                KursList = await _kursService.GetAllKursesAsync();
            }
        }
        [RelayCommand]
        private void Subscribe()
        {   
            if(SelectedPlan  != null)
            {
                _subscriptionService.Subscribe(selectedPlan.IdLearnPlan);
                MessageBox.Show("Запись на курс прошла успешно!");
            }
            
            Update();
        }
        [RelayCommand]
        private void CreatePlan()
        {

        }
        [RelayCommand]
        private void Aboba()
        {
            MessageBox.Show("Aboba");
        }
        [RelayCommand]
        private void GoToMyBlank()
        {
            _pageService.ChangePage(new MyBlankPage());
        }
        [RelayCommand]
        private void GoToMyProfile()
        {
            _pageService.ChangePage(new MyProfilePage());
        }
    }
}
