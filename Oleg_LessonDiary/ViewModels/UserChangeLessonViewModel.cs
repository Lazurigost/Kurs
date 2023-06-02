using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class UserChangeLessonViewModel : ObservableValidator
    {
        private readonly PageService _pageService;
        private readonly JournalService _journalService;

        public UserChangeLessonViewModel(PageService pageService, JournalService journalService)
        {
            _pageService = pageService;
            _journalService = journalService;
        }
    }
}
