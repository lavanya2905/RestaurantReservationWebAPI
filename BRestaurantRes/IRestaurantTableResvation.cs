using System.Threading.Tasks;
using DRestaurantReservation;

namespace BRestaurantReservation
{
   public interface IRestaurantTableResvation
   {
       Task<TTableReservation> CreateReservation(TTableReservation tTableReservation);
   }
}
