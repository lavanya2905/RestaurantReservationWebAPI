using System;

namespace BRestaurantReservation
{
    public sealed  class ReservationDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ResDate { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
