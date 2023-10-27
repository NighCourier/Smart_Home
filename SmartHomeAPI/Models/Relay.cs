using System.ComponentModel.DataAnnotations;

namespace SmartHomeAPI.Models
{
    public class Relay
    {
        public int id { get; set; }
        [Required]
        public string relayStatus1 { get; set; }
        [Required]
        public string relayStatus2 { get; set; }
        [Required]
        public string relayStatus3 { get; set; }
    }
}
