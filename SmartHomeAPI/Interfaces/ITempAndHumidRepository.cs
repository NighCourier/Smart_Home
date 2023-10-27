using SmartHomeAPI.Models;

namespace SmartHomeAPI.Interfaces
{
    public interface ITempAndHumidRepository
    {
        ICollection<TempAndHumid> GetTempAndHumids();
        TempAndHumid GetTempAndHumid(int id);
        bool TempAndHumidExist(int id);
        bool PostTempAndHumid(TempAndHumid tempAndHumid);
        bool Save();

    }
}
