namespace Oleg_LessonDiary.Services
{
    public class GuitarService
    {
        private readonly OdinsonlearnContext _context;

        public GuitarService(OdinsonlearnContext context)
        {
            _context = context;
        }
        public async Task<List<GuitarType>> GetGuitarTypesAsync()
        {
            List<GuitarType> types = await _context.GuitarTypes.ToListAsync();
            return types;
        }
    }
}
