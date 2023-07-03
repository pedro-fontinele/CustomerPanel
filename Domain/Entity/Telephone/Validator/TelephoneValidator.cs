using FluentValidation;
using CustomerPanel.Domain.Entity.Dto;
using CustomerPanel.Domain.Entity.Validator.ErrorMessage;

namespace CustomerPanel.Domain.Entity.Validator
{
    public class TelephoneValidator :  AbstractValidator<TelephoneDtoAction>
    {
        public TelephoneValidator()
        {
            RuleFor(e => e.DDD).NotEmpty().WithMessage(TelephoneErrorMessage.DDDMustBeInformed)
                               .NotNull().WithMessage(TelephoneErrorMessage.FieldCannotBeNull);

            RuleFor(e => e.Number).NotEmpty().WithMessage(TelephoneErrorMessage.NumberMustBeInformed)
                                  .NotNull().WithMessage(TelephoneErrorMessage.FieldCannotBeNull);

            RuleFor(e => e.TypeNumber).NotEmpty().WithMessage(TelephoneErrorMessage.TypeNumberMustBeInformed)
                                      .NotNull().WithMessage(TelephoneErrorMessage.FieldCannotBeNull);
        }
    }
}