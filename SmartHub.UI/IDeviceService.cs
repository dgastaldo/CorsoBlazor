using SmartHub.Models;

namespace SmartHub.UI
{
    public interface IDeviceService
    {
        Task<List<IoTDevice>> GetAllDevicesAsync();
        Task ToggleActivationAsync(IoTDevice device);
    }
}
