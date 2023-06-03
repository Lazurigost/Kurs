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
            if (CurrentUser.userSaved != null) 
            {
                Teacher_fullname = $"{CurrentUser.userSaved.UserSurname} {CurrentUser.userSaved.UserName} {CurrentUser.userSaved.UserPatronymics}";
            }
        }\\
        private void LogOut()
        {
            CurrentUser.userSaved = null;
            _pageService.ChangePage(new SignInPage());
        }
    }
}
