using BRestaurantRes.Data;
using DRestautrantRes;
using ResetaurantRes.Controllers;
using System;
using System.Linq;
using Xunit;

namespace RestaurantResTest
{
    public class SharedDatabaseTest : IClassFixture<DatabaseIntializer>
    {
        public SharedDatabaseTest(DatabaseIntializer fixture) => Fixture = fixture;

        public DatabaseIntializer Fixture { get; }



        [Fact]
        public void SaveReservation()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    var controller = new MTReservationsController(context);
                    MTReservation mTReservation = new MTReservation();

                    var response = controller.PostMTReservation(mTReservation).Result;

                    Assert.Equal("ItemFour", response.Value.Personname);
                }

                using (var context = Fixture.CreateContext(transaction))
                {
                    var response = context.Set<MTReservation>().Single(e => e.Personname == "ItemFour");

                    Assert.Equal("ItemFour", response.Personname);
                    Assert.Equal(0, response.RtableId);
                }
            }

            //ResetaurantResContext _context = new ResetaurantResContext(dbContextOptions);
            ////DBiintialization obj = new DBiintialization();
            ////obj.Seed(context);
            //var controller = new MTReservationsController(_context);

            //MTReservation mTReservation = new MTReservation
            //{
            //    NoofPersons = 12,
            //    ResDate = Convert.ToDateTime("2021-11-22"),
            //    Personname = "lava",

            //};
            //// Act on Test  
            //var response = controller.PostMTReservation(mTReservation).Result;
            //Assert.NotNull(response);



        }












    }







}