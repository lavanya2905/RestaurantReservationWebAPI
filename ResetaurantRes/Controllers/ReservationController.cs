using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BRestaurantReservation;
using DRestaurantReservation;
using BRestaurantReservation.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

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
            //try
            //{
                    var validator = new ReservationDtoValidation();
                    var validRes = validator.Validate(tTableReservation);
                    if (validRes.IsValid)
                    {
                           _context.TTableReservation.Add(tTableReservation);
                            var exceptionList = _context.TTableReservation.Where(x => x.ResDate == tTableReservation.ResDate).ToList();
                    string ddd = Convert.ToDateTime(tTableReservation.ResDate).ToString("yyyy-MM-dd");
                   var result1 = _context.MAvaialbleTables.FromSqlRaw("exec P_GetAvailableTables").DefaultIfEmpty().First();
                   var result = _context.MAvaialbleTables.FromSqlRaw("exec P_GetAvailableTables @ResDate={0}", Convert.ToDateTime(tTableReservation.ResDate).ToString("yyyy-MM-dd")).DefaultIfEmpty().First();
                    if (result != null)
                            {
                                tTableReservation.TableId = result.TableId;
                                await _context.SaveChangesAsync();
                                return new ObjectResult(tTableReservation) { StatusCode = StatusCodes.Status201Created };
                            }
                            else
                            {
                                return NotFound();
                            }
                    }
                    else
                    {
                       return NotFound();
                    }
            //}

            //catch(Exception ex)
            //{
            //    return NotFound();
            //}
          

        }


    }

}
