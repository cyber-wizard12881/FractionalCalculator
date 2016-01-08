using FractionalCalculator.Domain;

namespace FractionalCalculator.DataAccess
{
    public static class OperationsHelper
    {
        public static bool IsNegative(Fraction fraction)
        {
            if (fraction.Numerator < 0 && fraction.Denominator > 0 || fraction.Numerator > 0 && fraction.Denominator < 0)
                return true;
            return false;
        }
    }
}
