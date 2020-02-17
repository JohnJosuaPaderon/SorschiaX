using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Sorschia.Security
{
    public static class SecureStringConverter
    {
        public static string Convert(SecureString secureValue)
        {
            if (secureValue != null)
            {
                IntPtr unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = SecureStringMarshal.SecureStringToGlobalAllocUnicode(secureValue);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
            else
            {
                return default;
            }
        }

        public static SecureString Convert(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                unsafe
                {
                    fixed (char* passwordChars = value)
                    {
                        var secureValue = new SecureString(passwordChars, value.Length);
                        secureValue.MakeReadOnly();
                        return secureValue;
                    }
                }
            }
            else
            {
                return default;
            }
        }
    }
}
