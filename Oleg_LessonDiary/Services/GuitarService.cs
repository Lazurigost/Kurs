namespace Oleg_LessonDiary.Services
{
    public class GuitarService
    {
        private readonly NewlearnContext _context;

        public GuitarService(NewlearnContext context)
        {
            _context = context;
        }
        public async Task<List<Guitar>> GetGuitarTypesAsync()
        {
            List<Guitar> types = await _context.Guitars.ToListAsync();
            return types;
        }
    }
}
