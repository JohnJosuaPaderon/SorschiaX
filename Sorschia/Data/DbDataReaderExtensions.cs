using System;
using System.Data.Common;
using System.IO;

namespace Sorschia.Data
{
    public static class DbDataReaderExtensions
    {
        private static void Validate(DbDataReader reader, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new SorschiaDataException("fieldname is set to null or white space.");
            }

            if (reader.FieldCount <= 0)
            {
                throw new SorschiaDataException("reader has no fields.");
            }
        }

        private static bool ColumnExists(DbDataReader reader, string fieldName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), fieldName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static T Get<T>(this DbDataReader instance, string fieldName, Func<object, T, T> convert, T valueIfDefault = default)
        {
            Validate(instance, fieldName);
            return ColumnExists(instance, fieldName) ? convert(instance[fieldName], valueIfDefault) : valueIfDefault;
        }

        private static T Get<T>(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, Func<object, IFormatProvider, T, T> convert, T valueIfDefault = default)
        {
            Validate(instance, fieldName);
            return ColumnExists(instance, fieldName) ? convert(instance[fieldName], formatProvider, valueIfDefault) : valueIfDefault;
        }

        public static bool GetBoolean(this DbDataReader instance, string fieldName, bool valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToBoolean, valueIfDefault);
        }

        public static bool GetBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, bool valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToBoolean, valueIfDefault);
        }

        public static byte GetByte(this DbDataReader instance, string fieldName, byte valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToByte, valueIfDefault);
        }

        public static byte GetByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, byte valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToByte, valueIfDefault);
        }

        public static byte[] GetByteArray(this DbDataReader instance, string fieldName, byte[] valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToByteArray, valueIfDefault);
        }

        public static char GetChar(this DbDataReader instance, string fieldName, char valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToChar, valueIfDefault);
        }

        public static char GetChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, char valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToChar, valueIfDefault);
        }

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName, DateTime valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToDateTime, valueIfDefault);
        }

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, DateTime valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToDateTime, valueIfDefault);
        }

        public static decimal GetDecimal(this DbDataReader instance, string fieldName, decimal valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToDecimal, valueIfDefault);
        }

        public static decimal GetDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, decimal valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToDecimal, valueIfDefault);
        }

        public static double GetDouble(this DbDataReader instance, string fieldName, double valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToDouble, valueIfDefault);
        }


        public static double GetDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, double valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToDouble, valueIfDefault);
        }

        public static short GetInt16(this DbDataReader instance, string fieldName, short valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToInt16, valueIfDefault);
        }

        public static short GetInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, short valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToInt16, valueIfDefault);
        }

        public static int GetInt32(this DbDataReader instance, string fieldName, int valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToInt32, valueIfDefault);
        }

        public static int GetInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, int valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToInt32, valueIfDefault);
        }

        public static long GetInt64(this DbDataReader instance, string fieldName, long valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToInt64, valueIfDefault);
        }

        public static long GetInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, long valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToInt64, valueIfDefault);
        }

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName, bool? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableBoolean, valueIfDefault);
        }

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, bool? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableBoolean, valueIfDefault);
        }

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName, byte? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableByte, valueIfDefault);
        }

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, byte? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableByte, valueIfDefault);
        }

        public static char? GetNullableChar(this DbDataReader instance, string fieldName, char? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableChar, valueIfDefault);
        }

        public static char? GetNullableChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, char? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableChar, valueIfDefault);
        }

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName, DateTime? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableDateTime, valueIfDefault);
        }

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, DateTime? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableDateTime, valueIfDefault);
        }

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName, decimal? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableDecimal, valueIfDefault);
        }

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, decimal? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableDecimal, valueIfDefault);
        }

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName, double? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableDouble, valueIfDefault);
        }

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, double? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableDouble, valueIfDefault);
        }

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName, short? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableInt16, valueIfDefault);
        }

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, short? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableInt16, valueIfDefault);
        }

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName, int? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableInt32, valueIfDefault);
        }

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, int? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableInt32, valueIfDefault);
        }

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName, long? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableInt64, valueIfDefault);
        }

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, long? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableInt64, valueIfDefault);
        }

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName, sbyte? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableSByte, valueIfDefault);
        }

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, sbyte? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableSByte, valueIfDefault);
        }

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName, float? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableSingle, valueIfDefault);
        }

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, float? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableSingle, valueIfDefault);
        }

        public static TimeSpan? GetNullableTimeSpan(this DbDataReader instance, string fieldName, TimeSpan? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableTimeSpan, valueIfDefault);
        }

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName, ushort? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableUInt16, valueIfDefault);
        }

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ushort? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableUInt16, valueIfDefault);
        }

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName, uint? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableUInt32, valueIfDefault);
        }

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, uint? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableUInt32, valueIfDefault);
        }

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName, ulong? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableUInt64, valueIfDefault);
        }

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ulong? valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableUInt64, valueIfDefault);
        }

        public static sbyte GetSByte(this DbDataReader instance, string fieldName, sbyte valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToSByte, valueIfDefault);
        }

        public static sbyte GetSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, sbyte valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToSByte, valueIfDefault);
        }

        public static float GetSingle(this DbDataReader instance, string fieldName, float valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToSingle, valueIfDefault);
        }

        public static float GetSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, float valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToSingle, valueIfDefault);
        }

        public static Stream GetStream(this DbDataReader instance, string fieldName, Stream valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToStream, valueIfDefault);
        }

        public static string GetString(this DbDataReader instance, string fieldName, string valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToString, valueIfDefault);
        }

        public static string GetString(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToString, valueIfDefault);
        }

        public static TimeSpan GetTimeSpan(this DbDataReader instance, string fieldName, TimeSpan valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToTimeSpan, valueIfDefault);
        }

        public static ushort GetUInt16(this DbDataReader instance, string fieldName, ushort valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToUInt16, valueIfDefault);
        }

        public static ushort GetUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ushort valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToUInt16, valueIfDefault);
        }

        public static uint GetUInt32(this DbDataReader instance, string fieldName, uint valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToUInt32, valueIfDefault);
        }

        public static uint GetUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, uint valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToUInt32, valueIfDefault);
        }

        public static ulong GetUInt64(this DbDataReader instance, string fieldName, ulong valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToUInt64, valueIfDefault);
        }

        public static ulong GetUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ulong valueIfDefault = default)
        {
            return instance.Get(fieldName, formatProvider, DbValueConverter.ToUInt64, valueIfDefault);
        }

        public static Guid GetGuid(this DbDataReader instance, string fieldName, Guid valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToGuid, valueIfDefault);
        }

        public static Guid? GetNullableGuid(this DbDataReader instance, string fieldName, Guid? valueIfDefault = default)
        {
            return instance.Get(fieldName, DbValueConverter.ToNullableGuid, valueIfDefault);
        }
    }
}
