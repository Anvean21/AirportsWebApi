using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airport.Domain.Core.Entities;
using Airport.Infrastructure.Data;
using Airport.Infastructure.Bussines.Interfaces;

namespace AirportsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService airportService;

        public AirportsController(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        // GET: api/Airports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airports>>> GetAirports()
        {
            return Ok(await airportService.GetAirports());

        }

        // GET: api/Airport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airports>> GetAirport(int id)
        {
            var airport = await airportService.GetById(id);

            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        // PUT: api/Airport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport( Airports airport)
        {
            if (airport == null)
            {
                return BadRequest();
            }
            if (await airportService.GetById(airport.Id) == null)
            {
                return NotFound();

            }

            await airportService.EditAirport(airport);
            return Ok(airport);
        }

        // POST: api/Airport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airports>> PostAirports(Airports airport)
        {
            if (airport == null)
            {
                return BadRequest();
            }

            await airportService.AddAirport(airport);
            return Ok(airport);
        }

        // DELETE: api/Airport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirports(int id)
        {
            var flight = airportService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            await airportService.DeleteAirport(id);
            return Ok(flight);
        }

        //private bool AirportsExists(int id)
        //{
        //    return _context.Airports.Any(e => e.Id == id);
        //}
    }
}
