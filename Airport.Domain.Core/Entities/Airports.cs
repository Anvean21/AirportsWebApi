using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Domain.Core.Entities
{
    public class Airports : BaseEntity
    {
        public string Name { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
