using Microsoft.EntityFrameworkCore;
using System;
using Airport.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Infrastructure.Data
{
    public class AirportContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<Flights> Flights { get; set; }

        public AirportContext(DbContextOptions<AirportContext> options)
              : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ukraine = new Country { Id = 1, Name = "Germany" };
            var germany = new Country { Id = 2, Name = "Ukraine" };
            var china = new Country { Id = 3, Name = "China" };
            var france = new Country { Id = 4, Name = "France" };

            modelBuilder.Entity<Country>().HasData(
             new Country[]
             {
                     ukraine,germany,china,france
             });

            var kharkiv = new City { Id = 1, Name = "Kharkiv", CountryId = 1 };
            var berlin = new City { Id = 2, Name = "Berlin", CountryId = 2 };
            var pekin = new City { Id = 3, Name = "Pekin", CountryId = 3 };
            var paris = new City { Id = 4, Name = "Paris", CountryId = 4 };

            modelBuilder.Entity<City>().HasData(
             new City[]
             {
                    kharkiv,berlin,pekin,paris
             });

            var kharkiveAirport = new Airports { Id = 1, Name = "International Airport Kharkiv", CityId = 1, Latitude = 80, Longitude = 60 };
            var berlinAirport = new Airports { Id = 2, Name = "Frankfurt ", CityId = 2, Latitude = 30, Longitude = 90 };
            var chinaAirport = new Airports { Id = 3, Name = "Beijing", CityId = 3, Latitude = 12, Longitude = 65 };
            var franceAirport = new Airports { Id = 4, Name = "Charles de Gaulle", CityId = 4, Latitude = 76, Longitude = 34 };

            modelBuilder.Entity<Airports>().HasData(
            new Airports[]
            {
                    kharkiveAirport,berlinAirport,chinaAirport,franceAirport
            });

            modelBuilder.Entity<Flights>().HasData(
            new Flights[]
            {
                    new Flights { Id = 1, Duration = new TimeSpan(2, 14, 3).ToString(), StartTime =  new DateTime(2021, 9, 21, 17, 12, 00)},
                    new Flights { Id = 2, Duration = new TimeSpan(1, 34, 11).ToString(), StartTime = new DateTime(2021, 8, 3, 18, 34, 0)},
                    new Flights { Id = 3, Duration = new TimeSpan(3, 23, 25).ToString(), StartTime = new DateTime(2021, 8, 5, 19, 53, 00)},
                    new Flights { Id = 4, Duration = new TimeSpan(4, 54, 53).ToString(), StartTime = new DateTime(2021, 10, 30, 20, 43, 00)},
                    new Flights { Id = 5, Duration = new TimeSpan(2, 14, 3).ToString(), StartTime =  new DateTime(2021, 9, 21, 17, 12, 00)},
                    new Flights { Id = 6, Duration = new TimeSpan(1, 34, 11).ToString(), StartTime = new DateTime(2021, 8, 3, 18, 34, 0)},
                    new Flights { Id = 7, Duration = new TimeSpan(3, 23, 25).ToString(), StartTime = new DateTime(2021, 8, 5, 19, 53, 00)},
                    new Flights { Id = 8, Duration = new TimeSpan(4, 54, 53).ToString(), StartTime = new DateTime(2021, 10, 30, 20, 43, 00)},
                    new Flights { Id = 9, Duration = new TimeSpan(2, 14, 3).ToString(), StartTime =  new DateTime(2021, 9, 21, 17, 12, 00)},
                    new Flights { Id = 10, Duration = new TimeSpan(1, 34, 11).ToString(), StartTime = new DateTime(2021, 8, 3, 18, 34, 0)},
                    new Flights { Id = 11, Duration = new TimeSpan(3, 23, 25).ToString(), StartTime = new DateTime(2021, 8, 5, 19, 53, 00)},
                    new Flights { Id = 12, Duration = new TimeSpan(4, 54, 53).ToString(), StartTime = new DateTime(2021, 10, 30, 20, 43, 00)},
                    new Flights { Id = 13, Duration = new TimeSpan(2, 14, 3).ToString(), StartTime =  new DateTime(2021, 9, 21, 17, 12, 00)},
                    new Flights { Id = 14, Duration = new TimeSpan(1, 34, 11).ToString(), StartTime = new DateTime(2021, 8, 3, 18, 34, 0)},
                    new Flights { Id = 15, Duration = new TimeSpan(3, 23, 25).ToString(), StartTime = new DateTime(2021, 8, 5, 19, 53, 00)},
                    new Flights { Id = 16, Duration = new TimeSpan(4, 54, 53).ToString(), StartTime = new DateTime(2021, 10, 30, 20, 43, 00)}
            });
        }
    }
}
