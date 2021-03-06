using Airport.Domain.Core.Entities;
using Airport.Domain.Core.Intefaces;
using Airport.Domain.Core.Models;
using Airport.Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Airport.Infastructure.Bussines
{
    public class FlightService : IFlightService
    {
        private readonly IRepository<Flights> fligthRepository;

        public FlightService(IRepository<Flights> fligthRepository)
        {
            this.fligthRepository = fligthRepository;
        }

        public async Task AddFlight(Flights flight)
        {
            await fligthRepository.AddAsync(flight);
        }

        public async Task DeleteFlight(int id)
        {
            await fligthRepository.RemoveAsync(id);
        }

        public async Task EditFlight(Flights flight)
        {
            await fligthRepository.Update(flight);
        }

        public async Task<Flights> GetById(int id)
        {
            var flightIncludes = new List<Expression<Func<Flights, object>>>
            {
                y => y.StartAirport.City.Country,
                y => y.EndAirport.City.Country,
            };

            var flightSpec = new Specification<Flights>(x => x.Id == id, flightIncludes);

            return await fligthRepository.FindAsync(flightSpec);
        }

        public async Task<PagedList<Flights>> GetFlights(int pageNumber, int itemCount, int sorting,string property, string seacrhData)
        {
            var flightIncludes = new List<Expression<Func<Flights, object>>>
            {
                y => y.StartAirport.City.Country,
                y => y.EndAirport.City.Country,
            };

            var flightSpec = new Specification<Flights>(x => true, flightIncludes);

            if (!string.IsNullOrWhiteSpace(seacrhData))
            {
                 flightSpec = new Specification<Flights>(x => x.StartAirport.Name.ToLower().Contains(seacrhData.ToLower()), flightIncludes);
            }
            
            return await fligthRepository.GetAsync(flightSpec, pageNumber, itemCount, sorting, property);
        }
    }
}
