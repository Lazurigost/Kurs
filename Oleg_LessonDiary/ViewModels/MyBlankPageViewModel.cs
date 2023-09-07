using Oleg_LessonDiary.Models;
using Oleg_LessonDiary.Services;
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
        private readonly DocumentService _documentService;
        private readonly SaveFileDialogService saveFileDialogService_;
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
        public MyBlankPageViewModel(PageService pageService, KursService kursService, LearnplanService learnplanService,
            SubscriptionService subscriptionService, DocumentService documentService, SaveFileDialogService saveFileDialogService)
        {
            _pageService = pageService;
            _learnplanService = learnplanService;
            _kursService = kursService;
            _subscriptionService = subscriptionService;
            _documentService = documentService;
            saveFileDialogService_ = saveFileDialogService;

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
                _subscriptionService.Unsubscribe(SelectedUserPlan.IdLearnPlan);

                MessageBox.Show($"Вы отписались от курса {SelectedUserPlan.LearnPlanIdKursNavigation.KursName}");
            }
            Update();
        }
        [RelayCommand]
        private void GoToAboutPage()
        {
            if (SelectedTeachPlan != null)
            {
                Global.lplan = SelectedTeachPlan;
                _pageService.ChangePage(new AboutPlanPage());
            }        
        }
        [RelayCommand]
        private void Print()
        {
            string selectedFolder = "";
            selectedFolder = saveFileDialogService_.PDFSaveFileDialog();
            if (selectedFolder != "no folder")
            {
                _documentService.CreateDocument(Global.user, selectedFolder);
            }
        }
    }
}
