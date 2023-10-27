using System.ComponentModel.DataAnnotations;

namespace SmartHomeAPI.Models
{
    public class TempAndHumid
    {
        public int id { get; set; }
        [Required]
        public float tempValue { get; set; }
        [Required]
        public float humidValue { get; set; }
    }
}
