using FluentValidation;

namespace Taller.Application.Admins.Dtos.Documents.Validators
{
    public class DocumentValidator : AbstractValidator<DocumentSaveDto>
    {
        public DocumentValidator() {


            RuleFor(x => x.ExternalId)
                .NotEmpty();

        }
    }
}
