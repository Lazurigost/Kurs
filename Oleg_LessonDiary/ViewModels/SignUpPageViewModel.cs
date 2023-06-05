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
        [Required(ErrorMessage = "Заполните поле")]
        private int user_guitar;
        [ObservableProperty]
        private List<GuitarType> guitarList = new();
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
        [Required(ErrorMessage = "Заполните поле")]
        private int teacher_qual_check;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private int teacher_direction;
        [ObservableProperty]
        private List<Direction> directionsList = new();
        #endregion

        public SignUpPageViewModel(UserService userService, PageService pageService, TeacherService teacherService, DirectionsService directionsService, GuitarService guitarService)
        {
            _userService = userService;
            _pageService = pageService;
            _teacherService = teacherService;
            _directionsService = directionsService;
            _guitarService = guitarService;

            UpdateAll();
        }

        private async void UpdateAll()
        {
            User_datebirth = DateTime.Now;
            DirectionsList = await _directionsService.GetDirectionsAsync();
            GuitarList = await _guitarService.GetGuitarTypesAsync();
            Teacher_direction = -1;
            User_guitar = -1;
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
            ValidateProperty(User_guitar, nameof(User_guitar));
            #endregion

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
        private void CheckQual(string parameter)
        {
            if (parameter == "1")
            {
                Teacher_qual_check = 1;
            }
            else if (parameter == "2") 
            {
                Teacher_qual_check = 2;
            }
            else
            {
                Teacher_qual_check = 3;
            }
        }
        [RelayCommand]
        private void TeacherSignUp()
        {
            #region Валидации
            ValidateProperty(Teacher_login, nameof(Teacher_login));
            ValidateProperty(Teacher_password, nameof(Teacher_password));
            ValidateProperty(Teacher_surname, nameof(Teacher_surname));
            ValidateProperty(Teacher_name, nameof(Teacher_name));
            ValidateProperty(Teacher_patronymics, nameof(Teacher_patronymics));
            ValidateProperty(Teacher_qual_check, nameof(Teacher_qual_check));
            ValidateProperty(Teacher_direction, nameof(Teacher_direction));
            #endregion
            if (Teacher_qual_check != 0 && Teacher_direction != -1)
            if (HasErrors == false)
            {

                _teacherService.SignUp(new Teacher
                {
                    TrLogin = Teacher_login,
                    TrPassword = Teacher_password,
                    TrName = Teacher_name,
                    TrSurname = Teacher_surname,
                    TrPatronymics = Teacher_patronymics,
                    TrDegree = Teacher_qual_check,
                    TrDirection = Teacher_direction + 1
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
