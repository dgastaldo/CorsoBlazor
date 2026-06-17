using SmartHub.Models;
using SmartHub.UI;
using System.Net.Http.Json;

namespace SmartHub.Client.Services
{
    public class ClientDeviceService : IDeviceService
    {
        private readonly HttpClient httpClient;

        public ClientDeviceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<IoTDevice>> GetAllDevicesAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("devices");
            response.EnsureSuccessStatusCode();
            List<IoTDevice>? devices = await response.Content.ReadFromJsonAsync<List<IoTDevice>>();
            return devices ?? new List<IoTDevice>();
        }

        public async Task ToggleActivationAsync(IoTDevice device)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync("devices/toggleActivation", device);
            response.EnsureSuccessStatusCode();
        }

    }

}
