using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class AuthorizedUserControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? fullname;
        [ObservableProperty]
        private string? authRole;

        private readonly PageService _pageService;

        public AuthorizedUserControlViewModel(PageService pageService)
        {
            _pageService = pageService;
            if (Global.user != null)
            {
                Fullname = $"{Global.user.UsersSurname} {Global.user.UsersName} {Global.user.UsersPatronymics}";
                AuthRole = Global.user.UsersRole;
            }
        }
        [RelayCommand]
        private void LogOut()
        {
            Global.user = null;
            _pageService.ChangePage(new SignInPage());
        }
    }
}
