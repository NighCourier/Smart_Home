using SmartHomeAPI.Data;
using SmartHomeAPI.Interfaces;
using SmartHomeAPI.Models;

namespace SmartHomeAPI.Repository
{
    public class ToggleRepository : IToggleRepository
    {
        
        private readonly SmartHomeDBContext _context;
        public ToggleRepository(SmartHomeDBContext context)
        {
            _context = context;
        }

        public Toggle GetToggle()
        {
            Toggle toggle = new Toggle();
            if(_context.Toggles.Count() == 0)
            {
                toggle.id = 0;
                toggle.isEnabled = false;
                _context.Add(toggle);
                Save();
            }
            return _context.Toggles.OrderBy(t => t.id).Last();
        }

        public bool PostToggle(Toggle toggle)
        {
            _context.Add(toggle);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
