using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Oleg_LessonDiary.Infrastructure;

namespace Oleg_LessonDiary.ViewModels
{
    partial class SignInPageViewModel : ObservableObject
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;

        #region Свойства
        [ObservableProperty]
        private string userLogin;
        [ObservableProperty]
        private string? usersPassword;
        #endregion

        public SignInPageViewModel(UserService userService, PageService pageService)
        {
            _userService = userService;
            _pageService = pageService;
        }

        [RelayCommand]
        private async void SignIn()
        {
            await Task.Run(async () =>
            {
                if (await _userService.Authorization(userLogin, usersPassword) == true)
                {
                    MessageBox.Show($"{CurrentUser.userSaved.UserLogin}, {CurrentUser.userSaved.UserName}");
                }
                else
                {
                    MessageBox.Show("Поражение");
                }
            });
        }
        [RelayCommand]
        private void GoToSignUp() => _pageService.ChangePage(new SignUpPage());
        
    }
}
