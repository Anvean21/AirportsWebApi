using Airport.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infastructure.Bussines.Interfaces
{
    public interface ICityService
    {
        public Task AddCity(City city);
        public Task<IEnumerable<City>> GetCities(int pageNumber = 1, int itemCount = 10);
        public Task<City> GetById(int id);
        public Task EditCity(City city);
        public Task DeleteCity(int id);
    }
}
