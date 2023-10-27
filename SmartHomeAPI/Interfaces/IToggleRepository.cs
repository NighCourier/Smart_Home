using SmartHomeAPI.Models;

namespace SmartHomeAPI.Interfaces
{
    public interface IToggleRepository
    {
        bool PostToggle(Toggle toggle);
        Toggle GetToggle();
        bool Save();
    }
}
