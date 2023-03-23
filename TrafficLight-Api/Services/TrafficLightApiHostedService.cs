using TrafficLight_Api.Services.Abstractions;

namespace TrafficLight_Api.Services
{
    public class TrafficLightApiHostedService : IHostedService
    {
        private ITimerEvent _timerEvent;
        public TrafficLightApiHostedService(ITimerEvent timerEvent)
        {
            _timerEvent = timerEvent;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _timerEvent.SetTimer(ApplicationState.TrafficLight.RedState.MaxTimespan);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            //Cleanup logic here
        }
    }
}