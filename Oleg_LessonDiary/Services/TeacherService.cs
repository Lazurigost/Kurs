using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class TeacherService
    {
        private readonly OdinsonlearnContext _context;

        public TeacherService(OdinsonlearnContext context)
        {
            _context = context;
        }

        public async Task<bool> Authorization(string teacherLogin, string teacherPassword)
        {
            Teacher teacher = await _context.Teachers.Where(teacher => teacher.TrLogin == teacherLogin && teacher.TrPassword == teacherPassword).SingleOrDefaultAsync();

            if (teacher != null)
            {
                CurrentTeacher.CurTeacher = new Teacher
                {
                    IdTeacher = teacher.IdTeacher,
                    TrLogin = teacher.TrLogin,
                    TrPassword = teacher.TrPassword,
                    TrName = teacher.TrName,
                    TrSurname = teacher.TrSurname,
                    TrPatronymics = teacher.TrPatronymics,
                    TrDegree = teacher.TrDegree,
                    TrDirection = teacher.TrDirection
                };

                return true;
            }
            return false;
        }
        public async void SignUp(Teacher teacher)
        {
            Teacher teacherDb = teacher;
            teacherDb.IdTeacher = _context.Teachers.Max(t => t.IdTeacher) + 1;

            await _context.Teachers.AddAsync(teacherDb);
            await _context.SaveChangesAsync();
        }
    }
}
