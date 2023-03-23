using System.Timers;

namespace TrafficLight_Api.Services.Abstractions
{
    public interface ITimerEvent
    {
        public void SetTimer(double time);
        public void OnEventExecution(object? sender, ElapsedEventArgs eventArgs);
    }
}
