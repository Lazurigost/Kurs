using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class TeacherService
    {
        private readonly NewlearnContext _context;

        public TeacherService(NewlearnContext context)
        {
            _context = context;
        }
        public async Task<string> GetTeacherQual(Teacher teacher)
        {
            Qualification qual = await _context.Qualifications.Where(q => q.IdQualifications == teacher.TeacherIdQual).SingleOrDefaultAsync();
            return qual.QualificationsName;
        }
        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
    }
}
