using Business.Constrants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(25000);
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).Must(GreaterThanNineteenthCentruies).WithMessage(Messages.GTModelYear);

        }

        private bool GreaterThanNineteenthCentruies(DateTime dateTime)
        {
            return new DateTime(1886, 1, 1) < dateTime;
        }
    }
}
