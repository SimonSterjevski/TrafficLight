using AutoFixture;
using Moq;

using NUnit.Framework.Constraints;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrafficLight_Api.Services;
using TrafficLight_Api.Services.Abstractions;
using TrafficLight_Api.Services.Implementation;

namespace UnitTests
{
    public class Helpers
    {
        public ITrafficLightService TrafficLightService { get; set; }
        public Mock<ITimerEvent> TimerEventMock { get; set; }

        public readonly Fixture fixture = new Fixture();
        public CancellationToken CancellationToken { get; set; }

        public Helpers()
        {
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            TimerEventMock = new Mock<ITimerEvent>();
            TrafficLightService = new TrafficLightService(TimerEventMock.Object);

            CancellationToken = new CancellationToken();
        }
    }
}
