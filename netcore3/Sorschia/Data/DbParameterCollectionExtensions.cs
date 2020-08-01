using Sorschia.Utilities;
using System;
using System.Data.Common;
using System.IO;

namespace Sorschia.Data
{
    public static class DbParameterCollectionExtensions
    {
        private static void Validate(DbParameterCollection parameters, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new SorschiaDataException("parameter name is set to null or white space.");

            if (parameters.Count <= 0)
                throw new SorschiaDataException("parameters is empty.");
        }

        private static T Get<T>(this DbParameterCollection instance, string name, Convert<T> convert, T valueIfDefault = default)
        {
            Validate(instance, name);
            return convert(instance[name]?.Value, valueIfDefault);
        }

        private static T Get<T>(this DbParameterCollection instance, string name, IFormatProvider formatProvider, ConvertWithFormatProvider<T> convert, T valueIfDefault = default)
        {
            Validate(instance, name);
            return convert(instance[name]?.Value, formatProvider, valueIfDefault);
        }

        public static bool GetBoolean(this DbParameterCollection instance, string name, bool valueIfDefault = default) => instance.Get(name, DbValueConverter.ToBoolean, valueIfDefault);

        public static bool GetBoolean(this DbParameterCollection instance, string name, IFormatProvider formatProvider, bool valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToBoolean, valueIfDefault);

        public static byte GetByte(this DbParameterCollection instance, string name, byte valueIfDefault = default) => instance.Get(name, DbValueConverter.ToByte, valueIfDefault);

        public static byte GetByte(this DbParameterCollection instance, string name, IFormatProvider formatProvider, byte valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToByte, valueIfDefault);

        public static byte[] GetByteArray(this DbParameterCollection instance, string name, byte[] valueIfDefault = default) => instance.Get(name, DbValueConverter.ToByteArray, valueIfDefault);

        public static char GetChar(this DbParameterCollection instance, string name, char valueIfDefault = default) => instance.Get(name, DbValueConverter.ToChar, valueIfDefault);

        public static char GetChar(this DbParameterCollection instance, string name, IFormatProvider formatProvider, char valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToChar, valueIfDefault);

        public static DateTime GetDateTime(this DbParameterCollection instance, string name, DateTime valueIfDefault = default) => instance.Get(name, DbValueConverter.ToDateTime, valueIfDefault);

        public static DateTime GetDateTime(this DbParameterCollection instance, string name, IFormatProvider formatProvider, DateTime valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToDateTime, valueIfDefault);

        public static decimal GetDecimal(this DbParameterCollection instance, string name, decimal valueIfDefault = default) => instance.Get(name, DbValueConverter.ToDecimal, valueIfDefault);

        public static decimal GetDecimal(this DbParameterCollection instance, string name, IFormatProvider formatProvider, decimal valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToDecimal, valueIfDefault);

        public static double GetDouble(this DbParameterCollection instance, string name, double valueIfDefault = default) => instance.Get(name, DbValueConverter.ToDouble, valueIfDefault);

        public static double GetDouble(this DbParameterCollection instance, string name, IFormatProvider formatProvider, double valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToDouble, valueIfDefault);

        public static Guid GetGuid(this DbParameterCollection instance, string name, Guid valueIfDefault = default) => instance.Get(name, DbValueConverter.ToGuid, valueIfDefault);

        public static short GetInt16(this DbParameterCollection instance, string name, short valueIfDefault = default) => instance.Get(name, DbValueConverter.ToInt16, valueIfDefault);

        public static short GetInt16(this DbParameterCollection instance, string name, IFormatProvider formatProvider, short valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToInt16, valueIfDefault);

        public static int GetInt32(this DbParameterCollection instance, string name, int valueIfDefault = default) => instance.Get(name, DbValueConverter.ToInt32, valueIfDefault);

        public static int GetInt32(this DbParameterCollection instance, string name, IFormatProvider formatProvider, int valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToInt32, valueIfDefault);

        public static long GetInt64(this DbParameterCollection instance, string name, long valueIfDefault = default) => instance.Get(name, DbValueConverter.ToInt64, valueIfDefault);

        public static long GetInt64(this DbParameterCollection instance, string name, IFormatProvider formatProvider, long valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToInt64, valueIfDefault);

        public static bool? GetNullableBoolean(this DbParameterCollection instance, string name, bool? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableBoolean, valueIfDefault);

        public static bool? GetNullableBoolean(this DbParameterCollection instance, string name, IFormatProvider formatProvider, bool? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableBoolean, valueIfDefault);

        public static byte? GetNullableByte(this DbParameterCollection instance, string name, byte? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableByte, valueIfDefault);

        public static byte? GetNullableByte(this DbParameterCollection instance, string name, IFormatProvider formatProvider, byte? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableByte, valueIfDefault);

        public static char? GetNullableChar(this DbParameterCollection instance, string name, char? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableChar, valueIfDefault);

        public static char? GetNullableChar(this DbParameterCollection instance, string name, IFormatProvider formatProvider, char? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableChar, valueIfDefault);

        public static DateTime? GetNullableDateTime(this DbParameterCollection instance, string name, DateTime? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableDateTime, valueIfDefault);

        public static DateTime? GetNullableDateTime(this DbParameterCollection instance, string name, IFormatProvider formatProvider, DateTime? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableDateTime, valueIfDefault);

        public static decimal? GetNullableDecimal(this DbParameterCollection instance, string name, decimal? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableDecimal, valueIfDefault);

