using TrafficLight_Api.Models;

namespace TrafficLight_Api.Services
{
    public static class ApplicationState
    {
        public static TrafficLight TrafficLight = new()
        {
            RedState = new RedState
            {
                MinTimespan = TimeSpan.FromSeconds(120).TotalMilliseconds,
                MaxTimespan = TimeSpan.FromSeconds(120).TotalMilliseconds,
            },
            YellowState = new YellowState
            {
                MinTimespan = TimeSpan.FromSeconds(5).TotalMilliseconds,
                MaxTimespan = TimeSpan.FromSeconds(5).TotalMilliseconds,
            },
            GreenState = new GreenState
            {
                MinTimespan = TimeSpan.FromSeconds(120).TotalMilliseconds,
                MaxTimespan = TimeSpan.FromSeconds(360).TotalMilliseconds,
            },
            CurrentState = new List<CurrentState> 
            {
                CurrentState.Red
            },
        };
        public static DateTime TimeToTriger { get; set; }
        public static System.Timers.Timer Timer { get; set; }
        public static double PedestrianWaiting = 30;
}
}
