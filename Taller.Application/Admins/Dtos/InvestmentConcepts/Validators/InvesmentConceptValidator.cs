using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.InvestmentConcepts.Validators
{
    public class InvesmentConceptValidator : AbstractValidator<InvestmentConceptSaveDto>
    {
        public InvesmentConceptValidator()
        {
            RuleFor(x => x.Name)
               .NotNull()
               .NotEmpty();
        }
    }
}
