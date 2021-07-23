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
    public class CityService : ICityService
    {
        private readonly IRepository<City> cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task AddCity(City city)
        {
            await cityRepository.AddAsync(city);
        }

        public async Task DeleteCity(int id)
        {
            await cityRepository.RemoveAsync(id);
        }

        public async Task EditCity(City city)
        {
            await cityRepository.Update(city);
        }

        public async Task<City> GetById(int id)
        {
            return await cityRepository.FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetCities(int pageNumber = 1, int itemCount = 10)
        {
            var cityIncludes = new List<Expression<Func<City, object>>>
            {
                y => y.Country
            };
            var citySpec = new Specification<City>(x => true, cityIncludes);
            return await cityRepository.GetAsync(citySpec, pageNumber, itemCount);
        }
    }
}
