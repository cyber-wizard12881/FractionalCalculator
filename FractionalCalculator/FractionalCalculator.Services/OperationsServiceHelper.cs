using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractionalCalculator.Domain;

namespace FractionalCalculator.Services
{
    public class OperationsServiceHelper : IOperationsServiceHelper
    {
        public bool IsFractionValid(Fraction fraction)
        {
            return fraction.Denominator != 0;
        }

        public Fraction Normalize(Fraction fraction)
        {
            var gcd = GCD(Math.Abs(fraction.Numerator), Math.Abs(fraction.Denominator));
            var numerator = Math.Abs(fraction.Numerator) / gcd;
            var denominator = Math.Abs(fraction.Denominator) / gcd;
            if (fraction.IsNegative)
                return new Fraction(-numerator, denominator);
            return new Fraction(numerator, denominator);
        }

        private int GCD(int number1, int number2)
        {
            while (number1 != number2)
            {
                if (number1 > number2)
                    number1 = number1 - number2;
                else
                    number2 = number2 - number1;
            }
            return number1;
        }
    }
}
