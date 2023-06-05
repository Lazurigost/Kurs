using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class TeacherUserControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? teacher_fullname;

        private readonly PageService _pageService;

        public TeacherUserControlViewModel(PageService pageService)
        {
            _pageService = pageService;
            if (Global.user != null) 
            {
                Teacher_fullname = $"{Global.user.UserSurname} {Global.user.UserName} {Global.user.UserPatronymics}";
            }
        }
        private void LogOut()
        {
            Global.user = null;
            _pageService.ChangePage(new SignInPage());
        }
    }
}
