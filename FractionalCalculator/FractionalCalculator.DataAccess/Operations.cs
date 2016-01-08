using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractionalCalculator.Domain;
using FractionalCalculator.DataAccess;

namespace FractionalCalculator.DataAccess
{
    public class Operations<T> : IOperations<T> where T : Fraction
    {
        public Fraction Add(Fraction fraction1, Fraction fraction2)
        {
            var sum = new Fraction(fraction1.Numerator * fraction2.Denominator + fraction1.Denominator * fraction2.Numerator,
                fraction1.Denominator * fraction2.Denominator);
            return sum;
        }

        public Fraction Div(Fraction fraction1, Fraction fraction2)
        {
            var div = new Fraction(fraction1.Numerator * fraction2.Denominator,
               fraction1.Denominator * fraction2.Numerator);
            return div;
        }

        public Fraction Mul(Fraction fraction1, Fraction fraction2)
        {
            var prod = new Fraction(fraction1.Numerator * fraction2.Numerator,
               fraction1.Denominator * fraction2.Denominator);
            return prod;
        }

        public Fraction Pow(Fraction fraction, int power)
        {
            Fraction powResult = new Fraction(1,1);

            for (int times = Math.Abs(power); times > 0; times--)
            {
                powResult = Mul(powResult, fraction);
            }

            if (power < 0)
            {
                return new Fraction(powResult.Denominator, powResult.Numerator);
            }
            return powResult;
        }

        public Fraction Sub(Fraction fraction1, Fraction fraction2)
        {
            var diff = new Fraction(fraction1.Numerator * fraction2.Denominator - fraction1.Denominator * fraction2.Numerator,
               fraction1.Denominator * fraction2.Denominator);
            return diff;
        }
    }

}
