using SquareEquationSolverTest;

namespace TestProject
{
    public class TestsSquareEquationSolver
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDeterminate()
        {
            // x^2 - 5x + 6 = 0


            // 1. Arrange

            int a = 1;
            int b = -5;
            int c = 6;

            SquareEquationSolver solver_OK = new SquareEquationSolver(a, b, c);
            SquareEquationSolver solver_zero_A = new SquareEquationSolver(0, b, c);


            // 2. Act
            double D = solver_OK.Determinate();

            // 3. Assert
            Assert.That(D, Is.EqualTo(1));
            Assert.Throws<InvalidOperationException>(() => solver_zero_A.Determinate());
        }

        [Test]
        public void TestSolve()
        {
            //1. Arrange

            // 1.1 arrange D > 0 case
            int a = 1;
            int b = -5;
            int c = 6;

            // 1.2 arrange D < 0 case
            int a1 = 1;
            int b1 = -2;
            int c1 = 5;

            SquareEquationSolver solver_OK = new SquareEquationSolver(a, b, c);
            SquareEquationSolver solver_D_Less_0 = new SquareEquationSolver(a1, b1, c1);

            //2. Act
            Roots roots_OK = solver_OK.Calculate();
            Roots roots_Complex = solver_D_Less_0.Calculate();

            //3. Assert
            Assert.That(roots_OK.X1, Is.EqualTo(new ComplexNum(3)));
            Assert.That(roots_OK.X2, Is.EqualTo(new ComplexNum(2)));

            Assert.That(roots_Complex.X1, Is.EqualTo(new ComplexNum(1, 2)));
            Assert.That(roots_Complex.X2, Is.EqualTo(new ComplexNum(1, -2)));
        }
    }
}