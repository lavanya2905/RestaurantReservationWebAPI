using BRestaurantReservation;
using DRestaurantReservation;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Controllers;
using System;
using System.Linq;
using Xunit;
namespace RestaurantReservationTest
{
    public class ReservationDBTest : IClassFixture<DatabaseIntializer>
    {
        public ReservationDBTest(DatabaseIntializer fixture) => Fixture = fixture;
        public DatabaseIntializer Fixture { get; }
        [Fact]
        public void SaveReservation()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    IRestaurantTableResvation restaurantTableResvation = new RestaurantTableResvation(context);
                    var controller = new ReservationController(restaurantTableResvation);
                    ReservationDto rDto = new ReservationDto() { Name = "lava", ResDate = DateTime.Now.AddDays(3), NumberOfPersons = 2 };
                    var result = controller.PostReservation(rDto);
                    Assert.NotNull(result);

                }

            }

        }
    }
}
