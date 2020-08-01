using System;

namespace Sorschia.Utilities
{
    internal delegate TResult Convert<TInput, TResult>(TInput value);
    internal delegate TResult ConvertWithFormatProvider<TInput, TResult>(TInput value, IFormatProvider formatProvider);
    internal delegate T Convert<T>(object dbValue, T valueIfDefault);
    internal delegate T ConvertWithFormatProvider<T>(object dbValue, IFormatProvider formatProvider, T valueIfDefault);
}
