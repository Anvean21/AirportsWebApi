using Airport.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Infastructure.Bussines
{
    public interface IFlightService
    {
        public Task AddFlight(Flights flight);
        public Task<IEnumerable<Flights>> GetFlights(int pageNumber = 1, int itemCount = 10);
        public Task<Flights> GetById(int id);
        public Task EditFlight(Flights flight);
        public Task DeleteFlight(int id);
    }
}
