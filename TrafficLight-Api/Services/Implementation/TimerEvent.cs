using System.Timers;

using TrafficLight_Api.Models;
using TrafficLight_Api.Services.Abstractions;

namespace TrafficLight_Api.Services
{
    public class TimerEvent: ITimerEvent
    {
        public void SetTimer(double time)
        {
            ApplicationState.Timer = new System.Timers.Timer();
            ApplicationState.Timer.Elapsed += OnEventExecution;
            ApplicationState.Timer.Interval = time; 
            System.Diagnostics.Debug.WriteLine(ApplicationState.TrafficLight.CurrentState.Last());
            ApplicationState.Timer.AutoReset = false;
            ApplicationState.Timer.Start();
          
        }
        public void OnEventExecution(Object? sender, ElapsedEventArgs eventArgs)
        {
            ApplicationState.Timer.Stop();
            System.Diagnostics.Debug.WriteLine(eventArgs.SignalTime);
            if (ApplicationState.TrafficLight.CurrentState.Count == 1 && ApplicationState.TrafficLight.CurrentState.Contains(CurrentState.Yellow))
            {
                ApplicationState.TrafficLight.CurrentState.Clear();
                ApplicationState.TrafficLight.CurrentState.Add(CurrentState.Red);
                ApplicationState.TimeToTriger = eventArgs.SignalTime.AddMilliseconds(ApplicationState.TrafficLight.RedState.MaxTimespan);
                SetTimer(ApplicationState.TrafficLight.RedState.MaxTimespan);
            }
            else if (ApplicationState.TrafficLight.CurrentState.Count == 2)
            {
                ApplicationState.TrafficLight.CurrentState.Clear();
                ApplicationState.TrafficLight.CurrentState.Add(CurrentState.Green);
                ApplicationState.TimeToTriger = eventArgs.SignalTime.AddMilliseconds(ApplicationState.TrafficLight.GreenState.MaxTimespan);
                SetTimer(ApplicationState.TrafficLight.GreenState.MaxTimespan);
            }
            else if (ApplicationState.TrafficLight.CurrentState.Count == 1 && ApplicationState.TrafficLight.CurrentState.Contains(CurrentState.Red))
            {
                ApplicationState.TrafficLight.CurrentState.Add(CurrentState.Yellow);
                ApplicationState.TimeToTriger = eventArgs.SignalTime.AddMilliseconds(ApplicationState.TrafficLight.YellowState.MaxTimespan);
                SetTimer(ApplicationState.TrafficLight.YellowState.MaxTimespan);
            }
            else if (ApplicationState.TrafficLight.CurrentState.Count == 1 && ApplicationState.TrafficLight.CurrentState.Contains(CurrentState.Green))
            {
                ApplicationState.TrafficLight.CurrentState.Clear();
                ApplicationState.TrafficLight.CurrentState.Add(CurrentState.Yellow);
                ApplicationState.TimeToTriger = eventArgs.SignalTime.AddMilliseconds(ApplicationState.TrafficLight.YellowState.MaxTimespan);
                SetTimer(ApplicationState.TrafficLight.YellowState.MaxTimespan);
            }

        }

    }
}
