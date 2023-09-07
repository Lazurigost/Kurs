using Oleg_LessonDiary.Models;

namespace Oleg_LessonDiary.Services
{
    public class UserService
    {
        private readonly NewlearnContext _context;

        public UserService(NewlearnContext context)
        {
            _context = context;
        }
        public async Task<List<Userssubscription>> GetAllSubsAsync(User user)
        {
            return await _context.Userssubscriptions.Where(s => s.UserssubsriptionIdUsers == user.IdUsers).ToListAsync();
        }
        public async Task<bool> Authorization(string userLogin, string userPassword)
        {
            User user = await _context.Users.Where(user => user.UsersLogin == userLogin && user.UsersPassword == userPassword).SingleOrDefaultAsync();

            if (user != null) 
            {
                if (user.UsersRole == 2)
                {
                    List<Userssubscription> subbed = await _context.Userssubscriptions.Where(s => s.UserssubsriptionIdUsers == user.IdUsers).ToListAsync();
                    Global.user = new UserModel
                    {
                        IdUsers = user.IdUsers,
                        UsersLogin = user.UsersLogin,
                        UsersPassword = user.UsersPassword,
                        UsersName = user.UsersName,
                        UsersSurname = user.UsersSurname,
                        UsersPatronymics = user.UsersPatronymics,
                        UsersDatebirth = user.UsersDatebirth,
                        UsersRole = user.UsersRole,
                        UsersRoleNavigation = user.UsersRoleNavigation,
                        SubbedList = subbed
                    };
                }
                else if (user.UsersRole == 1)
                {
                    Global.teacher = user.Teacher;
                }
                else
                {
                    Global.userAdm = user;
                }

                return true;
            }
            return false;
        }
        public async void SignUp(User user, int? qual)
        {
            User userdb = user;
            userdb.IdUsers = _context.Users.Max(u => u.IdUsers) + 1;
            _context.Users.AddAsync(userdb);
            if (qual != null)
            {
                _context.Teachers.Add(new Teacher
                {
                    IdTeacher = user.IdUsers,
                    TeacherIdQual = (int)qual
                });
            }
            
            await _context.SaveChangesAsync();
        }
        public async void ChangeUser(User user, int? qual)
        {
            User userdb = await _context.Users.Where(u => u.IdUsers == user.IdUsers).FirstOrDefaultAsync();
            if (userdb != null)
            {
                userdb.UsersLogin = user.UsersLogin;
                userdb.UsersPassword = user.UsersPassword;
                userdb.UsersSurname = user.UsersSurname;
                userdb.UsersName = user.UsersName;
                userdb.UsersPatronymics = user.UsersPatronymics;
                userdb.UsersDatebirth = user.UsersDatebirth;
                if(qual != null)
                {
                    Teacher tr = await _context.Teachers.Where(t => t.IdTeacherNavigation.IdUsers == user.IdUsers).FirstOrDefaultAsync();
                    tr.TeacherIdQual = (int)qual;
                }
                //List<Userssubscription> subbed = await _context.Userssubscriptions.Where(s => s.UserssubsriptionIdUsers == user.IdUsers).ToListAsync();
                //Global.user = new UserModel
                //{
                //    IdUsers = user.IdUsers,
                //    UsersLogin = user.UsersLogin,
                //    UsersPassword = user.UsersPassword,
                //    UsersName = user.UsersName,
                //    UsersSurname = user.UsersSurname,
                //    UsersPatronymics = user.UsersPatronymics,
                //    UsersDatebirth = user.UsersDatebirth,
                //    UsersRole = user.UsersRole,
                //    UsersRoleNavigation = user.UsersRoleNavigation,
                //    SubbedList = subbed
                //};
                
            }
            await _context.SaveChangesAsync();
            MessageBox.Show("Изменение прошло успешно");
        }
    }
}
