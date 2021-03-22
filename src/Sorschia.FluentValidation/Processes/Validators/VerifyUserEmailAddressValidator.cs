using FluentValidation;

namespace Sorschia.Processes.Validators
{
    public sealed class VerifyUserEmailAddressValidator : AbstractValidator<VerifyUserEmailAddress>
    {
        public VerifyUserEmailAddressValidator()
        {
            RuleFor(_ => _.UserId)
                .NotEqual(0);
        }
    }
}
