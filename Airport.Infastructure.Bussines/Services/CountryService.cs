using Airport.Domain.Core.Entities;
using Airport.Domain.Core.Intefaces;
using Airport.Domain.Core.Models;
using Airport.Domain.Core.Specification;
using Airport.Infastructure.Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infastructure.Bussines.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task AddCountry(Country country)
        {
            await countryRepository.AddAsync(country);
        }

        public async Task DeleteCountry(int id)
        {
            await countryRepository.RemoveAsync(id);
        }

        public async Task EditCountry(Country country)
        {
            await countryRepository.Update(country);
        }

        public async Task<Country> GetById(int id)
        {
            return await countryRepository.FindAsync(id);
        }

        public async Task<PagedList<Country>> GetCountries(int pageNumber = 1, int itemCount = 10)
        {
            var countrySpec = new Specification<Country>(x => true);
            return await countryRepository.GetAsync(countrySpec, pageNumber, itemCount, 1, "Id");
        }
    }
}
