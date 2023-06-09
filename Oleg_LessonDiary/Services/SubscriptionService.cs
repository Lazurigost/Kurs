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
    }
}
