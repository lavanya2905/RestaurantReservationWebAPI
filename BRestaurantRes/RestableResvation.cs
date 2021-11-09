using BRestaurantRes.Data;
using DRestautrantRes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRestaurantRes
{
    public class RestableResvation:IRestableResvation
    {
        private readonly ResetaurantResContext _context;

        public RestableResvation(ResetaurantResContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MTReservation>> GetAllReservations()
        {
            return await _context.MTReservation.ToListAsync();
        }

        public async Task<MTReservation> GetReservationsById(int id)
        {
            return await _context.MTReservation
                 .SingleOrDefaultAsync(m => m.ResId == id); ;
        }



        public async Task UpdateReservations(int id, MTReservation mTReservation)
        {
            //_context.MTReservation.Add(mTReservation);
            //await _context.SaveChangesAsync();
            _context.MTReservation.Where(mtReservation =>
           (mtReservation.ResId == id)).Skip<MTReservation>(id);
            await _context.SaveChangesAsync();
        }

        public async Task<MTReservation> CreateReservations(MTReservation mTReservation)
        {
            _context.MTReservation.Add(mTReservation);
            await _context.SaveChangesAsync();
            return mTReservation;
        }

        public async Task DeleteReservations(MTReservation mTReservation)
        {
            _context.MTReservation.Remove(mTReservation);
            await _context.SaveChangesAsync();
        }
        public int GetReservationsByDatetable(DateTime resdate, int restid)
        {

            return _context.MTReservation.Where(mtReservation =>
            (mtReservation.ResDate == resdate) && (mtReservation.RtableId == restid)).Count();


        }


    }
}
