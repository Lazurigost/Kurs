using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class EditProfilePageViewModel : ObservableValidator
    {
        private readonly QualificationService _qualificationService;
        private readonly PageService _pageService;
        private readonly UserService _userService;

        [ObservableProperty]
        [Required(ErrorMessage = "Заполните поле")]
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

        public EditProfilePageViewModel(QualificationService qualificationService, UserService userService, PageService pageService) 
        {
            _pageService = pageService;
            _qualificationService = qualificationService;
            _userService = userService;

            if (Global.teacher != null)
            {
                IsTeacher = true;
            }
            else
            {
                IsTeacher = false;
                if(Global.user  != null)
                {
                    user_login = Global.user.UsersLogin;
                    user_password = Global.user.UsersPassword;
                    user_surname = Global.user.UsersSurname;
                    user_name = Global.user.UsersName;
                    user_patronymics = Global.user.UsersPatronymics;
                    user_datebirth = Global.user.UsersDatebirth.ToDateTime(TimeOnly.Parse("10:00 PM"));
                }
                
            }

            UpdateAll();
        }

        private async void UpdateAll()
        {
            QualificationsList = await _qualificationService.GetQualificationsAsync();
            Max_date = DateTime.Now.AddYears(-16);
            User_datebirth = Max_date;
        }
        [RelayCommand]
        private async void UserChange()
        {
            if(Global.user != null)
            {
                
                User user = new User
                {
                    IdUsers = Global.user.IdUsers,
                    UsersLogin = User_login,
                    UsersPassword = User_password,
                    UsersSurname = User_surname,
                    UsersName = User_name,
                    UsersPatronymics = User_patronymics,
                    UsersDatebirth = DateOnly.FromDateTime(User_datebirth),
                    UsersRole = 2
                };
                _userService.ChangeUser(user, null);
                await Task.Delay(1000);
                _pageService.ChangePage(new MyProfilePage());
            }
            
            
        }
    }
}
