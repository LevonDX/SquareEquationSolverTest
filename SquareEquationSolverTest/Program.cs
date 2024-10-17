namespace SquareEquationSolverTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = -5;
            int c = 6;

            SquareEquationSolver solver = new SquareEquationSolver(a, b, c);

            Roots roots = solver.Calculate();

            double x1 = (double)roots.X1;
            double x2 = (double)roots.X2;

            Console.WriteLine($"x1 = {x1}, x2 = {x2}");
        }
    }
}