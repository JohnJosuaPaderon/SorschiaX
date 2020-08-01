using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class UserConverter : IReaderConverter<User>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_FIRSTNAME = "[FirstName]";
        private const string FIELD_MIDDLENAME = "[MiddleName]";
        private const string FIELD_LASTNAME = "[LastName]";
        private const string FIELD_NAMEEXTENSION = "[NameExtension]";
        private const string FIELD_USERNAME = "[Username]";
        private const string FIELD_ISACTIVE = "[IsActive]";
        private const string FIELD_ISPASSWORDCHANGEREQUIRED = "[IsPasswordChangeRequired]";

        private readonly IFieldNameCache _fieldNameCache;

        public UserConverter(IFieldNameCache fieldNameCache)
        {
            _fieldNameCache = fieldNameCache;
        }

        public User Convert(SqlDataReader reader) => new User
        {
            Id = reader.GetInt32(FIELD_ID, _fieldNameCache),
            FirstName = reader.GetString(FIELD_FIRSTNAME, _fieldNameCache),
            MiddleName = reader.GetString(FIELD_MIDDLENAME, _fieldNameCache),
            LastName = reader.GetString(FIELD_LASTNAME, _fieldNameCache),
            NameExtension = reader.GetString(FIELD_NAMEEXTENSION, _fieldNameCache),
            Username = reader.GetString(FIELD_USERNAME, _fieldNameCache),
            IsActive = reader.GetBoolean(FIELD_ISACTIVE, _fieldNameCache),
            IsPasswordChangeRequired = reader.GetBoolean(FIELD_ISPASSWORDCHANGEREQUIRED, _fieldNameCache)
        };
    }
}
