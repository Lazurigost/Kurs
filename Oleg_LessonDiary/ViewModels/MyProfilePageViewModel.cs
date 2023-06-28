using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class MyProfilePageViewModel : ObservableObject
    {
        private readonly PageService _pageService;

        [ObservableProperty]
        public string login;
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string surname;
        [ObservableProperty]
        public string patronymics;
        [ObservableProperty]
        public DateOnly bdate;
        [ObservableProperty]
        private string mySubsOrKurs;
        [ObservableProperty]
        private string planOrKurs;

        public MyProfilePageViewModel(PageService pageService) 
        {
            _pageService = pageService;

            if (Global.user != null)
            {
                Login = Global.user.UsersLogin;
                Name = Global.user.UsersName;
                Surname = Global.user.UsersSurname;
                Patronymics = Global.user.UsersPatronymics;
                Bdate = Global.user.UsersDatebirth;
                MySubsOrKurs = "подписки";
                PlanOrKurs = "Планы";
            }
        }
        [RelayCommand]
        private void GoToEditProfile()
        {
            _pageService.ChangePage(new EditProfilePage());
        }
        [RelayCommand]
        private void GoToPostAuth()
        {
            _pageService.ChangePage(new PostAuthPage());
        }
        [RelayCommand]
        private void GoToMyBlank()
        {
            _pageService.ChangePage(new MyBlankPage());
        }
    }
}
