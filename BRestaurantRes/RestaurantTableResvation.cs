using BRestaurantReservation.Data;
using DRestaurantReservation;
using System.Linq;
using System.Threading.Tasks;

namespace BRestaurantReservation
{
    public class RestaurantTableResvation:IRestaurantTableResvation
    {
        private readonly RestaurantReservationContext dbContext;
        public RestaurantTableResvation(RestaurantReservationContext Context)
        {
            dbContext = Context;
        }
        public async Task<TTableReservation> CreateReservation(ReservationDto objReservationDto)
        {
            try
            {
                var reservedTables = dbContext.TTableReservation.Where(x => x.ResDate == objReservationDto.ResDate.Date).Select(x => x.TableId);
                var avaialbleTables = dbContext.MAvaialbleTables.Where(x => x.TCapacity >= objReservationDto.NumberOfPersons && !reservedTables.Contains(x.TableId) && x.TActive == 1).FirstOrDefault();
                if (avaialbleTables != null)
                {
                    TTableReservation objReservation = new TTableReservation();
                    objReservation.TableId = avaialbleTables.TableId;
                    objReservation.Name = objReservationDto.Name;
                    objReservation.NumberOfPersons = objReservationDto.NumberOfPersons;
                    objReservation.ResDate = objReservationDto.ResDate.Date;
                    dbContext.TTableReservation.Add(objReservation);
                    await dbContext.SaveChangesAsync();
                    return objReservation;
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
