using System.Security.Cryptography.X509Certificates;
using FractionalCalculator.Domain;

namespace FractionalCalculator.DataAccess
{
    public interface IOperations<T> where T:Fraction
    {
        Fraction Add(Fraction fraction1, Fraction fraction2);
        Fraction Sub(Fraction fraction1, Fraction fraction2);
        Fraction Mul(Fraction fraction1, Fraction fraction2);
        Fraction Div(Fraction fraction1, Fraction fraction2);
        Fraction Pow(Fraction fraction, int power);
    }
}