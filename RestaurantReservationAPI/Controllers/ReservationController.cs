using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BRestaurantReservation;
using DRestaurantReservation;
using BRestaurantReservation.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservationAPI.Controllers
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
                        var reservedTables = dbContext.TTableReservation.Where(x => x.ResDate == pReservationDto.ResDate.Date).Select(x => x.TableId);
                        var avaialbleTables = dbContext.MAvaialbleTables.Where(x => x.TCapacity >= pReservationDto.NumberOfPersons && !reservedTables.Contains(x.TableId) && x.TActive==1).FirstOrDefault();
                        if (avaialbleTables != null)
                        {
                            TTableReservation objReservation = new TTableReservation();
                            objReservation.TableId = avaialbleTables.TableId;
                            objReservation.Name = pReservationDto.Name;
                            objReservation.NumberOfPersons = pReservationDto.NumberOfPersons;
                            objReservation.ResDate = pReservationDto.ResDate.Date;
                            objReservation = await restaurantTableResvation.CreateReservation(objReservation);
                            return new ObjectResult(objReservation) { StatusCode = StatusCodes.Status201Created };
                        }
                    }
                }
                return new ObjectResult(null) { StatusCode = StatusCodes.Status404NotFound };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = StatusCodes.Status404NotFound };
            }
        }
    }
}
