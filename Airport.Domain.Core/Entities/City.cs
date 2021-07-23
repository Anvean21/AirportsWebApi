using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Domain.Core.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
