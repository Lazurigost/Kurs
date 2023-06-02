namespace Oleg_LessonDiary.ViewModels
{
    partial class SignInPageViewModel : ObservableValidator
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;

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

        [RelayCommand]
        private async void SignIn()
        {
            await Task.Run(async () =>
            {
                if (await _userService.Authorization(userLogin, usersPassword) == true)
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
    }
}
