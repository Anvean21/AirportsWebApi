using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportsWebApi.Models
{
    public class FlightVM
    {
        public int Id { get; set; }
        public string Duration { get; set; }
        public string StartTime { get; set; }
        public string StartAirport { get; set; }
        public string EndAirport { get; set; }
    }
}
