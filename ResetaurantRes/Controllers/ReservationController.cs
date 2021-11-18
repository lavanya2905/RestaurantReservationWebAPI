using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BRestaurantReservation;
using DRestaurantReservation;
using BRestaurantReservation.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ReservationController : ControllerBase
    {
        private readonly RestaurantReservationContext dbContext;
        private readonly IRestaurantTableResvation restaurantTableResvation;
        public ReservationController(RestaurantReservationContext DBContext, IRestaurantTableResvation RestaurantTableResvation)
        {
            dbContext = DBContext;
            restaurantTableResvation = RestaurantTableResvation;
        }
        [HttpPost]
        //[ActionName("ReserveTable")]
        public async Task<ActionResult<TTableReservation>> PostReservation([FromBody] ReservationDto pReservationDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validator = new ReservationDtoValidation();
                    var validRes = validator.Validate(pReservationDto);
                    if (validRes.IsValid)
                    {
                       var reservedTables= dbContext.TTableReservation.Where(x => x.ResDate == pReservationDto.ResDate.Date).Select(x => x.TableId);
                        var avaialbleTables = dbContext.MAvaialbleTables.Where(x => x.TCapacity >= pReservationDto.NumberOfPersons && !reservedTables.Contains(x.TableId)).FirstOrDefault();
                        if (avaialbleTables != null)

                        {
                            TTableReservation objReservation = new TTableReservation();
                            objReservation.TableId = avaialbleTables.TableId;
                            objReservation.Name = pReservationDto.Name;
                            objReservation.NumberOfPersons = pReservationDto.NumberOfPersons;
                            objReservation.ResDate = pReservationDto.ResDate.Date;
                            dbContext.TTableReservation.Add(objReservation);
                            await dbContext.SaveChangesAsync();
                            return new ObjectResult(pReservationDto) { StatusCode = StatusCodes.Status201Created };
                        }
                        else
                        {
                            return new ObjectResult(pReservationDto) { StatusCode = StatusCodes.Status404NotFound };
                        }
                    }
                    else
                    {
                        return new ObjectResult(pReservationDto) { StatusCode = StatusCodes.Status404NotFound };
                    }
                }
                else
                    return new ObjectResult(pReservationDto) { StatusCode = StatusCodes.Status404NotFound };
            }
            catch (Exception ex)
            {
                return new ObjectResult(pReservationDto) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
