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
            

                return NotFound();
            var validator = new ReservationDtoValidation();
            var validRes = validator.Validate(tTableReservation);
            if (!validRes.IsValid)
            {
                if (tTableReservation.ResDate < System.DateTime.Now.AddMonths(12) && tTableReservation.ResDate >= System.DateTime.Now)
                {
                    _context.TTableReservation.Add(tTableReservation);
                     //List<TTableReservation> exceptionList = _context.TTableReservation.Where(x => x.ResDate == tTableReservation.ResDate).ToList(); 
              //    var result = _context.MAvaialbleTables.Where(t =>( t.TCapacity >= tTableReservation.NumberOfPersons) && (!t.TableId.(exceptionList)))
                  //           .OrderBy(mRAvailableTables => mRAvailableTables.TableId).DefaultIfEmpty().First();
                    
                    
                    List<MAvaialbleTables> resAvailTaableresult = await _context.MAvaialbleTables.Where(mRAvailableTables =>
                    (mRAvailableTables.TCapacity >= tTableReservation.NumberOfPersons)).OrderBy(mRAvailableTables => mRAvailableTables.TableId).ToListAsync();
                    foreach (MAvaialbleTables mRAvailableTables in resAvailTaableresult)
                    {
                        int resTableProcResult = _restaurantTableResvation.GetReservationsByDatetable(tTableReservation.ResDate, mRAvailableTables.TableId);
                        if (resTableProcResult == 0)
                        {

                            tTableReservation.TableId = mRAvailableTables.TableId;
                            await _context.SaveChangesAsync();
                            resAvailTaableresult.Clear();
                            return CreatedAtAction("GetMTReservation" + "", new { id = tTableReservation.ResId }, tTableReservation);
                        }

                    }
               
                
                }
                return NotFound();

            }
            else
            {
                return BadRequest();
            }

        }

    }
        
       
    
    
}
