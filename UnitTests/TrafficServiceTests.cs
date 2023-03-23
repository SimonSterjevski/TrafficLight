using AutoFixture;

using Moq;

using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrafficLight_Api.Models;
using TrafficLight_Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UnitTests
{
    [TestFixture]
    public class TrafficServiceTests: Helpers
    {
        [Test]
        public async Task ChangeTimespans_ShouldUpdateValues()
        {
            List<TimespanDto> timespanDtos = new List<TimespanDto>();
            TimespanDto timeSpanDto = fixture.Build<TimespanDto>()
                .With(x => x.CurrentState, CurrentState.Red)
                 .With(x => x.Min, 6)
                 .With(x => x.Max, 6)
                .Create();
            timespanDtos.Add(timeSpanDto);
            await TrafficLightService.ChangeTimespans(timespanDtos);
            Assert.AreEqual(ApplicationState.TrafficLight.RedState.MaxTimespan, TimeSpan.FromSeconds(timeSpanDto.Max).TotalMilliseconds);
        }
        [Test]
        public async Task ChangeTimespans_ShouldUpdateValuess()
        {
            List<TimespanDto> timespanDtos = new List<TimespanDto>();
            TimespanDto timeSpanDto = fixture.Build<TimespanDto>()
                .With(x => x.CurrentState, CurrentState.Red)

                .With(x => x.Max, -6)
                .Create();
            timespanDtos.Add(timeSpanDto);
            Func<Task> asyncFunction = async () => await TrafficLightService.ChangeTimespans(timespanDtos);
            Assert.AreNotEqual(ApplicationState.TrafficLight.RedState.MaxTimespan, TimeSpan.FromSeconds(timeSpanDto.Max).TotalMilliseconds);
        }
    }
}
