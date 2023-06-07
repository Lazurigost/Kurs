namespace Oleg_LessonDiary.ViewModels
{
    partial class SignUpPageViewModel : ObservableValidator
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;
        private readonly TeacherService _teacherService;
        private readonly DirectionsService _directionsService;
        private readonly GuitarService _guitarService;

        #region User свойства
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
        private string user_role;
        #endregion

        public SignUpPageViewModel(UserService userService, PageService pageService, GuitarService guitarService)
        {
            _userService = userService;
            _pageService = pageService;
            _guitarService = guitarService;

            UpdateAll();
        }

        private async void UpdateAll()
        {
            User_datebirth = DateTime.Now;
        }

        [RelayCommand]
        private void UserSignUp()
        {
            #region Валидации
            ValidateProperty(User_login, nameof(User_login));
            ValidateProperty(User_password, nameof(User_password));
            ValidateProperty(User_surname, nameof(User_surname));
            ValidateProperty(User_name, nameof(User_name));
            ValidateProperty(User_patronymics, nameof(User_patronymics));
            ValidateProperty(User_datebirth, nameof(User_datebirth));
            #endregion

            if (HasErrors == false)
            {
                _userService.SignUp(new User
                {
                    UsersLogin = User_login,
                    UsersPassword = User_password,
                    UsersName = User_name,
                    UsersSurname = User_surname,
                    UsersDatebirth = DateOnly.FromDateTime(User_datebirth),
                    UsersRole = User_role
                });
                _pageService.ChangePage(new SignInPage());
            }
        }
        [RelayCommand]
        private void GoToSignIn()
        {
            _pageService.ChangePage(new SignInPage());
        }
    }
}
