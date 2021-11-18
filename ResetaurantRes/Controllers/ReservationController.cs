using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BRestaurantReservation;
using DRestaurantReservation;
using Microsoft.AspNetCore.Http;
using System;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ReservationController : ControllerBase
    {
        private readonly IRestaurantTableResvation restaurantTableResvation;
        public ReservationController(IRestaurantTableResvation RestaurantTableResvation)
        {
            restaurantTableResvation = RestaurantTableResvation;
        }
        [HttpPost]
       public async Task<ActionResult<TTableReservation>> PostReservation([FromBody] ReservationDto objReservationDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validator = new ReservationDtoValidation();
                    var validRes = validator.Validate(objReservationDto);
                    if (validRes.IsValid)
                    {
                        var objResult = await restaurantTableResvation.CreateReservation(objReservationDto);
                        if (objResult != null)
                            return new ObjectResult(objReservationDto) { StatusCode = StatusCodes.Status201Created };
                      
                    }
                }
                return new ObjectResult(objReservationDto) { StatusCode = StatusCodes.Status404NotFound };
            }
            catch (Exception)
            {
                return new ObjectResult(objReservationDto) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
