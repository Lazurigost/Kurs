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
                Global.user = new User
                {
                    IdUsers = user.IdUsers,
                    UsersLogin = user.UsersLogin,
                    UsersPassword = user.UsersPassword,
                    UsersName = user.UsersName,
                    UsersSurname = user.UsersSurname,
                    UsersPatronymics = user.UsersPatronymics,
                    UsersDatebirth = user.UsersDatebirth,
                    UsersRole = user.UsersRole
                };

                return true;
            }
            return false;
        }
        public async void SignUp(User user)
        {
            User userdb = user;
            userdb.IdUsers = _context.Users.Max(u => u.IdUsers) + 1;
            
            await _context.Users.AddAsync(userdb);
            await _context.SaveChangesAsync();
        }
    }
}