        public static decimal? GetNullableDecimal(this DbParameterCollection instance, string name, IFormatProvider formatProvider, decimal? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableDecimal, valueIfDefault);

        public static double? GetNullableDouble(this DbParameterCollection instance, string name, double? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableDouble, valueIfDefault);

        public static double? GetNullableDouble(this DbParameterCollection instance, string name, IFormatProvider formatProvider, double? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableDouble, valueIfDefault);

        public static Guid? GetNullableGuid(this DbParameterCollection instance, string name, Guid? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableGuid, valueIfDefault);

        public static short? GetNullableInt16(this DbParameterCollection instance, string name, short? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableInt16, valueIfDefault);

        public static short? GetNullableInt16(this DbParameterCollection instance, string name, IFormatProvider formatProvider, short? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableInt16, valueIfDefault);

        public static int? GetNullableInt32(this DbParameterCollection instance, string name, int? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableInt32, valueIfDefault);

        public static int? GetNullableInt32(this DbParameterCollection instance, string name, IFormatProvider formatProvider, int? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableInt32, valueIfDefault);

        public static long? GetNullableInt64(this DbParameterCollection instance, string name, long? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableInt64, valueIfDefault);

        public static long? GetNullableInt64(this DbParameterCollection instance, string name, IFormatProvider formatProvider, long? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableInt64, valueIfDefault);

        public static sbyte? GetNullableSByte(this DbParameterCollection instance, string name, sbyte? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableSByte, valueIfDefault);

        public static sbyte? GetNullableSByte(this DbParameterCollection instance, string name, IFormatProvider formatProvider, sbyte? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableSByte, valueIfDefault);

        public static float? GetNullableSingle(this DbParameterCollection instance, string name, float? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableSingle, valueIfDefault);

        public static float? GetNullableSingle(this DbParameterCollection instance, string name, IFormatProvider formatProvider, float? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableSingle, valueIfDefault);

        public static TimeSpan? GetNullableTimeSpan(this DbParameterCollection instance, string name, TimeSpan? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableTimeSpan, valueIfDefault);

        public static ushort? GetNullableUInt16(this DbParameterCollection instance, string name, ushort? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableUInt16, valueIfDefault);

        public static ushort? GetNullableUInt16(this DbParameterCollection instance, string name, IFormatProvider formatProvider, ushort? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableUInt16, valueIfDefault);

        public static uint? GetNullableUInt32(this DbParameterCollection instance, string name, uint? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableUInt32, valueIfDefault);

        public static uint? GetNullableUInt32(this DbParameterCollection instance, string name, IFormatProvider formatProvider, uint? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableUInt32, valueIfDefault);

        public static ulong? GetNullableUInt64(this DbParameterCollection instance, string name, ulong? valueIfDefault = default) => instance.Get(name, DbValueConverter.ToNullableUInt64, valueIfDefault);

        public static ulong? GetNullableUInt64(this DbParameterCollection instance, string name, IFormatProvider formatProvider, ulong? valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToNullableUInt64, valueIfDefault);

        public static sbyte GetSByte(this DbParameterCollection instance, string name, sbyte valueIfDefault = default) => instance.Get(name, DbValueConverter.ToSByte, valueIfDefault);

        public static sbyte GetSByte(this DbParameterCollection instance, string name, IFormatProvider formatProvider, sbyte valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToSByte, valueIfDefault);

        public static float GetSingle(this DbParameterCollection instance, string name, float valueIfDefault = default) => instance.Get(name, DbValueConverter.ToSingle, valueIfDefault);

        public static float GetSingle(this DbParameterCollection instance, string name, IFormatProvider formatProvider, float valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToSingle, valueIfDefault);

        public static Stream GetStream(this DbParameterCollection instance, string name, Stream valueIfDefault = default) => instance.Get(name, DbValueConverter.ToStream, valueIfDefault);

        public static string GetString(this DbParameterCollection instance, string name, string valueIfDefault = default) => instance.Get(name, DbValueConverter.ToString, valueIfDefault);

        public static string GetString(this DbParameterCollection instance, string name, IFormatProvider formatProvider, string valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToString, valueIfDefault);

        public static TimeSpan GetTimeSpan(this DbParameterCollection instance, string name, TimeSpan valueIfDefault = default) => instance.Get(name, DbValueConverter.ToTimeSpan, valueIfDefault);

        public static ushort GetUInt16(this DbParameterCollection instance, string name, ushort valueIfDefault = default) => instance.Get(name, DbValueConverter.ToUInt16, valueIfDefault);

        public static ushort GetUInt16(this DbParameterCollection instance, string name, IFormatProvider formatProvider, ushort valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToUInt16, valueIfDefault);

        public static uint GetUInt32(this DbParameterCollection instance, string name, uint valueIfDefault = default) => instance.Get(name, DbValueConverter.ToUInt32, valueIfDefault);

        public static uint GetUInt32(this DbParameterCollection instance, string name, IFormatProvider formatProvider, uint valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToUInt32, valueIfDefault);

        public static ulong GetUInt64(this DbParameterCollection instance, string name, ulong valueIfDefault = default) => instance.Get(name, DbValueConverter.ToUInt64, valueIfDefault);

        public static ulong GetUInt64(this DbParameterCollection instance, string name, IFormatProvider formatProvider, ulong valueIfDefault = default) => instance.Get(name, formatProvider, DbValueConverter.ToUInt64, valueIfDefault);
    }
}
