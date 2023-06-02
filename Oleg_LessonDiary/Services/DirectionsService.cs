using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Services
{
    public class DirectionsService
    {
        private readonly OdinsonlearnContext _context;

        public DirectionsService(OdinsonlearnContext context)
        {
            _context = context;
        }
        public async Task<List<Direction>> GetDirectionsAsync()
        {
            List<Direction> dirs = await _context.Directions.ToListAsync();
            return dirs;
        }
    }
}
