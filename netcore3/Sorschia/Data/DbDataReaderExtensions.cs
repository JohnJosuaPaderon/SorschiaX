using Sorschia.Utilities;
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
                throw new SorschiaDataException("fieldname is set to null or white space.");

            if (reader.FieldCount <= 0)
                throw new SorschiaDataException("reader has no fields.");
        }

        private static bool ColumnExists(DbDataReader reader, string fieldName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), fieldName, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }

            return false;
        }

        private static T Get<T>(this DbDataReader instance, string fieldName, Convert<T> convert, T valueIfDefault = default)
        {
            Validate(instance, fieldName);
            return ColumnExists(instance, fieldName) ? convert(instance[fieldName], valueIfDefault) : valueIfDefault;
        }

        private static T Get<T>(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, Convert<T> convert, T valueIfDefault = default)
        {
            if (fieldNameCache is null)
                throw SorschiaException.InvalidParameter<IFieldNameCache>(nameof(fieldNameCache));

            if (string.IsNullOrWhiteSpace(fieldName))
                throw new SorschiaDataException("fieldName is set to null or white-space");

            if (fieldNameCache.TryGet(instance, fieldName, out object result))
                return convert(result, valueIfDefault);

            return default;
        }

        private static T Get<T>(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ConvertWithFormatProvider<T> convert, T valueIfDefault = default)
        {
            Validate(instance, fieldName);
            return ColumnExists(instance, fieldName) ? convert(instance[fieldName], formatProvider, valueIfDefault) : valueIfDefault;
        }

        private static T Get<T>(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, ConvertWithFormatProvider<T> convert, T valueIfDefault = default)
        {
            if (fieldNameCache is null)
                throw SorschiaDataException.InvalidParameter<IFieldNameCache>(nameof(fieldNameCache));

            if (string.IsNullOrWhiteSpace(fieldName))
                throw new SorschiaDataException("fieldName is set to null or white-space");

            if (fieldNameCache.TryGet(instance, fieldName, out object result))
                return convert(result, formatProvider, valueIfDefault);

            return default;
        }

        public static bool GetBoolean(this DbDataReader instance, string fieldName, bool valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToBoolean, valueIfDefault);

        public static bool GetBoolean(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, bool valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToBoolean, valueIfDefault);

        public static bool GetBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, bool valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToBoolean, valueIfDefault);

        public static bool GetBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, bool valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToBoolean, valueIfDefault);

        public static byte GetByte(this DbDataReader instance, string fieldName, byte valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToByte, valueIfDefault);

        public static byte GetByte(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, byte valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToByte, valueIfDefault);

        public static byte GetByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, byte valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToByte, valueIfDefault);

        public static byte GetByte(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, IFormatProvider formatProvider, byte valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToByte, valueIfDefault);

        public static byte[] GetByteArray(this DbDataReader instance, string fieldName, byte[] valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToByteArray, valueIfDefault);

        public static byte[] GetByteArray(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, byte[] valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToByteArray, valueIfDefault);

        public static char GetChar(this DbDataReader instance, string fieldName, char valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToChar, valueIfDefault);

        public static char GetChar(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, char valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToChar, valueIfDefault);

        public static char GetChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, char valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToChar, valueIfDefault);

        public static char GetChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, char valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToChar, valueIfDefault);

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName, DateTime valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToDateTime, valueIfDefault);

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, DateTime valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToDateTime, valueIfDefault);

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, DateTime valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToDateTime, valueIfDefault);

        public static DateTime GetDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, DateTime valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToDateTime, valueIfDefault);

        public static decimal GetDecimal(this DbDataReader instance, string fieldName, decimal valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToDecimal, valueIfDefault);

        public static decimal GetDecimal(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, decimal valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToDecimal, valueIfDefault);

        public static decimal GetDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, decimal valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToDecimal, valueIfDefault);

        public static decimal GetDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, decimal valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToDecimal, valueIfDefault);

        public static double GetDouble(this DbDataReader instance, string fieldName, double valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToDouble, valueIfDefault);

        public static double GetDouble(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, double valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToDouble, valueIfDefault);

        public static double GetDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, double valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToDouble, valueIfDefault);

        public static double GetDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, double valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToDouble, valueIfDefault);

        public static Guid GetGuid(this DbDataReader instance, string fieldName, Guid valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToGuid, valueIfDefault);

        public static Guid GetGuid(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, Guid valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToGuid, valueIfDefault);

        public static short GetInt16(this DbDataReader instance, string fieldName, short valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToInt16, valueIfDefault);

        public static short GetInt16(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, short valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToInt16, valueIfDefault);

        public static short GetInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, short valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToInt16, valueIfDefault);

        public static short GetInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, short valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToInt16, valueIfDefault);

        public static int GetInt32(this DbDataReader instance, string fieldName, int valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToInt32, valueIfDefault);

        public static int GetInt32(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, int valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToInt32, valueIfDefault);

        public static int GetInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, int valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToInt32, valueIfDefault);

        public static int GetInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, int valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToInt32, valueIfDefault);

        public static long GetInt64(this DbDataReader instance, string fieldName, long valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToInt64, valueIfDefault);

        public static long GetInt64(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, long valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToInt64, valueIfDefault);

        public static long GetInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, long valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToInt64, valueIfDefault);

        public static long GetInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, long valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToInt64, valueIfDefault);

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName, bool? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableBoolean, valueIfDefault);

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, bool? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableBoolean, valueIfDefault);

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, bool? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableBoolean, valueIfDefault);

        public static bool? GetNullableBoolean(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, bool? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableBoolean, valueIfDefault);

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName, byte? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableByte, valueIfDefault);

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, byte? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableByte, valueIfDefault);

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, byte? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableByte, valueIfDefault);

        public static byte? GetNullableByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, byte? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableByte, valueIfDefault);

        public static char? GetNullableChar(this DbDataReader instance, string fieldName, char? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableChar, valueIfDefault);

        public static char? GetNullableChar(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, char? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableChar, valueIfDefault);

        public static char? GetNullableChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, char? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableChar, valueIfDefault);

        public static char? GetNullableChar(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, char? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableChar, valueIfDefault);

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName, DateTime? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableDateTime, valueIfDefault);

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, DateTime? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableDateTime, valueIfDefault);

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, DateTime? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableDateTime, valueIfDefault);

        public static DateTime? GetNullableDateTime(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, DateTime? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableDateTime, valueIfDefault);

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName, decimal? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableDecimal, valueIfDefault);

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, decimal? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableDecimal, valueIfDefault);

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, decimal? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableDecimal, valueIfDefault);

        public static decimal? GetNullableDecimal(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, decimal? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableDecimal, valueIfDefault);

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName, double? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableDouble, valueIfDefault);

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, double? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableDouble, valueIfDefault);

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, double? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableDouble, valueIfDefault);

        public static double? GetNullableDouble(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, double? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableDouble, valueIfDefault);

        public static Guid? GetNullableGuid(this DbDataReader instance, string fieldName, Guid? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableGuid, valueIfDefault);

        public static Guid? GetNullableGuid(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, Guid? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableGuid, valueIfDefault);

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName, short? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableInt16, valueIfDefault);

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, short? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableInt16, valueIfDefault);

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, short? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableInt16, valueIfDefault);

        public static short? GetNullableInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, short? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableInt16, valueIfDefault);

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName, int? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableInt32, valueIfDefault);

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, int? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableInt32, valueIfDefault);

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, int? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableInt32, valueIfDefault);

        public static int? GetNullableInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, int? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableInt32, valueIfDefault);

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName, long? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableInt64, valueIfDefault);

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, long? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableInt64, valueIfDefault);

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, long? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableInt64, valueIfDefault);

        public static long? GetNullableInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, long? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableInt64, valueIfDefault);

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName, sbyte? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableSByte, valueIfDefault);

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, sbyte? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableSByte, valueIfDefault);

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, sbyte? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableSByte, valueIfDefault);

        public static sbyte? GetNullableSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, sbyte? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableSByte, valueIfDefault);

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName, float? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableSingle, valueIfDefault);

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, float? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableSingle, valueIfDefault);

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, float? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableSingle, valueIfDefault);

        public static float? GetNullableSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, float? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableSingle, valueIfDefault);

        public static TimeSpan? GetNullableTimeSpan(this DbDataReader instance, string fieldName, TimeSpan? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableTimeSpan, valueIfDefault);

        public static TimeSpan? GetNullableTimeSpan(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, TimeSpan? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableTimeSpan, valueIfDefault);

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName, ushort? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableUInt16, valueIfDefault);

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, ushort? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableUInt16, valueIfDefault);

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ushort? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableUInt16, valueIfDefault);

        public static ushort? GetNullableUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, ushort? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableUInt16, valueIfDefault);

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName, uint? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableUInt32, valueIfDefault);

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, uint? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableUInt32, valueIfDefault);

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, uint? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableUInt32, valueIfDefault);

        public static uint? GetNullableUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, uint? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableUInt32, valueIfDefault);

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName, ulong? valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToNullableUInt64, valueIfDefault);

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, ulong? valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToNullableUInt64, valueIfDefault);

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ulong? valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToNullableUInt64, valueIfDefault);

        public static ulong? GetNullableUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, ulong? valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToNullableUInt64, valueIfDefault);

        public static sbyte GetSByte(this DbDataReader instance, string fieldName, sbyte valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToSByte, valueIfDefault);

        public static sbyte GetSByte(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, sbyte valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToSByte, valueIfDefault);

        public static sbyte GetSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, sbyte valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToSByte, valueIfDefault);

        public static sbyte GetSByte(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, sbyte valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToSByte, valueIfDefault);

        public static float GetSingle(this DbDataReader instance, string fieldName, float valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToSingle, valueIfDefault);

        public static float GetSingle(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, float valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToSingle, valueIfDefault);

        public static float GetSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, float valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToSingle, valueIfDefault);

        public static float GetSingle(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, float valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToSingle, valueIfDefault);

        public static Stream GetStream(this DbDataReader instance, string fieldName, Stream valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToStream, valueIfDefault);

        public static Stream GetStream(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, Stream valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToStream, valueIfDefault);

        public static string GetString(this DbDataReader instance, string fieldName, string valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToString, valueIfDefault);

        public static string GetString(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, string valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToString, valueIfDefault);

        public static string GetString(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, string valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToString, valueIfDefault);

        public static string GetString(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, string valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToString, valueIfDefault);

        public static TimeSpan GetTimeSpan(this DbDataReader instance, string fieldName, TimeSpan valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToTimeSpan, valueIfDefault);

        public static TimeSpan GetTimeSpan(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, TimeSpan valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToTimeSpan, valueIfDefault);

        public static ushort GetUInt16(this DbDataReader instance, string fieldName, ushort valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToUInt16, valueIfDefault);

        public static ushort GetUInt16(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, ushort valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToUInt16, valueIfDefault);

        public static ushort GetUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ushort valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToUInt16, valueIfDefault);

        public static ushort GetUInt16(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, ushort valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToUInt16, valueIfDefault);

        public static uint GetUInt32(this DbDataReader instance, string fieldName, uint valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToUInt32, valueIfDefault);

        public static uint GetUInt32(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, uint valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToUInt32, valueIfDefault);

        public static uint GetUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, uint valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToUInt32, valueIfDefault);

        public static uint GetUInt32(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, uint valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToUInt32, valueIfDefault);

        public static ulong GetUInt64(this DbDataReader instance, string fieldName, ulong valueIfDefault = default) => instance.Get(fieldName, DbValueConverter.ToUInt64, valueIfDefault);

        public static ulong GetUInt64(this DbDataReader instance, string fieldName, IFieldNameCache fieldNameCache, ulong valueIfDefault = default) => instance.Get(fieldName, fieldNameCache, DbValueConverter.ToUInt64, valueIfDefault);

        public static ulong GetUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, ulong valueIfDefault = default) => instance.Get(fieldName, formatProvider, DbValueConverter.ToUInt64, valueIfDefault);

        public static ulong GetUInt64(this DbDataReader instance, string fieldName, IFormatProvider formatProvider, IFieldNameCache fieldNameCache, ulong valueIfDefault = default) => instance.Get(fieldName, formatProvider, fieldNameCache, DbValueConverter.ToUInt64, valueIfDefault);
    }
}
