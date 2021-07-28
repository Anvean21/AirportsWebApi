using Airport.Domain.Core.Entities;
using Airport.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infastructure.Bussines.Interfaces
{
    public interface ICountryService
    {
        public Task AddCountry(Country country);
        public Task<PagedList<Country>> GetCountries(int pageNumber = 1, int itemCount = 10);
        public Task<Country> GetById(int id);
        public Task EditCountry(Country country);
        public Task DeleteCountry(int id);
    }
}
