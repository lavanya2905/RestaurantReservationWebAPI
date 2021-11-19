using BRestaurantReservation;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Controllers;
using System;

using Xunit;

namespace RestaurantReservationTest
{
    public class ReservationDBTest : IClassFixture<DatabaseIntializer>
    {
        public ReservationDBTest(DatabaseIntializer fixture) => Fixture = fixture;
        public DatabaseIntializer Fixture { get; }
        [Fact]
        public async void SaveReservation()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    IRestaurantTableResvation restaurantTableResvation = new RestaurantTableResvation(context);
                    var controller = new ReservationController(restaurantTableResvation);
                    ReservationDto rDto = new ReservationDto() { Name = "lava", ResDate = DateTime.Now.AddDays(3), NumberOfPersons = 2 };
                    var actionResult =await  controller.PostReservation(rDto);
                    StatusCodeResult objectResponse = Assert.IsType<StatusCodeResult>(actionResult);
                    Assert.Equal(201, objectResponse.StatusCode);
                    Assert.NotNull(actionResult);
                }
                using (var context = Fixture.CreateContext(transaction))
                {
                    IRestaurantTableResvation restaurantTableResvation = new RestaurantTableResvation(context);
                    var controller = new ReservationController(restaurantTableResvation);
                    ReservationDto rDto = new ReservationDto() { Name = "lava", ResDate = DateTime.Now.AddDays(400), NumberOfPersons = 2 };
                    var actionResult = await controller.PostReservation(rDto);
                    Microsoft.AspNetCore.Mvc.ObjectResult objectResponse = Assert.IsType<Microsoft.AspNetCore.Mvc.ObjectResult>(actionResult);
                    Assert.Equal(404, objectResponse.StatusCode);
                    Assert.NotNull(actionResult);
                }
            }
        }
    }
}
