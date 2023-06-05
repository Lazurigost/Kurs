namespace Oleg_LessonDiary.ViewModels
{
    partial class SignInPageViewModel : ObservableValidator
    {
        #region Сервисы
        private readonly UserService _userService;
        private readonly PageService _pageService;
        private readonly TeacherService _teacherService;
        #endregion
        #region Свойства
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string userLogin;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string? usersPassword;
        #endregion
        #region Teacher свойства
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string teacherLogin;
        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
        private string? teacherPassword;
        #endregion

        public SignInPageViewModel(UserService userService, PageService pageService, TeacherService teacherService)
        {
            _userService = userService;
            _teacherService = teacherService;
            _pageService = pageService;
        }
        #region Комманды
        [RelayCommand]
        private async void SignIn()
        {
            await Task.Run(async () =>
            {
                if (await _userService.Authorization(userLogin, usersPassword))
                {
                    await Application.Current.Dispatcher.InvokeAsync(async () => _pageService.ChangePage(new UserStartupPage()));
                }
                else
                {
                    MessageBox.Show("Поражение");
                }
            });
        }
        [RelayCommand]
        private async void TeacherSignIn()
        {
            await Task.Run(async () =>
            {
                if (await _teacherService.Authorization(TeacherLogin, TeacherPassword))
                {
                    MessageBox.Show("Ura pobeda");
                }
                else
                {
                    MessageBox.Show("Porazhenie");
                }
            });
        }
        [RelayCommand]
        private void GoToSignUp() => _pageService.ChangePage(new SignUpPage());
        #endregion
    }
}
