using Airport.Domain.Core.Entities;
using Airport.Infastructure.Bussines;
using AirportsWebApi.Automapper;
using AirportsWebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirportsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService flightService;
        private readonly IMapper mapper;

        public FlightsController(IFlightService flightService, IMapper mapper)
        {
            this.flightService = flightService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightVM>>> Get()
        {
            var flights = await flightService.GetFlights();
            var mapped = mapper.Map<Flights, FlightVM>(flights);
            return Ok(mapped);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightVM>> Get(int id)
        {
            Flights flight = await flightService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
           var mapped = mapper.Map<Flights, FlightVM>(flight);
            return Ok(mapped);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Flights>> Post(Flights flight)
        {
            if (flight == null)
            {
                return BadRequest();
            }

            await flightService.AddFlight(flight);
            return Ok(flight);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Flights>> Put(Flights flight)
        {
            if (flight == null)
            {
                return BadRequest();
            }
            if (await flightService.GetById(flight.Id) == null)
            {
                return NotFound();

            }

            await flightService.EditFlight(flight);
            return Ok(flight);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flights>> Delete(int id)
        {
            var flight = flightService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            await flightService.DeleteFlight(id);
            return Ok();
        }
    }
}
