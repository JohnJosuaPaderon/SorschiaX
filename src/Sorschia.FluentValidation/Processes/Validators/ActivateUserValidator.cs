using FluentValidation;

namespace Sorschia.Processes.Validators
{
    public sealed class ActivateUserValidator : AbstractValidator<ActivateUser>
    {
        public ActivateUserValidator()
        {
            RuleFor(_ => _.UserId)
                .NotEqual(0);
        }
    }
}
