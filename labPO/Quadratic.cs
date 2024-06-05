using System;

namespace LABPO
{
    public class QuadraticDef : IStr
    {
        public Complex[] FindSqrt(double[] coefficients)
        {
            if (coefficients.Length != 3)
            {
                throw new InvalidOperationException("Unsupported size of array!");
            }

            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];

            if (a == 0)
            {
                throw new InvalidOperationException("Coefficient a cannot be 0 for a quadratic equation!");
            }

            double discriminant = b * b - 4 * a * c;
            Complex sqrtDiscriminant = Complex.Sqrt(discriminant);

            Complex minusB = new Complex(-b, 0);
            Complex denominator = new Complex(2 * a, 0);

            Complex root1 = (minusB + sqrtDiscriminant) / denominator;
            Complex root2 = (minusB - sqrtDiscriminant) / denominator;

            return new Complex[] { root1, root2 };
        }
    }
}