using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.InvestmentTypes.Validators
{
    public class InvestmentTypeValidator : AbstractValidator<InvestmentTypeSaveDto>
    {
        public InvestmentTypeValidator()
        {
            RuleFor(x => x.Name)
               .NotNull()
               .NotEmpty();
        }
    }
}
