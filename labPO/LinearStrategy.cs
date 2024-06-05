using System;

namespace LABPO
{
    public class LinearDef : IStr
    {
        public Complex[] FindSqrt(double[] coefficients)
        {
            if (coefficients.Length != 2)
            {
                throw new InvalidOperationException("Unsupported size of array!");
            }

            double a = coefficients[0];
            double b = coefficients[1];

            if (a == 0)
            {
                if (b == 0)
                {
                    throw new InvalidOperationException("Infinite amount of roots");
                }
            }

            return new Complex[] { new Complex(-b / a, 0) };
        }
    }
}