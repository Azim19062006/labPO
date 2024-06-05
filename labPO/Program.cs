using System;

namespace LABPO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the coefficients of the equation: ");
            double[] coefficients = Input();

            try
            {
                Interface equation = new Implement(coefficients);
                Complex[] roots = equation.FindSqrt();
                Console.WriteLine("Roots of the equation");
                foreach (var root in roots)
                {
                    Console.WriteLine(root);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        static double[] Input()
        {
            double[] coefficients;
            while (true)
            {
                Console.Write("Coefficients: ");
                string input = Console.ReadLine();
                string[] split = input.Split(' ');

                coefficients = new double[split.Length];
                bool valid = true;

                for (int i = 0; i < split.Length; i++)
                {
                    if (!double.TryParse(split[i], out coefficients[i]))
                    {
                        valid = false;
                        Console.WriteLine("Invalid input!");
                        break;
                    }
                }

                if (valid)
                {
                    break;
                }
            }
            return coefficients;
        }
    }
}
