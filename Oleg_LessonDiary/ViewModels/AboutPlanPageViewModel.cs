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
        private List<User> subbedList;

        public AboutPlanPageViewModel(PageService pageService, LearnplanService learnplanService)
        {
            _pageService = pageService;
            _learnplanService = learnplanService;

            Update();
        }
        private async void Update()
        {

            if (Global.lplan != null)
            {
                SubbedList = await _learnplanService.GetSubbedUsersAsync(Global.lplan.IdLearnPlan);

                Name = Global.lplan.LearnPlanIdKursNavigation.KursName;
                KursDuration = Global.lplan.LearnPlanIdKursNavigation.KursDuration.ToString();
                StartDate = Global.lplan.LearnPlanIdKursNavigation.KursStartDate.ToString();
                Restriction = SubbedList.Count().ToString();
                EndRestriction = Global.lplan.LearnPlanRestriction.ToString();
            }
        }
    }
}
