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
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        // GET: api/Airports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAirports()
        {
            return Ok(await cityService.GetCities());

        }

        // GET: api/Airport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetAirport(int id)
        {
            var airport = await cityService.GetById(id);

            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        // PUT: api/Airport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport(City airport)
        {
            if (airport == null)
            {
                return BadRequest();
            }
            if (await cityService.GetById(airport.Id) == null)
            {
                return NotFound();

            }

            await cityService.EditCity(airport);
            return Ok(airport);
        }

        // POST: api/Airport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostAirports(City airport)
        {
            if (airport == null)
            {
                return BadRequest();
            }

            await cityService.AddCity(airport);
            return Ok(airport);
        }

        // DELETE: api/Airport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirports(int id)
        {
            var flight = cityService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            await cityService.DeleteCity(id);
            return Ok(flight);
        }
    }
}
