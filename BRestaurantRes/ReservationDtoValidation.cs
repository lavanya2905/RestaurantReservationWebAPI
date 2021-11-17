using DRestaurantReservation;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace BRestaurantReservation
{
  public class ReservationDtoValidation : AbstractValidator<TTableReservation>
  {
        public ReservationDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 20).Must(x => HasValidName(x));
            RuleFor(x => x.ResDate).NotEmpty().InclusiveBetween(DateTime.UtcNow.Date,DateTime.UtcNow.AddMonths(12).Date);
            RuleFor(x => x.NumberOfPersons).NotEmpty().InclusiveBetween(1,12);
        }
        private bool HasValidName(string name)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            return (lowercase.IsMatch(name) || uppercase.IsMatch(name));
        }

  }

}
