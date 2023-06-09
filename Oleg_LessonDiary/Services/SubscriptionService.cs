using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class SubscriptionService
    {
        private readonly NewlearnContext _context;

        public SubscriptionService(NewlearnContext context)
        {
            _context = context;
        }
        public async void Subscribe(int chosen)
        {
            int subNumber = _context.Userssubscriptions.Max(s => s.IdUserssubsription) + 1;

            List<Userssubscription> userssubscriptions = await _context.Userssubscriptions.ToListAsync();
            Userssubscription newSub = new Userssubscription
            {
                IdUserssubsription = subNumber,
                UserssubscriptionIdPlan = chosen,
                UserssubsriptionDate = DateTime.Now,
                UserssubsriptionIdUsers = Global.user.IdUsers,
                UserssubsriptionStatus = 0
            };
            await _context.Userssubscriptions.AddAsync(newSub);
            await _context.SaveChangesAsync();
        }
    }
}
