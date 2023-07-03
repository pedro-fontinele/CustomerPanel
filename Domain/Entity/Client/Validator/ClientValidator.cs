using FluentValidation;
using CustomerPanel.Domain.Entity.Dto;
using CustomerPanel.Domain.Entity.Validator.ErrorMessage;

namespace CustomerPanel.Domain.Entity.Validator
{
    public class ClientValidator : AbstractValidator<ClientDtoAction>
    {
        public ClientValidator()
        {
            RuleFor(e => e.LegalName).NotEmpty().WithMessage(ClientErrorMessage.LegalNameMustBeInformed)
                                     .NotNull().WithMessage(ClientErrorMessage.FieldCannotBeNull)
                                     .MaximumLength(150).WithMessage(ClientErrorMessage.ExceededNumberOfCharacters);

            RuleFor(e => e.Mail).NotEmpty().WithMessage(ClientErrorMessage.MailMustBeInformed)
                                .NotNull().WithMessage(ClientErrorMessage.FieldCannotBeNull)
                                .MaximumLength(150).WithMessage(ClientErrorMessage.ExceededNumberOfCharacters);

            RuleFor(e => e.Telephone).NotEmpty().WithMessage(ClientErrorMessage.TelephoneMustBeInformed)
                                     .NotNull().WithMessage(ClientErrorMessage.FieldCannotBeNull);
        }
    }
}
