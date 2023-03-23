using Microsoft.AspNetCore.Mvc;

using System.Timers;

using TrafficLight_Api.Models;
using TrafficLight_Api.Services.Abstractions;

namespace TrafficLight_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficLightController : ControllerBase
    {
        private ITrafficLightService _service;
        public TrafficLightController(ITrafficLightService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> ChangeTimespans([FromBody] List<TimespanDto> timespanDto, CancellationToken token)
        {
            await _service.ChangeTimespans(timespanDto);
            return Ok();
        }
        [HttpPost("Invoke")]
        public async Task<IActionResult> InvokePedestrianGreen(CancellationToken token)
        {
            await _service.InvokePedestrianGreen();
            return Ok();
        }
    }
}