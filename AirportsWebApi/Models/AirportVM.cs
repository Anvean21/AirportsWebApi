using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportsWebApi.Models
{
    public class AirportVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
