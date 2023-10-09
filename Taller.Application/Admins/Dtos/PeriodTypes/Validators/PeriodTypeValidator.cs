using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.PeriodTypes.Validators
{
    public class PeriodTypeValidator : AbstractValidator<PeriodTypeSaveDto>
    {
        public PeriodTypeValidator() {

            RuleFor(x => x.Name)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.Time)
           .NotNull()
           .NotEmpty();

        }
    }
}
