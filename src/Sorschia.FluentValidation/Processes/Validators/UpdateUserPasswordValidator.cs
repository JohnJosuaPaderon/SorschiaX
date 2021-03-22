using FluentValidation;
using Sorschia.Entities;

namespace Sorschia.Processes.Validators
{
    public sealed class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPassword>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(_ => _.UserId)
                .NotEqual(0);

            RuleFor(_ => _.Password)
                .NotEmpty()
                .MaximumLength(User.PasswordMaxLength);
        }
    }
}
