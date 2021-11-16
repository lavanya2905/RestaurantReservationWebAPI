using BRestaurantReservation.Data;
using DRestaurantReservation;
using DRestautrantRes;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<TTableReservation> GetReservationsByDatetable(DateTime resdate)
        {

           List<TTableReservation> result=  _context.TTableReservation.Where(mtReservation =>
            (mtReservation.ResDate == resdate)).ToList();
            return result;

        }
        //public int GetReservationsByDatetable(DateTime resdate, int resid)
        //{

        //    return _context.TTableReservation.Where(mtReservation =>
        //    (mtReservation.ResDate == resdate) && (mtReservation.TableId == resid)).Count();


        //}

    }
}
