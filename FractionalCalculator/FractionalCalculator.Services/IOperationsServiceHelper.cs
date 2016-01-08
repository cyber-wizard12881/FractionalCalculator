using FractionalCalculator.Domain;

namespace FractionalCalculator.Services
{
    public interface IOperationsServiceHelper
    {
        Fraction Normalize(Fraction fraction);
        bool IsFractionValid(Fraction fraction);
    }
}