using System;

namespace BE.Service.Exceptions
{
    internal static class Extensions
    {
        internal static void ThrowIfEmpty(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        internal static void ThrowIfHasSpaces(this string value)
        {
            if (value.Contains(' '))
            {
                throw new ArgumentException(nameof(value));
            }
        }

        internal static void ThrowIfGreaterThan(this string value, int predicateValue)
        {
            if (value.Length > predicateValue)
            {
                throw new ArgumentException(nameof(value));
            }
        }

        internal static void ThrowIfLessThan(this string value, int predicateValue)
        {
            if (value.Length < predicateValue)
            {
                throw new ArgumentException(nameof(value));
            }
        }

        internal static void ThrowIfNotEqualTo(this string value, int predicateValue)
        {
            if (value.Length != predicateValue)
            {
                throw new ArgumentException(nameof(value));
            }
        }

        internal static void ThrowIfZero(this int value)
        {
            if (value == 0)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        internal static void ThrowIfGreaterThan(this int value, int predicateValue)
        {
            if (value > predicateValue)
            {
                throw new ArgumentException(nameof(value));
            }
        }

        internal static void ThrowIfLessThan(this int value, int predicateValue)
        {
            if (value < predicateValue)
            {
                throw new ArgumentException(nameof(value));
            }
        }

        internal static void ThrowIfNull(this DateTime value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        internal static void ThrowIfNull(this object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
