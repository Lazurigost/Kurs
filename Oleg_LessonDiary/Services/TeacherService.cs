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

        //public async Task<bool> Authorization(string teacherLogin, string teacherPassword)
        //{
        //    Teacher teacher = await _context.Teachers.Where(teacher => teacher.TeacherLogin == teacherLogin && teacher.TeacherPassword == teacherPassword).SingleOrDefaultAsync();

        //    if (teacher != null) 
        //    {
        //        CurrentTeacher.CurTeacher = new Teacher
        //        {
        //            IdTeacher = teacher.IdTeacher,
        //            TeacherLogin = teacher.TeacherLogin,
        //            TeacherPassword = teacher.TeacherPassword,
        //            TeacherName = teacher.TeacherName,
        //            TeacherSurname = teacher.TeacherSurname,
                    
        //        }
        //    }
        //}
    }
}
