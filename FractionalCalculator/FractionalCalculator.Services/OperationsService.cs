using System;
using FractionalCalculator.DataAccess;
using FractionalCalculator.Domain;

namespace FractionalCalculator.Services
{
    public class OperationsService : IOperationsService
    {
        private readonly IOperations<Fraction> _operations;
        private readonly IOperationsServiceHelper _operationsServiceHelper;

        public OperationsService()
        {
            _operations = new Operations<Fraction>();
            _operationsServiceHelper = new OperationsServiceHelper();
        }
        public OperationsService(IOperations<Fraction> operations, IOperationsServiceHelper helper)
        {
            _operations = operations;
            _operationsServiceHelper = helper;
        }

        public Fraction Add(Fraction fraction1, Fraction fraction2)
        {
            if (_operationsServiceHelper.IsFractionValid(fraction1) &&
                _operationsServiceHelper.IsFractionValid(fraction2))
            {
                Fraction sum = _operations.Add(fraction1, fraction2);
                return _operationsServiceHelper.Normalize(sum);
            }
            throw new FractionException("Fraction is NaN as Denominator is 0.");
        }

        public Fraction Div(Fraction fraction1, Fraction fraction2)
        {
            if (_operationsServiceHelper.IsFractionValid(fraction1) &&
                _operationsServiceHelper.IsFractionValid(fraction2))
            {
                Fraction div = _operations.Div(fraction1, fraction2);
                if (_operationsServiceHelper.IsFractionValid(div))
                    return _operationsServiceHelper.Normalize(div);
                throw new FractionException("Result is NaN as Denominator is 0.");
            }
            throw new FractionException("Fraction is NaN as Denominator is 0.");
        }

        public Fraction Mul(Fraction fraction1, Fraction fraction2)
        {
            if (_operationsServiceHelper.IsFractionValid(fraction1) &&
                _operationsServiceHelper.IsFractionValid(fraction2))
            {
                Fraction prod = _operations.Mul(fraction1, fraction2);
                return _operationsServiceHelper.Normalize(prod);
            }
            throw new FractionException("Fraction is NaN as Denominator is 0.");
        }

        public Fraction Pow(Fraction fraction, int power)
        {
            if (_operationsServiceHelper.IsFractionValid(fraction))
            {
                Fraction pow = _operations.Pow(fraction, power);
                return _operationsServiceHelper.Normalize(pow);
            }
            throw new FractionException("Fraction is NaN as Denominator is 0.");
        }

        public Fraction Sub(Fraction fraction1, Fraction fraction2)
        {
            if (_operationsServiceHelper.IsFractionValid(fraction1) &&
               _operationsServiceHelper.IsFractionValid(fraction2))
            {
                Fraction diff = _operations.Sub(fraction1, fraction2);
                return _operationsServiceHelper.Normalize(diff);
            }
            throw new FractionException("Fraction is NaN as Denominator is 0.");
        }
    }
}
