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

            Bruh();
        }
        #region Комманды
        private async void Bruh()
        {
            TeacherList = await _teacherService.GetAllTeachersAsync();
        }
        [RelayCommand]
        private async void SignIn()
        {
            await Task.Run(async () =>
            {
                if (await _userService.Authorization(userLogin, usersPassword))
                {
                    MessageBox.Show("Pobeda");
                    //await Application.Current.Dispatcher.InvokeAsync(async () => _pageService.ChangePage(new UserStartupPage()));
                    if (Global.teacher != null)
                    {
                        MessageBox.Show(TeacherList[0].IdTeacher1.UsersPatronymics);
                    }
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
