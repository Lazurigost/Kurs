namespace Oleg_LessonDiary.Services
{
    internal class UserService
    {
        private readonly OdinsonlearnContext _context;

        public UserService(OdinsonlearnContext context)
        {
            _context = context;
        }

        public async Task<bool> Authorization(string userLogin, string userPassword)
        {
            User user = await _context.Users.Where(user => user.UserLogin == userLogin && user.UsersPassword == userPassword).SingleOrDefaultAsync();

            if (user != null) 
            {
                CurrentUser.userSaved = new User
                {
                    IdUsers = user.IdUsers,
                    UserLogin = user.UserLogin,
                    UsersPassword = user.UsersPassword,
                    UserName = user.UserName,
                    UserSurname = user.UserSurname,
                    UserPatronymics = user.UserPatronymics,
                    UserDatebirth = user.UserDatebirth,
                    IdType = user.IdType
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
