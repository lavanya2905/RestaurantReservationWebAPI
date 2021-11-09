using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DRestautrantRes;

namespace BRestaurantRes
{
   public interface IRestableResvation
    {
        Task<IEnumerable<MTReservation>> GetAllReservations();
        Task<MTReservation> GetReservationsById(int id);
        int GetReservationsByDatetable(DateTime resdate, int restid);
        Task<MTReservation> CreateReservations(MTReservation mTReservation);
        Task UpdateReservations(int id, MTReservation mTReservation);
        Task DeleteReservations(MTReservation mTReservation);
    }
}
