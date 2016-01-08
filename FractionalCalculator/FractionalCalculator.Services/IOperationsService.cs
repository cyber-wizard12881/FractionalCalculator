using FractionalCalculator.Domain;

namespace FractionalCalculator.Services
{
    public interface IOperationsService
    {
        Fraction Add(Fraction fraction1, Fraction fraction2);
        Fraction Sub(Fraction fraction1, Fraction fraction2);
        Fraction Mul(Fraction fraction1, Fraction fraction2);
        Fraction Div(Fraction fraction1, Fraction fraction2);
        Fraction Pow(Fraction fraction, int power);
    }
}