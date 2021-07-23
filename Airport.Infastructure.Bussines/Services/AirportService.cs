using Airport.Domain.Core.Entities;
using Airport.Domain.Core.Intefaces;
using Airport.Domain.Core.Specification;
using Airport.Infastructure.Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infastructure.Bussines.Services
{
    public class AirportService : IAirportService
    {
        private readonly IRepository<Airports> airportsRepository;

        public AirportService(IRepository<Airports> airportsRepository)
        {
            this.airportsRepository = airportsRepository;
        }

        public async Task AddAirport(Airports airport)
        {
            await airportsRepository.AddAsync(airport);
        }

        public async Task DeleteAirport(int id)
        {
            await airportsRepository.RemoveAsync(id);
        }

        public async Task EditAirport(Airports airport)
        {
            await airportsRepository.Update(airport);
        }

        public async Task<IEnumerable<Airports>> GetAirports(int pageNumber = 1, int itemCount = 10)
        {
            var airportIncludes = new List<Expression<Func<Airports, object>>>
            {
                y => y.City.Country
            };
            var airportSpec = new Specification<Airports>(x => true, airportIncludes);
            return await airportsRepository.GetAsync(airportSpec, pageNumber, itemCount);
        }

        public async Task<Airports> GetById(int id)
        {
            return await airportsRepository.FindAsync(id);
        }
    }
}
