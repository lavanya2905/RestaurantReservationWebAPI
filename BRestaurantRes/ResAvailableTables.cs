using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BRestaurantRes.Data;
using DRestautrantRes;
using Microsoft.EntityFrameworkCore;

namespace BRestaurantRes
{
   public class ResAvailableTables : IResAvailableTables
    {
        private readonly RESERVContext _context;

        public ResAvailableTables(RESERVContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MRAvailableTables>> GetAllResvationtAsync()
        {
            return await _context.MRAvailableTables
                .Include(m => m.RtableId)
                .ToListAsync();
        }

        public async Task<MRAvailableTables> GetWithResvationByIdAsync(int id)
        {
            return await _context.MRAvailableTables
                .Include(m => m.RtableId)
                .SingleOrDefaultAsync(m => m.RtableId == id); ;
        }

        public async Task UpdateResvation(MRAvailableTables mRAvailableTables, int id)
        {
            _context.MRAvailableTables.Add(mRAvailableTables);
            await _context.SaveChangesAsync();
        }

        public async Task<MRAvailableTables> CreateResvation(MRAvailableTables mRAvailableTables)
        {
            _context.MRAvailableTables.Add(mRAvailableTables);
            await _context.SaveChangesAsync();
            return mRAvailableTables;
        }

        public async Task DeleteResvation(MRAvailableTables mRAvailableTables)
        {
            _context.MRAvailableTables.Remove(mRAvailableTables);
            await _context.SaveChangesAsync();
        }


    }
}
