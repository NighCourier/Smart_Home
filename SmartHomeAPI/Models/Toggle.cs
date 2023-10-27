using System.ComponentModel.DataAnnotations;

namespace SmartHomeAPI.Models
{
    public class Toggle
    {
        public int id { get; set; }
        [Required]
        public bool isEnabled { get; set; }
    }
}
