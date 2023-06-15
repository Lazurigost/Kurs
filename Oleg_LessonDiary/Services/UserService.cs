namespace Oleg_LessonDiary.Services
{
    internal class UserService
    {
        private readonly NewlearnContext _context;

        public UserService(NewlearnContext context)
        {
            _context = context;
        }

        public async Task<bool> Authorization(string userLogin, string userPassword)
        {
            User user = await _context.Users.Where(user => user.UsersLogin == userLogin && user.UsersPassword == userPassword).SingleOrDefaultAsync();

            if (user != null) 
            {
                if (user.UsersRole == 2)
                {
                    Global.user = new User
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
                        
                    };
                    foreach()
                }
                else if (user.UsersRole == 1)
                {
                    Global.teacher = user.Teacher;
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
    }
}
