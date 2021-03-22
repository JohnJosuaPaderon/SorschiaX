using FluentValidation;

namespace Sorschia.Processes.Validators
{
    public sealed class RequireUserPasswordChangeValidator : AbstractValidator<RequireUserPasswordChange>
    {
        public RequireUserPasswordChangeValidator()
        {
            RuleFor(_ => _.UserId)
                .NotEqual(0);
        }
    }
}
