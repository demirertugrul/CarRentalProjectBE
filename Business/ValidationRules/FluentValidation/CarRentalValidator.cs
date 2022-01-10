using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarRentalValidator:AbstractValidator<Rental>
    {
        public CarRentalValidator()
        {
            RuleFor(c => c.RentDate).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CostumerId).NotEmpty();
        }
    }
}
