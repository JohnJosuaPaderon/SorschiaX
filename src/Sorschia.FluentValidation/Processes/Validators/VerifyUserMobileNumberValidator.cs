using FluentValidation;

namespace Sorschia.Processes.Validators
{
    public sealed class VerifyUserMobileNumberValidator : AbstractValidator<VerifyUserMobileNumber>
    {
        public VerifyUserMobileNumberValidator()
        {
            RuleFor(_ => _.UserId)
                .NotEqual(0);
        }
    }
}
