using System;
using System.IO;

namespace Sorschia
{
    public static class ValueConverter
    {
        private static bool IsDefault<T>(T value)
        {
            return Equals(default(T), value);
        }

        private static TResult ConvertBase<TInput, TResult>(TInput value, Func<TInput, TResult> convert, TResult valueIfDefault = default)
        {
            if (convert != null)
            {
                return IsDefault(value) ? valueIfDefault : convert(value);
            }
            else
            {
                throw new SorschiaException($"Parameter '{nameof(convert)}' cannot be null.");
            }
        }

        private static TResult ConvertBase<TInput, TResult>(TInput value, IFormatProvider formatProvider, Func<TInput, IFormatProvider, TResult> convert, TResult valueIfDefault = default)
        {
            if (convert != null)
            {
                return IsDefault(value) ? valueIfDefault : convert(value, formatProvider);
            }
            else
            {
                throw new SorschiaException($"Parameter '{nameof(convert)}' cannot be null.");
            }
        }

        private static TResult? ConvertNullableBase<TInput, TResult>(TInput value, Func<TInput, TResult> convert, TResult? valueIfDefault = default)
            where TInput : class
            where TResult : struct
        {
            if (convert != null)
            {
                return IsDefault(value) ? valueIfDefault : new TResult?(convert(value));
            }
            else
            {
                throw new SorschiaException($"Parameter '{nameof(convert)}' cannot be null.");
            }
        }

        private static TResult? ConvertNullableBase<TInput, TResult>(TInput value, IFormatProvider formatProvider, Func<TInput, IFormatProvider, TResult> convert, TResult? valueIfDefault = default)
            where TInput : class
            where TResult : struct
        {
            if (convert != null)
            {
                return IsDefault(value) ? valueIfDefault : new TResult?(convert(value, formatProvider));
            }
            else
            {
                throw new SorschiaException($"Parameter '{nameof(convert)}' cannot be null.");
            }
        }

