using System;

namespace Sorschia.Entities
{
    public abstract class DbEntityBase
    {
        public bool IsDeleted { get; set; }
        public int? InsertedById { get; set; }
        public DateTimeOffset? InsertedOn { get; set; }
        public int? UpdatedById { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public int? DeletedById { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        public virtual DbUser? InsertedBy { get; set; }
        public virtual DbUser? UpdatedBy { get; set; }
        public virtual DbUser? DeletedBy { get; set; }
    }

    public class DbUser : DbEntityBase
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameExtension { get; set; }
        public string EmailAddress { get; set; } = default!;
        public bool IsActive { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsPasswordChangeRequired { get; set; }

        public static implicit operator User(DbUser source)
        {
            if (source is null)
                throw new SorschiaException($"Parameter '{nameof(source)}' is null");

            return new User
            {

            };
        }
    }

    public class DbRole : DbEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;


    }
}
