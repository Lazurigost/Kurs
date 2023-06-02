namespace Oleg_LessonDiary.ViewModels
{
    partial class SignUpPageViewModel : ObservableValidator
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;
        private readonly TeacherService _teacherService;

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
        [Required(ErrorMessage = "Заполните поле")]
        private int user_guitar;
        #endregion

        #region Teacher свойства
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string teacher_login;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string teacher_password;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string teacher_surname;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string teacher_name;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string teacher_patronymics;
        [ObservableProperty]
        private bool teacher_qual_check;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private int teacher_direction;
        #endregion

        public SignUpPageViewModel(UserService userService, PageService pageService, TeacherService teacherService)
        {
            _userService = userService;
            _pageService = pageService;
            _teacherService = teacherService;

            User_datebirth = DateTime.Now;
            
        }
        [RelayCommand]
        private void UserSignUp()
        {
            ValidateProperty(User_name);

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
        [RelayCommand]
        private void TeacherSignUp()
        {
            
        }
    }
}
