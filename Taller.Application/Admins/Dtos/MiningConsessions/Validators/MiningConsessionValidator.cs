using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.MiningConsessions.Validators
{
    public class MiningConsessionValidator : AbstractValidator<MiningConsessionSaveDto>
    {
        public MiningConsessionValidator() {
            RuleFor(x => x.Code)
                  .NotNull()
                  .NotEmpty();

            RuleFor(x => x.Name)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.MineralTypeId)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.OriginId)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.TypeId)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.SituationId)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.MiningunitId)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.ConditionId)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.StatemanagementId)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.Issincronized)
              .NotNull()
              .NotEmpty();
        }
    }
}
