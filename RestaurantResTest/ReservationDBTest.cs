using DRestaurantReservation;
using RestaurantReservation.Controllers;
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
                    var response = context.Set<TTableReservation>().Single(e => e.Name == "lava");
                    Assert.Equal("lava", response.Name);
                    Assert.NotNull(response);
                }
                using (var context = Fixture.CreateContext(transaction))
                {
                    var controller = new ReservationController(context);
                    var responsereserv = context.Set<TTableReservation>().Single(e => e.Name == "lava");
                    responsereserv.ResId = 0;
                    //var response = controller.PostReservation(responsereserv);
                    //Assert.NotNull(response.Result);
                               
                }

            }

        }
    }


}
