using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sorschia.Entities;
using Sorschia.Utilities;
using System;

namespace Sorschia.ChangeTracking
{
    public static class EntityEntryExtensions
    {
        private const string ENTITYBASE_ISDELETED = nameof(EntityBase.IsDeleted);
        private const string ENTITYBASE_INSERTEDON = nameof(EntityBase.InsertedOn);
        private const string ENTITYBASE_INSERTEDBYID = nameof(EntityBase.InsertedById);
        private const string ENTITYBASE_UPDATEDON = nameof(EntityBase.UpdatedOn);
        private const string ENTITYBASE_UPDATEDBYID = nameof(EntityBase.UpdatedById);
        private const string ENTITYBASE_DELETEDON = nameof(EntityBase.DeletedOn);
        private const string ENTITYBASE_DELETEDBYID = nameof(EntityBase.DeletedById);
        private const string INAME_FULLNAME = nameof(IName.FullName);

        public static EntityEntry ConfigureEntityBaseFields(this EntityEntry instance)
        {
            var currentUserId = instance.Context.GetService<ICurrentUserIdProvider>().CurrentUserId;
            var currentDate = DateTimeOffset.Now;

            if (instance.Entity is EntityBase)
            {
                switch (instance.State)
                {
                    case EntityState.Added:
                        instance.CurrentValues[ENTITYBASE_ISDELETED] = false;
                        instance.CurrentValues[ENTITYBASE_INSERTEDBYID] = currentUserId;
                        instance.CurrentValues[ENTITYBASE_INSERTEDON] = currentDate;
                        break;
                    case EntityState.Modified:
                        instance.CurrentValues[ENTITYBASE_UPDATEDBYID] = currentUserId;
                        instance.CurrentValues[ENTITYBASE_UPDATEDON] = currentDate;
                        break;
                    case EntityState.Deleted:
                        instance.State = EntityState.Modified;
                        instance.CurrentValues[ENTITYBASE_ISDELETED] = true;
                        instance.CurrentValues[ENTITYBASE_DELETEDBYID] = currentUserId;
                        instance.CurrentValues[ENTITYBASE_DELETEDON] = currentDate;
                        break;
                }
            }

            return instance;
        }

        public static EntityEntry<EntityBase> ConfigureEntityBaseFields(this EntityEntry<EntityBase> instance)
        {
            var currentUserId = instance.Context.GetService<ICurrentUserIdProvider>().CurrentUserId;
            var currentDate = DateTimeOffset.Now;

            switch (instance.State)
            {
                case EntityState.Added:
                    instance.CurrentValues[ENTITYBASE_ISDELETED] = false;
                    instance.CurrentValues[ENTITYBASE_INSERTEDBYID] = currentUserId;
                    instance.CurrentValues[ENTITYBASE_INSERTEDON] = currentDate;
                    break;
                case EntityState.Modified:
                    instance.CurrentValues[ENTITYBASE_UPDATEDBYID] = currentUserId;
                    instance.CurrentValues[ENTITYBASE_UPDATEDON] = currentDate;
                    break;
                case EntityState.Deleted:
                    instance.State = EntityState.Modified;
                    instance.CurrentValues[ENTITYBASE_ISDELETED] = true;
                    instance.CurrentValues[ENTITYBASE_DELETEDBYID] = currentUserId;
                    instance.CurrentValues[ENTITYBASE_DELETEDON] = currentDate;
                    break;
            }

            return instance;
        }

        public static EntityEntry BuildFullName(this EntityEntry instance)
        {
            var builder = instance.Context.GetService<IFullNameBuilder>();

            if (instance.Entity is IName name)
            {
                switch (instance.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        instance.CurrentValues[INAME_FULLNAME] = builder.Build(name.FirstName, name.MiddleName, name.LastName, name.NameSuffix);
                        break;
                }
            }

            return instance;
        }
    }
}