        public static bool ToBoolean(byte value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(decimal value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(double value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(short value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(int value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(long value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(object value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(object value, IFormatProvider formatProvider, bool valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(sbyte value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(float value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(string value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(string value, IFormatProvider formatProvider, bool valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(ushort value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(uint value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool ToBoolean(ulong value, bool valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static byte ToByte(bool value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(char value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(decimal value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(double value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(short value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(int value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(long value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(object value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(object value, IFormatProvider formatProvider, byte valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(sbyte value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(float value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(string value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(string value, IFormatProvider formatProvider, byte valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(ushort value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(uint value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte ToByte(ulong value, byte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte[] ToByteArray(object value, byte[] valueIfDefault = default)
        {
            if (value is byte[] bytes)
            {
                return bytes;
            }
            else
            {
                return valueIfDefault;
            }
        }

        public static char ToChar(byte value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(short value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(int value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(long value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(object value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(object value, IFormatProvider formatProvider, char valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(sbyte value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(string value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(string value, IFormatProvider formatProvider, char valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(ushort value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(uint value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char ToChar(ulong value, char valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToChar, valueIfDefault);
        }

        public static DateTime ToDateTime(object value, DateTime valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDateTime, valueIfDefault);
        }

        public static DateTime ToDateTime(object value, IFormatProvider formatProvider, DateTime valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToDateTime, valueIfDefault);
        }

        public static DateTime ToDateTime(string value, DateTime valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDateTime, valueIfDefault);
        }

        public static DateTime ToDateTime(string value, IFormatProvider formatProvider, DateTime valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToDateTime, valueIfDefault);
        }

        public static decimal ToDecimal(bool value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(byte value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(double value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(short value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(int value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(long value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(object value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(object value, IFormatProvider formatProvider, decimal valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(sbyte value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(float value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(string value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(string value, IFormatProvider formatProvider, decimal valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(ushort value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(uint value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal ToDecimal(ulong value, decimal valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static double ToDouble(bool value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(byte value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(decimal value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(short value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(int value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(long value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(object value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(object value, IFormatProvider formatProvider, double valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(sbyte value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(float value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(string value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(string value, IFormatProvider formatProvider, double valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(ushort value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(uint value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double ToDouble(ulong value, double valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static Guid ToGuid(object value, Guid valueIfDefault = default)
        {
            if (Guid.TryParse(ToString(value), out Guid result))
            {
                return result;
            }
            else
            {
                return valueIfDefault;
            }
        }

        public static short ToInt16(bool value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(byte value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(char value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(decimal value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(double value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(int value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(long value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(object value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(object value, IFormatProvider formatProvider, short valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(sbyte value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(float value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(string value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(string value, IFormatProvider formatProvider, short valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(ushort value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(uint value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short ToInt16(ulong value, short valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static int ToInt32(bool value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(byte value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(char value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(decimal value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(double value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(short value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(long value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(object value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(object value, IFormatProvider formatProvider, int valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(sbyte value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(float value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(string value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(string value, IFormatProvider formatProvider, int valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(ushort value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(uint value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int ToInt32(ulong value, int valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static long ToInt64(bool value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(byte value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(char value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(decimal value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(double value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(short value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(int value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(object value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(object value, IFormatProvider formatProvider, long valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(sbyte value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(float value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(string value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(string value, IFormatProvider formatProvider, long valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(ushort value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(uint value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long ToInt64(ulong value, long valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static bool? ToNullableBoolean(object value, bool? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool? ToNullableBoolean(object value, IFormatProvider formatProvider, bool? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToBoolean, valueIfDefault);
        }

        public static bool? ToNullableBoolean(string value, bool? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToBoolean, valueIfDefault);
        }

        public static bool? ToNullableBoolean(string value, IFormatProvider formatProvider, bool? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToBoolean, valueIfDefault);
        }

        public static byte? ToNullableByte(object value, byte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte? ToNullableByte(object value, IFormatProvider formatProvider, byte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToByte, valueIfDefault);
        }

        public static byte? ToNullableByte(string value, byte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToByte, valueIfDefault);
        }

        public static byte? ToNullableByte(string value, IFormatProvider formatProvider, byte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToByte, valueIfDefault);
        }

        public static char? ToNullableChar(object value, char? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char? ToNullableChar(object value, IFormatProvider formatProvider, char? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToChar, valueIfDefault);
        }

        public static char? ToNullableChar(string value, char? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToChar, valueIfDefault);
        }

        public static char? ToNullableChar(string value, IFormatProvider formatProvider, char? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToChar, valueIfDefault);
        }

        public static DateTime? ToNullableDateTime(object value, DateTime? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToDateTime, valueIfDefault);
        }

        public static DateTime? ToNullableDateTime(object value, IFormatProvider formatProvider, DateTime? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToDateTime, valueIfDefault);
        }

        public static DateTime? ToNullableDateTime(string value, DateTime? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToDateTime, valueIfDefault);
        }

        public static DateTime? ToNullableDateTime(string value, IFormatProvider formatProvider, DateTime? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToDateTime, valueIfDefault);
        }

        public static decimal? ToNullableDecimal(object value, decimal? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal? ToNullableDecimal(object value, IFormatProvider formatProvider, decimal? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal? ToNullableDecimal(string value, decimal? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToDecimal, valueIfDefault);
        }

        public static decimal? ToNullableDecimal(string value, IFormatProvider formatProvider, decimal? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToDecimal, valueIfDefault);
        }

        public static double? ToNullableDouble(object value, double? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double? ToNullableDouble(object value, IFormatProvider formatProvider, double? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToDouble, valueIfDefault);
        }

        public static double? ToNullableDouble(string value, double? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToDouble, valueIfDefault);
        }

        public static double? ToNullableDouble(string value, IFormatProvider formatProvider, double? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToDouble, valueIfDefault);
        }

        public static Guid? ToNullableGuid(object value, Guid? valueIfDefault = default)
        {
            if (Guid.TryParse(ToString(value), out Guid result))
            {
                return result;
            }
            else
            {
                return valueIfDefault;
            }
        }

        public static short? ToNullableInt16(object value, short? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short? ToNullableInt16(object value, IFormatProvider formatProvider, short? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToInt16, valueIfDefault);
        }

        public static short? ToNullableInt16(string value, short? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToInt16, valueIfDefault);
        }

        public static short? ToNullableInt16(string value, IFormatProvider formatProvider, short? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToInt16, valueIfDefault);
        }

        public static int? ToNullableInt32(object value, int? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int? ToNullableInt32(object value, IFormatProvider formatProvider, int? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToInt32, valueIfDefault);
        }

        public static int? ToNullableInt32(string value, int? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToInt32, valueIfDefault);
        }

        public static int? ToNullableInt32(string value, IFormatProvider formatProvider, int? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToInt32, valueIfDefault);
        }

        public static long? ToNullableInt64(object value, long? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long? ToNullableInt64(object value, IFormatProvider formatProvider, long? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToInt64, valueIfDefault);
        }

        public static long? ToNullableInt64(string value, long? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToInt64, valueIfDefault);
        }

        public static long? ToNullableInt64(string value, IFormatProvider formatProvider, long? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToInt64, valueIfDefault);
        }

        public static sbyte? ToNullableSByte(object value, sbyte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte? ToNullableSByte(object value, IFormatProvider formatProvider, sbyte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte? ToNullableSByte(string value, sbyte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte? ToNullableSByte(string value, IFormatProvider formatProvider, sbyte? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToSByte, valueIfDefault);
        }

        public static float? ToNullableSingle(object value, float? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float? ToNullableSingle(object value, IFormatProvider formatProvider, float? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToSingle, valueIfDefault);
        }

        public static float? ToNullableSingle(string value, float? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float? ToNullableSingle(string value, IFormatProvider formatProvider, float? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToSingle, valueIfDefault);
        }

        public static TimeSpan? ToNullableTimeSpan(object value, TimeSpan? valueIfDefault = default)
        {
            var converted = ToNullableInt64(value);
            return converted == null ? valueIfDefault : new TimeSpan?(ToTimeSpan(converted));
        }

        public static TimeSpan? ToNullableTimeSpan(object value, IFormatProvider formatProvider, TimeSpan? valueIfDefault = default)
        {
            var converted = ToNullableUInt64(value, formatProvider);
            return converted == null ? valueIfDefault : new TimeSpan?(ToTimeSpan(converted));
        }

        public static ushort? ToNullableUInt16(object value, ushort? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort? ToNullableUInt16(object value, IFormatProvider formatProvider, ushort? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort? ToNullableUInt16(string value, ushort? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort? ToNullableUInt16(string value, IFormatProvider formatProvider, ushort? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToUInt16, valueIfDefault);
        }

        public static uint? ToNullableUInt32(object value, uint? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint? ToNullableUInt32(object value, IFormatProvider formatProvider, uint? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToUInt32, valueIfDefault);
        }

        public static uint? ToNullableUInt32(string value, uint? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint? ToNullableUInt32(string value, IFormatProvider formatProvider, uint? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToUInt32, valueIfDefault);
        }

        public static ulong? ToNullableUInt64(object value, ulong? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong? ToNullableUInt64(object value, IFormatProvider formatProvider, ulong? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong? ToNullableUInt64(string value, ulong? valueIfDefault = default)
        {
            return ConvertNullableBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong? ToNullableUInt64(string value, IFormatProvider formatProvider, ulong? valueIfDefault = default)
        {
            return ConvertNullableBase(value, formatProvider, Convert.ToUInt64, valueIfDefault);
        }

        public static sbyte ToSByte(bool value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(byte value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(char value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(decimal value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(double value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(short value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(int value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(long value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(object value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(object value, IFormatProvider formatProvider, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(float value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(string value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(string value, IFormatProvider formatProvider, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(ushort value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(uint value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static sbyte ToSByte(ulong value, sbyte valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSByte, valueIfDefault);
        }

        public static float ToSingle(bool value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(byte value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(decimal value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(double value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(short value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(int value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(long value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(object value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(object value, IFormatProvider formatProvider, float valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(sbyte value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(string value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(string value, IFormatProvider formatProvider, float valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(ushort value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(uint value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static float ToSingle(ulong value, float valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToSingle, valueIfDefault);
        }

        public static Stream ToStream(object value, Stream valueIfDefault = default)
        {
            return value == null ? valueIfDefault : ConvertBase(value, val => new MemoryStream(ToByteArray(val)));
        }

        public static string ToString(bool value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(bool value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(byte value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(byte value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(char value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(char value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(DateTime value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(DateTime value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(decimal value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(decimal value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(double value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(double value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(short value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(short value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(int value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(int value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(long value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(long value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(object value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(object value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(sbyte value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(sbyte value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(float value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(float value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(ushort value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(ushort value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(uint value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(uint value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static string ToString(ulong value, string valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToString, valueIfDefault);
        }

        public static string ToString(ulong value, IFormatProvider formatProvider, string valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToString, valueIfDefault);
        }

        public static TimeSpan ToTimeSpan(object value, TimeSpan valueIfDefault = default)
        {
            var converted = ToInt64(value);
            return Equals(converted, default) ? valueIfDefault : new TimeSpan(converted);
        }

        public static TimeSpan ToTimeSpan(object value, IFormatProvider formatProvider, TimeSpan valueIfDefault = default)
        {
            var converted = ToInt64(value, formatProvider);
            return Equals(converted, default) ? valueIfDefault : new TimeSpan(converted);
        }

        public static ushort ToUInt16(bool value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(byte value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(char value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(decimal value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(double value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(short value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(int value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(long value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(object value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(object value, IFormatProvider formatProvider, ushort valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(sbyte value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(float value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(string value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(string value, IFormatProvider formatProvider, ushort valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(uint value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static ushort ToUInt16(ulong value, ushort valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt16, valueIfDefault);
        }

        public static uint ToUInt32(bool value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(byte value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(char value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(decimal value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(double value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(short value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(int value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(long value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(object value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(object value, IFormatProvider formatProvider, uint valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(sbyte value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(float value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(string value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(string value, IFormatProvider formatProvider, uint valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(ushort value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static uint ToUInt32(ulong value, uint valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt32, valueIfDefault);
        }

        public static ulong ToUInt64(bool value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(byte value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(char value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(decimal value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(double value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(short value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(int value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(long value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(object value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(object value, IFormatProvider formatProvider, ulong valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(sbyte value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(float value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(string value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(string value, IFormatProvider formatProvider, ulong valueIfDefault = default)
        {
            return ConvertBase(value, formatProvider, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(ushort value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }

        public static ulong ToUInt64(uint value, ulong valueIfDefault = default)
        {
            return ConvertBase(value, Convert.ToUInt64, valueIfDefault);
        }
    }
}
