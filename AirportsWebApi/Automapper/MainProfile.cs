using Airport.Domain.Core.Entities;
using AirportsWebApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportsWebApi.Automapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<City, CityVM>().ForMember(x => x.CountryName, (options) => options.MapFrom(x => x.Country.Name)).ReverseMap();
            CreateMap<Airports, AirportVM>().ForMember(x => x.City, (options) => options.MapFrom(x => x.City.Name)).ReverseMap();
            CreateMap<Flights, FlightVM>()
                .ForMember(x => x.StartAirport, (options) => options.MapFrom(x => x.StartAirport.Name))
                .ForMember(x => x.EndAirport, (options) => options.MapFrom(x => x.EndAirport.Name))
                .ForMember(x => x.StartTime, (options) => options.MapFrom(x => x.StartTime.ToUniversalTime().ToString()))
                .ReverseMap();
        }
    }
}
