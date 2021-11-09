
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DRestautrantRes;

namespace BRestaurantRes
{
   public interface IResAvailableTables
    {
        Task<IEnumerable<MRAvailableTables>> GetAllAvailableTables();
        Task<MRAvailableTables> GetAvailableTablesById(int id);
        Task<MRAvailableTables> CreateAvailableTables(MRAvailableTables mRAvailableTables);
        Task UpdateAvailableTables(MRAvailableTables mRAvailableTables, int id);
        Task DeleteAvailableTables(MRAvailableTables mRAvailableTables);
    }
