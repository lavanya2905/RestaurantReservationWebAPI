using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace BRestaurantReservation
{
  public class ReservationDtoValidation : AbstractValidator<ReservationDto>
  {
        public ReservationDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).Must(x => HasValidName(x));
            RuleFor(x => x.ResDate).NotEmpty().InclusiveBetween(DateTime.UtcNow.Date,DateTime.UtcNow.AddMonths(12).Date);
            RuleFor(x => x.NumberOfPersons).NotEqual(0).InclusiveBetween(1,12);
        }
        private bool HasValidName(string name)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            return (lowercase.IsMatch(name) || uppercase.IsMatch(name));
        }

  }

}
