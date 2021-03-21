using FluentValidation;
using Sorschia.Entities;

namespace Sorschia.Processes.Validators
{
    public sealed class SaveApplicationValidator : AbstractValidator<SaveApplication>
    {
        public SaveApplicationValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .MaximumLength(Application.NameMaxLength);

            RuleFor(_ => _.Description)
                .MaximumLength(Application.DescriptionMaxLength);

            RuleForEach(_ => _.Roles)
                .ChildRules(RoleValidator);

            RuleForEach(_ => _.Permissions)
                .ChildRules(PermissionValidator);

            RuleForEach(_ => _.DeletedRoleIds)
                .NotEqual(0);

            RuleForEach(_ => _.DeletedPermissionIds)
                .NotEqual(0);
        }

        private void RoleValidator(InlineValidator<SaveApplication.RoleObj> rules)
        {
            rules.RuleFor(_ => _.Name)
                .NotEmpty()
                .MaximumLength(Role.NameMaxLength);

            rules.RuleFor(_ => _.Description)
                .MaximumLength(Role.DescriptionMaxLength);

            rules.RuleForEach(_ => _.Permissions)
                .ChildRules(PermissionValidator);

            rules.RuleForEach(_ => _.DeletedPermissionIds)
                .NotEqual(0);
        }

        private void PermissionValidator(InlineValidator<SaveApplication.PermissionObj> rules)
        {
            rules.RuleFor(_ => _.Name)
                .NotEmpty()
                .MaximumLength(Permission.NameMaxLength);

            rules.RuleFor(_ => _.Description)
                .MaximumLength(Permission.DescriptionMaxLength);

            rules.RuleForEach(_ => _.AspNetRoutes)
                .ChildRules(PermissionAspNetRouteValidator);

            rules.RuleForEach(_ => _.DeletedAspNetRouteIds)
                .NotEqual(0);
        }

        private void PermissionAspNetRouteValidator(InlineValidator<SaveApplication.PermissionAspNetRouteObj> rules)
        {
            rules.RuleFor(_ => _.AspNetArea)
                .MaximumLength(PermissionAspNetRoute.AspNetAreaMaxLength);

            rules.RuleFor(_ => _.AspNetController)
                .NotEmpty()
                .MaximumLength(PermissionAspNetRoute.AspNetControllerMaxLength);

            rules.RuleFor(_ => _.AspNetAction)
                .NotEmpty()
                .MaximumLength(PermissionAspNetRoute.AspNetActionMaxLength);
        }
    }
}
