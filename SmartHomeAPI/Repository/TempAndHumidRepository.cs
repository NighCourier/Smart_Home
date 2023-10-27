using SmartHomeAPI.Data;
using SmartHomeAPI.Interfaces;
using SmartHomeAPI.Models;

namespace SmartHomeAPI.Repository
{
    public class TempAndHumidRepository : ITempAndHumidRepository
    {
        private readonly SmartHomeDBContext _context;
        public TempAndHumidRepository(SmartHomeDBContext context)
        {
            _context = context;
        }

        public TempAndHumid GetTempAndHumid(int id)
        {
            return _context.TempAndHumids.Where(t => t.id == id).FirstOrDefault();
        }

        public ICollection<TempAndHumid> GetTempAndHumids()
        {
            return _context.TempAndHumids.OrderBy(t => t.id).ToList();
        }

        public bool PostTempAndHumid(TempAndHumid tempAndHumid)
        {
            _context.Add(tempAndHumid);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TempAndHumidExist(int id)
        {
            return _context.TempAndHumids.Any(t => t.id == id);
        }
    }
}
