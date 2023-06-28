﻿using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class MyBlankPageViewModel: ObservableObject
    {
        #region Сервисы
        private readonly PageService _pageService;
        private readonly KursService _kursService;
        private readonly LearnplanService _learnplanService;
        private readonly SubscriptionService _subscriptionService;
        #endregion
        #region Свойства
        [ObservableProperty]
        private string mySubsOrKurs;
        [ObservableProperty]
        private string planOrKurs;
        [ObservableProperty]
        private bool isUser;
        [ObservableProperty]
        private bool isTeacher;
        [ObservableProperty]
        private ObservableCollection<Lplan> kursList;
        [ObservableProperty]
        private ObservableCollection<Lplan> learnplanList;
        [ObservableProperty]
        private Lplan selectedTeachPlan;
        [ObservableProperty]
        private Lplan selectedUserPlan;
        #endregion
        public MyBlankPageViewModel(PageService pageService, KursService kursService, LearnplanService learnplanService, SubscriptionService subscriptionService) 
        {
            _pageService = pageService;
            _learnplanService = learnplanService;
            _kursService = kursService;
            _subscriptionService = subscriptionService;

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
            if (Global.user != null)
            {
                LearnplanList = await _learnplanService.GetAllSubs(Global.user);
            }
            else
            {
                KursList = await _kursService.GetMyPlansAsync(Global.teacher);
            }
        }
        [RelayCommand]
        private async void DeletePlan()
        {
            if(SelectedTeachPlan != null)
            {
                
                _learnplanService.DeletePlan(SelectedTeachPlan);
                MessageBox.Show("Курс был удалён.");
            }
            Update();
        }
        [RelayCommand]
        private void GoToPostAuth()
        {
            _pageService.ChangePage(new PostAuthPage());
        }
        [RelayCommand]
        private void GoToMyProfile()
        {
            _pageService.ChangePage(new MyProfilePage());
        }
        [RelayCommand]
        private async void UnSubscribe()
        {
            if (SelectedUserPlan != null)
            {
                _subscriptionService.Unsubscribe(selectedUserPlan.IdLearnPlan);
            }
            Update();
        }
        [RelayCommand]
        private void GoToAboutPage()
        {
            Global.lplan = SelectedTeachPlan;
            _pageService.ChangePage(new AboutPlanPage());
        }
    }
}