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

        public SignInPageViewModel(UserService userService, PageService pageService)
        {
            _userService = userService;
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
        private void GoToSignUp() => _pageService.ChangePage(new SignUpPage());
        #endregion
    }
}
