using FluentValidation;
using Sorschia.Entities;

namespace Sorschia.Processes.Validators
{
    public sealed class InsertUserValidator : AbstractValidator<InsertUser>
    {
        public InsertUserValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty()
                .MaximumLength(User.FirstNameMaxLength);

            RuleFor(_ => _.MiddleName)
                .MaximumLength(User.MiddleNameMaxLength);

            RuleFor(_ => _.LastName)
                .NotEmpty()
                .MaximumLength(User.LastNameMaxLength);

            RuleFor(_ => _.NameSuffix)
                .MaximumLength(User.NameSuffixMaxLength);

            RuleFor(_ => _.Username)
                .NotEmpty()
                .MaximumLength(User.UsernameMaxLength);

            RuleFor(_ => _.Password)
                .NotEmpty()
                .MaximumLength(User.PasswordMaxLength);

            RuleFor(_ => _.EmailAddress)
                .MaximumLength(User.EmailAddressMaxLength);

            RuleFor(_ => _.MobileNumber)
                .MaximumLength(User.MobileNumberMaxLength);

            RuleForEach(_ => _.ApplicationIds)
                .NotEqual((short)0);

            RuleForEach(_ => _.RoleIds)
                .NotEqual(0);

            RuleForEach(_ => _.PermissionIds)
                .NotEqual(0);
        }
    }
}
