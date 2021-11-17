using BRestaurantReservation.Data;
using DRestaurantReservation;
using System.Threading.Tasks;

namespace BRestaurantReservation
{
    public class RestaurantTableResvation:IRestaurantTableResvation
    {
        private readonly RestaurantReservationContext _context;
        public RestaurantTableResvation(RestaurantReservationContext context)
        {
            _context = context;
        }
        public async Task<TTableReservation> CreateReservation(TTableReservation tTableReservation)
        {
            _context.TTableReservation.Add(tTableReservation);
            await _context.SaveChangesAsync();
            return tTableReservation;
        }
    }
}
