namespace SquareEquationSolverTest
{
    public class ComplexNum : IComparable<ComplexNum>
    {
        public double Real { get; set; }
        public double Imiginary { get; set; }

        public ComplexNum()
        {

        }

        public ComplexNum(double real, double imiginary = 0)
        {
            Real = real;
            Imiginary = imiginary;
        }

        public override string ToString()
        {
            if (Imiginary == 0)
                return Real.ToString();

            char sym = Imiginary > 0 ? '+' : '-';

            double modImiginary = Math.Abs(Imiginary);

            return $"{Real} {sym} i{modImiginary}";
        }

        public override bool Equals(object? obj)
        {
            ComplexNum? other = obj as ComplexNum;

            if (other == null) return false;

            return this.Real == other.Real &&
                this.Imiginary == other.Imiginary;
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imiginary.GetHashCode();
        }

        public int CompareTo(ComplexNum? other)
        {
            if (other == null)
            {
                return 1; // Current instance is greater than null
            }

            // Calculate the magnitude of both complex numbers
            double thisMagnitude = Math.Sqrt(this.Real * this.Real + this.Imiginary * this.Imiginary);
            double otherMagnitude = Math.Sqrt(other.Real * other.Real + other.Imiginary * other.Imiginary);

            // Compare the magnitudes
            if (thisMagnitude > otherMagnitude)
            {
                return 1;
            }
            else if (thisMagnitude < otherMagnitude)
            {
                return -1;
            }
            else
            {
                return 0; // They are equal in magnitude
            }
        }

        public static ComplexNum operator +(ComplexNum a, ComplexNum b)
        {
            return new ComplexNum(a.Real + b.Real, a.Imiginary + b.Imiginary);
        }

        public static ComplexNum operator -(ComplexNum a, ComplexNum b)
        {
            return new ComplexNum(a.Real - b.Real, a.Imiginary - b.Imiginary);
        }

        public static ComplexNum operator *(ComplexNum a, ComplexNum b)
        {
            double real = a.Real * b.Real - a.Imiginary * b.Imiginary;
            double imiginary = a.Real * b.Imiginary + a.Imiginary * b.Real;

            return new ComplexNum(real, imiginary);
        }

        public static explicit operator double(ComplexNum d)
        {
            if(d.Imiginary != 0)
            {
                throw new InvalidCastException("Cannot convert complex number to double");
            }

            return d.Real;
        }
    }
}