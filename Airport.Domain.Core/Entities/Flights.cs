using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Domain.Core.Entities
{
    public class Flights : BaseEntity
    {
        public string Duration { get; set; }
        public DateTime StartTime { get; set; }
        public Airports StartAirport { get; set; }
        public Airports EndAirport { get; set; }
    }
}
