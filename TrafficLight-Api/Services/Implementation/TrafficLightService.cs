using System;
using System.Threading;
using System.Timers;

using TrafficLight_Api.Models;
using TrafficLight_Api.Services.Abstractions;

namespace TrafficLight_Api.Services.Implementation
{
    public class TrafficLightService: ITrafficLightService
    {
        private ITimerEvent _timerEvent;
        public TrafficLightService(ITimerEvent timerEvent)
        {
            _timerEvent = timerEvent;
        }

        public async Task ChangeTimespans(List<TimespanDto> timespanDto)
        {
            var greenTimespan = timespanDto.FirstOrDefault(x => x.CurrentState == CurrentState.Green);
            var yellowTimespan = timespanDto.FirstOrDefault(x => x.CurrentState == CurrentState.Yellow);
            var redTimespan = timespanDto.FirstOrDefault(x => x.CurrentState == CurrentState.Red);
            if (greenTimespan != null)
            {
                ApplicationState.TrafficLight.GreenState.MinTimespan = TimeSpan.FromSeconds(greenTimespan.Min).TotalMilliseconds;
                ApplicationState.TrafficLight.GreenState.MaxTimespan = TimeSpan.FromSeconds(greenTimespan.Max).TotalMilliseconds;
            }
            if (yellowTimespan != null)
            {
                ApplicationState.TrafficLight.YellowState.MinTimespan = TimeSpan.FromSeconds(yellowTimespan.Min).TotalMilliseconds;
                ApplicationState.TrafficLight.YellowState.MaxTimespan = TimeSpan.FromSeconds(yellowTimespan.Max).TotalMilliseconds;
            }
            if (redTimespan != null)
            {
                ApplicationState.TrafficLight.RedState.MinTimespan = TimeSpan.FromSeconds(redTimespan.Min).TotalMilliseconds;
                ApplicationState.TrafficLight.RedState.MaxTimespan = TimeSpan.FromSeconds(redTimespan.Max).TotalMilliseconds;
            }

        }

        public async Task InvokePedestrianGreen()
        {

            if (ApplicationState.TrafficLight.CurrentState.Contains(CurrentState.Green))
            {
                var datetimeNow = DateTime.Now;
                var timeLeft = ApplicationState.TimeToTriger - datetimeNow;
                var timeStarted = ApplicationState.TimeToTriger.AddMilliseconds(-ApplicationState.TrafficLight.GreenState.MaxTimespan);
                var timePassed = datetimeNow - timeStarted;
                var millisecondsLeft = timeLeft.TotalMilliseconds;
                var millisecondsPassed = timePassed.TotalMilliseconds;
                System.Diagnostics.Debug.WriteLine(millisecondsLeft);
           
                if (millisecondsLeft > TimeSpan.FromSeconds(ApplicationState.PedestrianWaiting).TotalMilliseconds && millisecondsPassed > ApplicationState.TrafficLight.GreenState.MinTimespan)
                {
                    ApplicationState.Timer.Stop();
                    _timerEvent.SetTimer(TimeSpan.FromSeconds(ApplicationState.PedestrianWaiting).TotalMilliseconds);
                }
            }
        }
       
    }
}
