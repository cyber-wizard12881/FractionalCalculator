using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalCalculator.Domain
{
    public class Fraction
    {
        public int Numerator { get; set; } = 0;
        public int Denominator { get; set; } = 1;
        public bool IsNegative { get; private set; } = false;

        public Fraction(int numerator, int denominator)
        {
            IsNegative = FractionsHelper.IsNegative(numerator, denominator);
            Numerator = IsNegative?-Math.Abs(numerator):Math.Abs(numerator);
            Denominator = Math.Abs(denominator);
        }
    }
}
