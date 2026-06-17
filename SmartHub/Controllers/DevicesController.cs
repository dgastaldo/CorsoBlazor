using Microsoft.AspNetCore.Mvc;
using SmartHub.Models;
using SmartHub.UI;

namespace SmartHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet()]
        public async Task<IEnumerable<IoTDevice>> GetDevices()
        {
            return await _deviceService.GetAllDevicesAsync();
        }

        [HttpPut("toggleActivation")]
        public async Task<IActionResult> ToggleActivation([FromBody] IoTDevice device)
        {
            await _deviceService.ToggleActivationAsync(device);
            return Ok();
        }
    }
}
