using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartHub.Models
{
    public class SmartHubDbContext(DbContextOptions<SmartHubDbContext> options) : IdentityDbContext<ApplicationUser>(options)
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
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "29f231f8-ad0b-48d2-93dc-bf6cabea0ea9", ConcurrencyStamp = "2a0d4e92-fe4f-4742-8c13-1a16f790a3d0", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "51e4214b-1b89-414b-ad75-7a32767f2de9", ConcurrencyStamp = "82644469-cc16-410d-86d7-e4a366260035", Name = "User", NormalizedName = "USER" }
            );
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "60ce9648-fcf6-44b8-ac9e-8bbbc8ce711b",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "fc771f33-5eae-4ead-a1b4-9a159d9145a8",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = "ADMIN@TEST.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    Email = "admin@test.com",
                    SecurityStamp = "d3f1e5b0-4c6e-4f8a-9b2c-1e5f3d2a1b4c"
                },
                new IdentityUser
                {
                    Id = "c1f8c6bd-e55c-433b-92bf-eece36c8fa21",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "d3684c55-9109-4f5c-be31-cf6111c4aa2",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = "USER@TEST.COM",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@test.com",
                    PasswordHash = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = "f2f8d966-b6d5-476c-9e58-3a052cfc165e"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "60ce9648-fcf6-44b8-ac9e-8bbbc8ce711b",
                    RoleId = "29f231f8-ad0b-48d2-93dc-bf6cabea0ea9"
                },
                new IdentityUserRole<string>
                {
                    UserId = "c1f8c6bd-e55c-433b-92bf-eece36c8fa21",
                    RoleId = "51e4214b-1b89-414b-ad75-7a32767f2de9"
                }
            );
        }
    }
}
