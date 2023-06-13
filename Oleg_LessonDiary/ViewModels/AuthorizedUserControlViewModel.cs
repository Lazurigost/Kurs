namespace Oleg_LessonDiary.ViewModels
{
    public partial class AuthorizedUserControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? fullname;
        [ObservableProperty]
        private string? authRole;

        private readonly PageService _pageService;

        public AuthorizedUserControlViewModel(PageService pageService)
        {
            _pageService = pageService;
            if (Global.user != null)
            {
                Fullname = $"{Global.user.UsersSurname} {Global.user.UsersName} {Global.user.UsersPatronymics}";
                AuthRole = Global.user.UsersRoleNavigation.RoleName;
            }
            else if (Global.teacher != null)
            {
                Fullname = $"{Global.teacher.IdTeacherNavigation.UsersSurname} {Global.teacher.IdTeacherNavigation.UsersName} {Global.teacher.IdTeacherNavigation.UsersPatronymics}";
                AuthRole = Global.teacher.IdTeacherNavigation.UsersRoleNavigation.RoleName;
            }
        }
        [RelayCommand]
        private void LogOut()
        {
            Global.user = null;
            Global.teacher = null;
            _pageService.ChangePage(new SignInPage());
        }
    }
}
