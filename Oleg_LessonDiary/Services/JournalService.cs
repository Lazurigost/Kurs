using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class JournalService
    {
        private readonly OdinsonlearnContext _context;

        public JournalService(OdinsonlearnContext context)
        {
            _context = context;
        }

        public async Task<List<Journal>> GetAllJournalsAsync()
        {
            List<Journal> allJournals = await _context.Journals.ToListAsync();
            return allJournals;
        }

        public async Task<List<Journal>> GetAllUserLessons(int userId)
        {
            List<Journal> lessons = await _context.Journals.Where(l => l.JournalUserId == userId).ToListAsync();
            return lessons;
        }

        public async void AddLesson(Journal lesson)
        {
            await _context.Journals.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
