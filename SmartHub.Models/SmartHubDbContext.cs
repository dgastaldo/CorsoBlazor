using Microsoft.EntityFrameworkCore;

namespace SmartHub.Models
{
    public class SmartHubDbContext(DbContextOptions<SmartHubDbContext> options) : DbContext(options)
    {
        public DbSet<IoTDevice> IoTDevices => Set<IoTDevice>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the IoTDevice entity
            modelBuilder.Entity<IoTDevice>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IsOn).IsRequired();
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500);
            });
            modelBuilder.Entity<IoTDevice>().HasData(
                new IoTDevice { Id = 1, Name = "Smart Light", IsOn = true, Value = 75.0, Description = "A smart light bulb." },
                new IoTDevice { Id = 2, Name = "Smart Thermostat", IsOn = false, Value = 22.5, Description = "A smart thermostat for home heating." },
                new IoTDevice { Id = 3, Name = "Smart Plug", IsOn = true, Value = 0.0, Description = "A smart plug to control appliances." }
            );
        }
    }
}
