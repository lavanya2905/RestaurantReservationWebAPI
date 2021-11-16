using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DRestaurantReservation;
using DRestautrantRes;

namespace BRestaurantReservation
{
   public interface IRestaurantTableResvation
   {
       Task<TTableReservation> CreateReservation(TTableReservation tTableReservation);
        int GetReservationsByDatetable(DateTime resdate,int resid);
    }
}
