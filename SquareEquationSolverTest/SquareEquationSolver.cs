using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SquareEquationSolverTest
{
    /// <summary>
    /// ax^2 + bx + c = 0
    /// </summary>
    public class SquareEquationSolver
    {
        private double a;
        private double b;
        private double c;

        public SquareEquationSolver(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Determinate()
        {
            if (a == 0)
            {
                throw new InvalidOperationException("a cannot be zero");
            }

            double d = b * b - 4 * a * c;

            return d;
        }

        public Roots Calculate()
        {
            double D = Determinate();

            if (D >= 0)
            {
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);

                double x2 = (-b - Math.Sqrt(D)) / (2 * a);


                return new Roots(new ComplexNum(x1), new ComplexNum(x2));
            }
            else
            {
                double absD = Math.Abs(D);

                double r1 = -b / (2 * a);
                double i1 = Math.Sqrt(absD) / (2 * a);

                double r2 = -b / (2 * a);
                double i2 = -Math.Sqrt(absD) / (2 * a);

                return new Roots(new ComplexNum(r1, i1), new ComplexNum(r2, i2));
            }
        }
    }
}