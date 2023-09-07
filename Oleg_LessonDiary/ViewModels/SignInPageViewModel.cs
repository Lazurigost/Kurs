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
        [ObservableProperty]
        private List<Teacher> teacherList = new();
        #endregion

        public SignInPageViewModel(UserService userService, PageService pageService, TeacherService teacherService)
        {
            _userService = userService;
            _pageService = pageService;
            _teacherService = teacherService;
        }
        #region Комманды
        
        [RelayCommand]
        private async void SignIn()
        {
            await Task.Run(async () =>
            {
                if (await _userService.Authorization(userLogin, usersPassword))
                {
                    if (Global.userAdm == null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _pageService.ChangePage(new PostAuthPage());
                        });
                    }
                    else
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _pageService.ChangePage(new AdminPage());
                        });
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте данные и повторите попытку.");
                }
            });
        }
        [RelayCommand]
        private void GoToSignUp() => _pageService.ChangePage(new SignUpPage());
        #endregion
    }
}
