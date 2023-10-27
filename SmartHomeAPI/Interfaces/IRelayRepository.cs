using SmartHomeAPI.Models;
using SmartHomeAPI.Repository;

namespace SmartHomeAPI.Interfaces
{
    public interface IRelayRepository
    {
        ICollection<Relay> GetRelays();
        Relay GetRelay(int id);
        bool RelayExist(int id);
        bool PostRelay(Relay relay);
        bool Save();
    }
}
