using System.Timers;

using TrafficLight_Api.Models;

namespace TrafficLight_Api.Services.Abstractions
{
    public interface ITrafficLightService
    {
        public Task ChangeTimespans(List<TimespanDto> timespanDto);
        public Task InvokePedestrianGreen();

    }
}
