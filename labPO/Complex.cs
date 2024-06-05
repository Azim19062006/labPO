using System;

namespace LABPO
{
    public class Complex
    {
        public double X { get; }
        public double Y { get; }

        public Complex(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Complex Re(double x)
        {
            return new Complex(x, 0);
        }

        public static Complex Im(double y)
        {
            return new Complex(0, y);
        }

        public static Complex Sqrt(double n)
        {
            if (n < 0)
            {
                return new Complex(0, Math.Sqrt(-n));
            }

            else
            {
                return new Complex(Math.Sqrt(n), 0);
            }
        }

        public static Complex Zero = new Complex(0, 0);
        public static Complex One = new Complex(1, 0);
        public static Complex Imaginary = new Complex(0, 1);

        public double Length(Complex comp1, Complex comp2)
        {
            return Math.Sqrt(Math.Pow(comp1.X - comp2.X, 2) + Math.Pow(comp1.Y - comp2.Y, 2));
        }

        public static Complex operator +(Complex first, Complex second)
        {
            return new Complex(first.X + second.X, first.Y + second.Y);
        }

        public static Complex operator -(Complex first, Complex second)
        {
            return new Complex(first.X - second.X, first.Y - second.Y);
        }

        public static Complex operator *(Complex first, Complex second)
        {
            double firstpart = first.X * second.X - first.Y * second.Y;
            double secondpart = first.Y * second.X + first.X * second.Y;
            return new Complex(firstpart, secondpart);
        }

        public static Complex operator /(Complex first, Complex second)
        {
            if (second.X == 0 && second.Y == 0)
            {
                throw new DivideByZeroException("Division by zero!!!");
            }

            double divisor = Math.Pow(second.X, 2) + Math.Pow(second.Y, 2);
            double firstpart = (first.X * second.X + first.Y * second.Y) / divisor;
            double secondpart = (first.Y * second.X - first.X * second.Y) / divisor;
            return new Complex(firstpart, secondpart);
        }

        public override string ToString()
        {
            return $"{X} + {Y}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Complex)
            {
                return false;
            }

            Complex comp = (Complex)obj;
            return X == comp.X && Y == comp.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
    }
}