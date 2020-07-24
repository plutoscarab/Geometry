// DoubleExtensions.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public static class DoubleExtensions
    {
        public static (BigInteger, BigInteger) ToFraction(this double d)
        {
            if (double.IsNaN(d) || double.IsInfinity(d))
                throw new ArgumentException(nameof(d));
                
            if (d == 0)
                return (BigInteger.Zero, BigInteger.One);

            var bits = BitConverter.DoubleToInt64Bits(d);
            var exp = (int)(bits >> 52) & 0x7FF;
            var numerator = bits & 0xFFFFFFFFFFFFF;

            if (exp == 0)
            {
                exp -= 1022;
            }
            else
            {
                numerator |= 0x10000000000000;
                exp -= 1023;
            }

            if (bits < 0)
            {
                numerator = -numerator;
            }

            exp -= 52;
            BigInteger p, q;

            if (exp >= 0)
            {
                p = numerator * BigInteger.Pow(2, exp);
                q = BigInteger.One;
            }
            else
            {
                p = numerator;
                q = BigInteger.Pow(2, -exp);
            }

            return (p, q);
        }
    }
}