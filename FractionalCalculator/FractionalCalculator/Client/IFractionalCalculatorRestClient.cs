using FractionalCalculator.Response;

namespace FractionalCalculator.Client
{
    public interface IFractionalCalculatorRestClient
    {
        FractionResponse Add(int numerator1,int denominator1,int numerator2, int denominator2);
        FractionResponse Subtract(int numerator1,int denominator1,int numerator2, int denominator2);
        FractionResponse Multiply(int numerator1,int denominator1,int numerator2, int denominator2);
        FractionResponse Divide(int numerator1,int denominator1,int numerator2, int denominator2);
        FractionResponse Power(int numerator,int denominator,int power);
    }
}
