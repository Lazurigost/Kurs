using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    
    public class QualificationService
    {
        private readonly NewlearnContext _context;

        public QualificationService( NewlearnContext context)
        {
            _context = context;
        }
        public async Task<List<Qualification>> GetQualificationsAsync()
        {
            return await _context.Qualifications.ToListAsync();
        }
    }
}
