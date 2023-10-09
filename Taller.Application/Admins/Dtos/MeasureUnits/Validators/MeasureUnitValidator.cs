using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.MeasureUnits.Validators
{
    public class MeasureUnitValidator : AbstractValidator<MeasureUnitSaveDto>
    {
        public MeasureUnitValidator()
        {
            RuleFor(x => x.Name)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.Symbol)
              .NotNull()
              .NotEmpty();
        }
    }
}
