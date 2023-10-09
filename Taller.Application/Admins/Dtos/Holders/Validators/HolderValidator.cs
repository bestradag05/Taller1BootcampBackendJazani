using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Holders.Validators
{
    public class HolderValidator : AbstractValidator<Holder>
    {
        public HolderValidator()
        {

            RuleFor(x => x.Name)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.LastName)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.MaidenName)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.DocumentNumber)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.HolderregimeId)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.HoldergroupId)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.RegistryOfficeId)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.IdentificationDocumentId)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.HoldertypeId)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
