using Microsoft.EntityFrameworkCore;
using SmartHub.Models;
using SmartHub.UI;

namespace SmartHub.Services
{
    public class ServerDeviceService : IDeviceService
    {
        private readonly IDbContextFactory<SmartHubDbContext> _contextFactory;
        public ServerDeviceService(IDbContextFactory<SmartHubDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<IoTDevice>> GetAllDevicesAsync()
        {
            using SmartHubDbContext context = _contextFactory.CreateDbContext();
            return Task.FromResult(context.IoTDevices.ToList<IoTDevice>());
        }

        public async Task ToggleActivationAsync(IoTDevice device)
        {
            using SmartHubDbContext context = _contextFactory.CreateDbContext();
            IoTDevice? dbDevice = context.IoTDevices.FirstOrDefault(d => d.Id == device.Id);
            if (dbDevice != null)
            {
                dbDevice.IsOn = !dbDevice.IsOn;
                await context.SaveChangesAsync();
            }
        }
    }
}
