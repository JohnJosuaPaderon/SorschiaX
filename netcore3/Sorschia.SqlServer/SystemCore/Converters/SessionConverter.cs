using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class SessionConverter : IReaderConverter<Session>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_MACADDRESS = "[MacAddress]";
        private const string FIELD_IPADDRESS = "[IpAddress]";
        private const string FIELD_OPERATINGSYSTEM = "[OperatingSystem]";
        private const string FIELD_SESSIONSTART = "[SessionStart]";
        private const string FIELD_SESSIONEND = "[SessionEnd]";
        private const string FIELD_USERID = "[UserId]";
        private const string FIELD_APPLICATIONID = "[ApplicationId]";

        private readonly IFieldNameCache _fieldNameCache;

        public SessionConverter(IFieldNameCache fieldNameCache)
        {
            _fieldNameCache = fieldNameCache;
        }

        public Session Convert(SqlDataReader reader) => new Session
        {
            Id = reader.GetInt64(FIELD_ID, _fieldNameCache),
            MacAddress = reader.GetString(FIELD_MACADDRESS, _fieldNameCache),
            IpAddress = reader.GetString(FIELD_IPADDRESS, _fieldNameCache),
            OperatingSystem = reader.GetString(FIELD_OPERATINGSYSTEM, _fieldNameCache),
            SessionStart = reader.GetDateTime(FIELD_SESSIONSTART, _fieldNameCache),
            SessionEnd = reader.GetNullableDateTime(FIELD_SESSIONEND, _fieldNameCache),
            UserId = reader.GetNullableInt32(FIELD_USERID, _fieldNameCache),
            ApplicationId = reader.GetNullableInt32(FIELD_APPLICATIONID, _fieldNameCache)
        };
    }
}
