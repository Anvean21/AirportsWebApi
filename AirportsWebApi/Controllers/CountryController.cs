using Airport.Domain.Core.Entities;
using Airport.Infastructure.Bussines.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        // GET: api/GetAirports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetAirports()
        {
            return Ok(await countryService.GetCountries());

        }

        // GET: api/GetAirport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetAirport(int id)
        {
            var airport = await countryService.GetById(id);

            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        // PUT: api/PutAirport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport(Country airport)
        {
            if (airport == null)
            {
                return BadRequest();
            }
            if (await countryService.GetById(airport.Id) == null)
            {
                return NotFound();

            }

            await countryService.EditCountry(airport);
            return Ok(airport);
        }

        // POST: api/PostAirports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostAirports(Country airport)
        {
            if (airport == null)
            {
                return BadRequest();
            }

            await countryService.AddCountry(airport);
            return Ok(airport);
        }

        // DELETE: api/DeleteAirports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirports(int id)
        {
            var flight = countryService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            await countryService.DeleteCountry(id);
            return Ok(flight);
        }
    }
}
