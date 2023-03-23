using System.Xml;

namespace TrafficLight_Api.Models
{
    public class TrafficLight
    {
        public RedState RedState { get; set; }
        public YellowState YellowState { get; set; }
        public GreenState GreenState { get; set; }
        public List<CurrentState> CurrentState { get; set; }
    }
}
