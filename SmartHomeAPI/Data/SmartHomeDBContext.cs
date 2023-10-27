using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Models;

namespace SmartHomeAPI.Data
{
    public class SmartHomeDBContext : DbContext
    {
        public SmartHomeDBContext(DbContextOptions options):base(options) { }

        public DbSet<TempAndHumid> TempAndHumids { get; set; }
        public DbSet<Relay> Relays { get; set; }
        public DbSet<Toggle> Toggles { get; set; }
    } 
}
