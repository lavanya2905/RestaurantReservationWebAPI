using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BRestaurantReservation;
using DRestaurantReservation;
using BRestaurantReservation.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ReservationController : ControllerBase
    {
        private readonly RestaurantReservationContext _context;
        private readonly IRestaurantTableResvation _restaurantTableResvation;
        public ReservationController(RestaurantReservationContext Context)
        {
            _context = Context;
            _restaurantTableResvation = new RestaurantTableResvation(Context);
        }
        [HttpPost]
        public async Task<ActionResult<TTableReservation>> PostReservation([FromBody] TTableReservation tTableReservation)
        {
           
            if (mTReservation.ResDate < System.DateTime.Now.AddMonths(12) && mTReservation.ResDate >= System.DateTime.Now)
            {
                _context.MTReservation.Add(mTReservation);
                List<MRAvailableTables> resAvailTaableresult = await _context.MRAvailableTables.Where(mRAvailableTables =>
                 (mRAvailableTables.Capacity >= mTReservation.NoofPersons)).OrderBy(mRAvailableTables => mRAvailableTables.RtableId).ToListAsync();
                foreach (MRAvailableTables mRAvailableTables in resAvailTaableresult)
                {
                    int resTableProcResult = _restableResvation.GetReservationsByDatetable(mTReservation.ResDate, mRAvailableTables.RtableId);
                    if (resTableProcResult == 0)
                    {
                       
                            mTReservation.RtableId = mRAvailableTables.RtableId;
                            await _context.SaveChangesAsync();
                            resAvailTaableresult.Clear();
                            return CreatedAtAction("GetMTReservation" + "", new { id = mTReservation.ResId }, mTReservation);

                       
                        
                    }
                   

                }

                return NotFound();
            }
            else 
            {
                return BadRequest();
            }
        }

    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<TTableReservation>>> GetMTReservation()
    //    {
    //        // return await _context.MTReservation.ToListAsync();
    //        var restableResvation = await _restableResvation.GetAllReservations();
    //        return Ok(restableResvation);

    //    }


    //    // To get All Rows from Reservation Table based on Id
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<MTReservation>> GetMTReservationId(int id)
    //    {
    //        var restableResvation = await _restableResvation.GetReservationsById(id);
    //        if (restableResvation == null)
    //        {
    //            return NotFound();
    //        }

    //        return restableResvation;

    //    }
    //    // To update  Row in Reservation Table based on Id
    //    [HttpPut("{id}")]
    //    public async Task<ActionResult> PutMTReservation(int id, MTReservation mTReservation)
    //    {
    //        if (id != mTReservation.ResId)
    //        {
    //            return BadRequest();
    //        }
    //        _context.Entry(mTReservation).State = EntityState.Modified;

    //        try
    //        {
    //            await _restableResvation.UpdateReservations(id, mTReservation);
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!MTReservationExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;

    //            }
    //        }

    //        return NoContent();

            

    //    }

    //    // To save  Row in Reservation Table 
    //    [HttpPost]
    //    public async Task<ActionResult<MTReservation>> PostMTReservation(MTReservation mTReservation)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.MTReservation.Add(mTReservation);
    //            List<MRAvailableTables> resAvailTaableresult = await _context.MRAvailableTables.Where(mRAvailableTables =>
    //             (mRAvailableTables.Capacity >= mTReservation.NoofPersons)).OrderBy(mRAvailableTables => mRAvailableTables.RtableId).ToListAsync();
    //            foreach (MRAvailableTables mRAvailableTables in resAvailTaableresult)
    //            {
    //                int resTableProcResult = _restableResvation.GetReservationsByDatetable(mTReservation.ResDate, mRAvailableTables.RtableId);
    //                if (resTableProcResult == 0)
    //                {

    //                    mTReservation.RtableId = mRAvailableTables.RtableId;
    //                    await _context.SaveChangesAsync();
    //                    resAvailTaableresult.Clear();
    //                    return CreatedAtAction("GetMTReservation" + "", new { id = mTReservation.ResId }, mTReservation);



    //                }


    //            }

    //            return NotFound();
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }

    //    }

    
        
   

    

    //// To save  Row in Reservation Table 
    //[HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteMTReservation(int id)
    //    {

    //        if (id == 0)

    //            return BadRequest();


    //        var mTReservation = await _context.MTReservation.FindAsync(id);
    //        if (mTReservation == null)
    //        {
    //            return NotFound();
    //        }

    //        await _restableResvation.DeleteReservations(mTReservation);
    //        await _context.SaveChangesAsync();

    //        return NoContent();


    //    }

    //    private bool MTReservationExists(int id)
    //    {
    //        return _context.MTReservation.Any(e => e.ResId == id);


    //    }


    }
}
