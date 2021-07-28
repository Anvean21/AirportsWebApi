using Airport.Domain.Core.Entities;
using Airport.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infastructure.Bussines.Interfaces
{
    public interface IAirportService
    {
        public Task AddAirport(Airports airport);
        public Task<PagedList<Airports>> GetAirports(int pageNumber = 1, int itemCount = 10);
        public Task<Airports> GetById(int id);
        public Task EditAirport(Airports airport);
        public Task DeleteAirport(int id);
    }
}
