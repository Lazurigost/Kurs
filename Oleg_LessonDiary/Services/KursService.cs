using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class KursService
    {
        private readonly NewlearnContext _newlearnContext;
        public KursService(NewlearnContext newlearnContext)
        {
            _newlearnContext = newlearnContext;
        }
        public async Task<List<Kur>> GetAllKursesAsync()
        {
            return await _newlearnContext.Kurs.ToListAsync();
        }
    }
}
