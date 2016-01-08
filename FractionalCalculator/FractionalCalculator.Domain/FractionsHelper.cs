namespace FractionalCalculator.Domain
{
    public static class FractionsHelper
    {
        public static bool IsNegative(int numerator, int denominator)
        {
            if (numerator < 0 && denominator > 0 || numerator > 0 && denominator < 0)
                return true;
            return false;
        }
    }
}
