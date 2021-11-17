﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BRestaurantReservation;
using DRestaurantReservation;
using BRestaurantReservation.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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
                    var avaialbleTables = await _context.MAvaialbleTables.FromSqlRaw("exec P_GetAvailableTables @ResDate={0},@NumberOfPersons={1}", 
                        tTableReservation.ResDate.Date, tTableReservation.NumberOfPersons).ToListAsync();
                    if (avaialbleTables.Count != 0)
                    {
                        tTableReservation.TableId = avaialbleTables.FirstOrDefault().TableId;
                        tTableReservation.ResDate = tTableReservation.ResDate.Date;
                        await _context.SaveChangesAsync();
                        return new ObjectResult(tTableReservation) { StatusCode = StatusCodes.Status201Created };
                    }
                    else
                    {
                        return new ObjectResult(tTableReservation) { StatusCode = StatusCodes.Status404NotFound };
                    }
                }
                else
                {
                    return new ObjectResult(tTableReservation) { StatusCode = StatusCodes.Status404NotFound };
                }
            //}
            //catch (Exception)
            //{
            //    return new ObjectResult(tTableReservation) { StatusCode = StatusCodes.Status404NotFound };
            //}
        }
    }
}
