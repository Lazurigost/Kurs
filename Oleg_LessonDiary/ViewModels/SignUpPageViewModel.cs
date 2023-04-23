using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Oleg_LessonDiary.ViewModels
{
    partial class SignUpPageViewModel : ObservableObject
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;

        #region Свойства
        [ObservableProperty]
        private string userLogin;
        [ObservableProperty]
        private string? usersPassword;
        #endregion

        public SignUpPageViewModel(UserService userService, PageService pageService)
        {
            _userService = userService;
            _pageService = pageService;
        }

        [RelayCommand]
        private async void SignUp()
        {
            await Task.Run(async () =>
            {
                if (await _userService.Authorization(userLogin, usersPassword) == true)
                {
                    MessageBox.Show("Победа");
                }
                else
                {
                    MessageBox.Show("Поражение");
                }
            });
        }
    }
}
