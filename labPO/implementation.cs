using System;
using System.Linq;

namespace LABPO
{
    internal class Implement : Interface
    {
        private double[] coefficients;
        private IStr solver;

        public int Size
        {
            get
            {
                return coefficients.Length;
            }
        }

        public double[] Coefficients
        {
            get
            {
                return (double[])coefficients.Clone();
            }
        }

        public Implement(double[] coefficients)
        {
            this.coefficients = Remover(coefficients);
            this.solver = Selector(this.coefficients);
        }

        public Complex[] FindSqrt()
        {
            if (solver == null)
            {
                throw new InvalidOperationException("Solver wasn't installed!");
            }

            return solver.FindSqrt(coefficients);
        }

        private double[] Remover(double[] coefficients)
        {
            if (coefficients.Length == 0 || coefficients == null)
            {
                throw new ArgumentException("Array is empty!");
            }

            int lastInd = Array.FindLastIndex(coefficients, x => x != 0);
            return coefficients.Take(lastInd + 1).ToArray();
        }

        private IStr Selector(double[] coefficients)
        {
            if (coefficients.Length == 0)
            {
                throw new ArgumentException("Array is empty!");
            }

            if (coefficients.Length == 1)
            {
                return new LinearDef();
            }

            if (coefficients.Length == 2)
            {
                return new LinearDef();
            }

            if (coefficients.Length == 3)
            {
                return new QuadraticDef();
            }

            throw new InvalidOperationException("Unsupported size of array!");
        }
    }
}