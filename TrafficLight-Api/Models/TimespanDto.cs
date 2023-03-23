using System.ComponentModel.DataAnnotations;

namespace TrafficLight_Api.Models
{
    public class TimespanDto
    {
        [Range(0.01, Double.MaxValue,
             ErrorMessage = "Timespan must be grater than zero")]
        public double Min { get; set; }
        [Range(0.01, Double.MaxValue,
            ErrorMessage = "Timespan must be grater than zero")]
        public double Max { get; set; }
        public CurrentState CurrentState { get; set; }
    }
}
