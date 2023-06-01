using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm.Native;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Oleg_LessonDiary.ViewModels
{
    partial class SignUpPageViewModel : ObservableValidator
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;

        #region Свойства
        [ObservableProperty]
        [Required(ErrorMessage ="Заполните поле")]
        private string user_login;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string user_password;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string user_surname;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string user_name;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string user_patronymics;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private DateTime user_datebirth;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private int user_guitar;
        #endregion

        public SignUpPageViewModel(UserService userService, PageService pageService)
        {
            _userService = userService;
            _pageService = pageService;

            User_datebirth = DateTime.Now;
        }
        [RelayCommand]
        private void SignUp()
        {
            ValidateAllProperties();

            if (HasErrors == false)
            {
                _userService.SignUp(new User
                {
                    UserLogin = User_login,
                    UsersPassword = User_password,
                    UserName = User_name,
                    UserSurname = User_surname,
                    UserDatebirth = DateOnly.FromDateTime(User_datebirth),
                    IdType = User_guitar
                });
                _pageService.ChangePage(new SignInPage());
            }
        }
    }
}
