namespace Oleg_LessonDiary.ViewModels
{
    partial class SignUpPageViewModel : ObservableValidator
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;
        private readonly GuitarService _guitarService;
        private readonly QualificationService _qualificationService;

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
        private int user_role;
        [ObservableProperty]
        private bool isTeacher;
        [ObservableProperty]
        private DateTime max_date;
        [ObservableProperty]
        private List<Qualification> qualificationsList;
        [ObservableProperty]
        private int? qualIndex;
        #endregion

        public SignUpPageViewModel(UserService userService, PageService pageService, GuitarService guitarService, QualificationService qualificationService)
        {
            _userService = userService;
            _pageService = pageService;
            _guitarService = guitarService;
            _qualificationService = qualificationService;

            UpdateAll();
            
        }

        private async void UpdateAll()
        {
            QualificationsList = await _qualificationService.GetQualificationsAsync();
            Max_date = DateTime.Now.AddYears(-16);
            User_datebirth = Max_date;
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
            if (IsTeacher)
            {
                User_role = 1;
            }
            else
            {
                User_role = 2;
            }
            if (HasErrors == false)
            {
                if (IsTeacher)
                {
                    _userService.SignUp(new User
                    {
                        UsersLogin = User_login,
                        UsersPassword = User_password,
                        UsersName = User_name,
                        UsersSurname = User_surname,
                        UsersDatebirth = DateOnly.FromDateTime(User_datebirth),
                        UsersRole = User_role
                    }, QualIndex + 1);
                }
                else
                {
                    _userService.SignUp(new User
                    {
                        UsersLogin = User_login,
                        UsersPassword = User_password,
                        UsersName = User_name,
                        UsersSurname = User_surname,
                        UsersDatebirth = DateOnly.FromDateTime(User_datebirth),
                        UsersRole = User_role
                    }, null);
                }
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
