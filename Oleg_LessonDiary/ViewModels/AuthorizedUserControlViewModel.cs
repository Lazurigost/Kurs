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

        private readonly PageService _pageService;

        public AuthorizedUserControlViewModel(PageService pageService)
        {
            _pageService = pageService;
            if (CurrentUser.userSaved != null)
            {
                Fullname = $"{CurrentUser.userSaved.UserSurname} {CurrentUser.userSaved.UserName} {CurrentUser.userSaved.UserPatronymics}";
            }
        }
        [RelayCommand]
        private void LogOut()
        {
            CurrentUser.userSaved = null;
            _pageService.ChangePage(new SignInPage());
        }
    }
}
