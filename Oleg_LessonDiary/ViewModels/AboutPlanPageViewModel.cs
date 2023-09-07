using Oleg_LessonDiary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class AboutPlanPageViewModel:ObservableObject
    {
        private readonly PageService _pageService;
        private readonly LearnplanService _learnplanService;
        private readonly SaveFileDialogService _saveFileDialogService;
        private readonly DocumentService _documentService;

        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string kursDuration;
        [ObservableProperty]
        private string startDate;
        [ObservableProperty]
        private string restriction;
        [ObservableProperty]
        private string endRestriction;
        [ObservableProperty]
        private string guitarName;
        [ObservableProperty]
        private List<User> subbedList;

        public AboutPlanPageViewModel(PageService pageService, LearnplanService learnplanService, SaveFileDialogService saveFileDialogService, DocumentService documentService)
        {
            _pageService = pageService;
            _learnplanService = learnplanService;
            _saveFileDialogService = saveFileDialogService;
            _documentService = documentService;

            Update();
        }
        private async void Update()
        {

            if (Global.lplan != null)
            {
                SubbedList = await _learnplanService.GetSubbedUsersAsync(Global.lplan.IdLearnPlan);

                Name = Global.lplan.LearnPlanIdKursNavigation.KursName;
                GuitarName = Global.lplan.LearnPlanIdKursNavigation.KursIdGuitarNavigation.GuitarName;
                KursDuration = Global.lplan.LearnPlanIdKursNavigation.KursDuration.ToString();
                StartDate = Global.lplan.LearnPlanIdKursNavigation.KursStartDate.ToString();
                Restriction = SubbedList.Count().ToString();
                EndRestriction = Global.lplan.LearnPlanRestriction.ToString();
            }
        }
        [RelayCommand]
        private void GoBack()
        {
            _pageService.ChangePage(new PostAuthPage());
        }
        [RelayCommand]
        private void PrintTeacher()
        {
            string selectedFolder = "";
            selectedFolder = _saveFileDialogService.PDFSaveFileDialog();
            if (selectedFolder != "no folder")
            {
                _documentService.CreaterLplanDocument(Global.lplan, selectedFolder);
            }
        }
    }
}
