using System;
using System.IO;

namespace Sorschia
{
    public static partial class IScopedVariablesExtensions
    {
        private static T GetValue<T>(this IScopedVariables instance, string key, Func<object, T, T> convert, T valueIfDefault = default)
        {
            if (instance.Exists(key))
            {
                return convert(instance[key], valueIfDefault);
            }

            return valueIfDefault;
        }

        public static object GetValue(this IScopedVariables instance, string key, object valueIfDefault = default)
        {
            if (instance.Exists(key))
            {
                return instance[key];
            }

            return valueIfDefault;
        }

        public static T GetValue<T>(this IScopedVariables instance, string key, T valueIfDefault = default)
        {
            if (instance.Exists(key) && instance[key] is T result)
            {
                return result;
            }

            return valueIfDefault;
        }

        public static bool GetBoolean(this IScopedVariables instance, string key, bool valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToBoolean, valueIfDefault);
        }

        public static byte GetByte(this IScopedVariables instance, string key, byte valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToByte, valueIfDefault);
        }

        public static byte[] GetByteArray(this IScopedVariables instance, string key, byte[] valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToByteArray, valueIfDefault);
        }

        public static char GetChar(this IScopedVariables instance, string key, char valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToChar, valueIfDefault);
        }

        public static DateTime GetDateTime(this IScopedVariables instance, string key, DateTime valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToDateTime, valueIfDefault);
        }

        public static decimal GetDecimal(this IScopedVariables instance, string key, decimal valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToDecimal, valueIfDefault);
        }

        public static double GetDouble(this IScopedVariables instance, string key, double valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToDouble, valueIfDefault);
        }

        public static Guid GetGuid(this IScopedVariables instance, string key, Guid valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToGuid, valueIfDefault);
        }

        public static short GetInt16(this IScopedVariables instance, string key, short valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToInt16, valueIfDefault);
        }

        public static int GetInt32(this IScopedVariables instance, string key, int valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToInt32, valueIfDefault);
        }

        public static long GetInt64(this IScopedVariables instance, string key, long valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToInt64, valueIfDefault);
        }

        public static bool? GetNullableBoolean(this IScopedVariables instance, string key, bool? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableBoolean, valueIfDefault);
        }

        public static byte? GetNullableByte(this IScopedVariables instance, string key, byte? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableByte, valueIfDefault);
        }

        public static char? GetNullableChar(this IScopedVariables instance, string key, char? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableChar, valueIfDefault);
        }

        public static DateTime? GetNullableDateTime(this IScopedVariables instance, string key, DateTime? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableDateTime, valueIfDefault);
        }

        public static decimal? GetNullableDecimal(this IScopedVariables instance, string key, decimal? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableDecimal, valueIfDefault);
        }

        public static double? GetNullableDouble(this IScopedVariables instance, string key, double? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableDouble, valueIfDefault);
        }

        public static Guid? GetNullableGuid(this IScopedVariables instance, string key, Guid? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableGuid, valueIfDefault);
        }

        public static short? GetNullableInt16(this IScopedVariables instance, string key, short? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableInt16, valueIfDefault);
        }

        public static int? GetNullableInt32(this IScopedVariables instance, string key, int? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableInt32, valueIfDefault);
        }

        public static long? GetNullableInt64(this IScopedVariables instance, string key, long? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableInt64, valueIfDefault);
        }

        public static sbyte? GetNullableSByte(this IScopedVariables instance, string key, sbyte? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableSByte, valueIfDefault);
        }

        public static float? GetNullableSingle(this IScopedVariables instance, string key, float? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableSingle, valueIfDefault);
        }

        public static TimeSpan? GetNullableTimespan(this IScopedVariables instance, string key, TimeSpan? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableTimeSpan, valueIfDefault);
        }

        public static ushort? GetNullableUInt16(this IScopedVariables instance, string key, ushort? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableUInt16, valueIfDefault);
        }

        public static uint? GetNullableUInt32(this IScopedVariables instance, string key, uint? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableUInt32, valueIfDefault);
        }

        public static ulong? GetNullableUInt64(this IScopedVariables instance, string key, ulong? valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToNullableUInt64, valueIfDefault);
        }

        public static sbyte GetSByte(this IScopedVariables instance, string key, sbyte valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToSByte, valueIfDefault);
        }

        public static float GetSingle(this IScopedVariables instance, string key, float valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToSingle, valueIfDefault);
        }

        public static Stream GetStream(this IScopedVariables instance, string key, Stream valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToStream, valueIfDefault);
        }

        public static string GetString(this IScopedVariables instance, string key, string valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToString, valueIfDefault);
        }

        public static TimeSpan GetTimeSpan(this IScopedVariables instance, string key, TimeSpan valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToTimeSpan, valueIfDefault);
        }

        public static ushort GetUInt16(this IScopedVariables instance, string key, ushort valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToUInt16, valueIfDefault);
        }

        public static uint GetUInt32(this IScopedVariables instance, string key, uint valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToUInt32, valueIfDefault);
        }

        public static ulong GetUInt64(this IScopedVariables instance, string key, ulong valueIfDefault = default)
        {
            return instance.GetValue(key, ValueConverter.ToUInt64, valueIfDefault);
        }
    }
}
