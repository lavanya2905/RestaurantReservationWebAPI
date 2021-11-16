using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRestaurantReservation;
using DRestaurantReservation;
using System.Net.Http;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResController : ControllerBase
    {

        //public sealed  HttpResponseMessage PostRes([FromBody] TTableReservation tTableReservation)
        //{
        //    //try
        //    //{
        //    //    using (TESTEntities entities = new TESTEntities())
        //    //    {
        //    //        entities.employeesDatas.Add(employee);
        //    //        entities.SaveChanges();
        //    //        var message = Request.CreateResponse(HttpStatusCode.Created, employee);
        //    //        message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
        //    //        return message;
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    //}
        //}


    }
}
