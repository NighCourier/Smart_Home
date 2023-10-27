using SmartHomeAPI.Data;
using SmartHomeAPI.Interfaces;
using SmartHomeAPI.Models;

namespace SmartHomeAPI.Repository
{
    public class RelayRepository : IRelayRepository
    {
        private readonly SmartHomeDBContext _context;
        public RelayRepository(SmartHomeDBContext context)
        {
            _context = context;
        }

        public Relay GetRelay(int id)
        {
            return _context.Relays.Where(r => r.id == id).FirstOrDefault();
        }

        public ICollection<Relay> GetRelays()
        {
            return _context.Relays.OrderBy(r => r.id).ToList();
        }

        public bool PostRelay(Relay relay)
        {
            _context.Add(relay);
            return Save();
        }

        public bool RelayExist(int id)
        {
            return _context.Relays.Any(r => r.id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
