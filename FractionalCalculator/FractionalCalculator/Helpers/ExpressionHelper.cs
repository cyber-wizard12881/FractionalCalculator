using System;
using FractionalCalculator.Client;
using FractionalCalculator.Models;
using FractionalCalculator.Response;

namespace FractionalCalculator.Helpers
{
    public class ExpressionHelper : IExpressionHelper
    {
        private readonly IFractionalCalculatorRestClient _client;

        private readonly string[] _delims = { " " };

        public ExpressionHelper()
        {
            _client = new FractionalCalculatorRestClient();
        }

        public ExpressionHelper(IFractionalCalculatorRestClient client)
        {
            _client = client;
        }

        public string ParseExpression(string expression)
        {
            FractionResponse fractionResponse;
            FractionModel fraction1;
            FractionModel fraction2;

            var tokens = expression.Split(_delims, StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[1])
            {
                case "^":
                    fraction1 = StringToFraction(tokens[0]);
                    fraction2 = StringToFraction(tokens[2]);
                    fractionResponse = _client.Power(fraction1.Numerator, fraction1.Denominator, fraction2.Numerator);
                    break;
                case "/":
                    fraction1 = StringToFraction(tokens[0]);
                    fraction2 = StringToFraction(tokens[2]);
                    fractionResponse = _client.Divide(fraction1.Numerator, fraction1.Denominator, fraction2.Numerator,
                        fraction2.Denominator);
                    break;
                case "*":
                    fraction1 = StringToFraction(tokens[0]);
                    fraction2 = StringToFraction(tokens[2]);
                    fractionResponse = _client.Multiply(fraction1.Numerator, fraction1.Denominator, fraction2.Numerator,
                        fraction2.Denominator);
                    break;
                case "-":
                    fraction1 = StringToFraction(tokens[0]);
                    fraction2 = StringToFraction(tokens[2]);
                    fractionResponse = _client.Subtract(fraction1.Numerator, fraction1.Denominator, fraction2.Numerator,
                        fraction2.Denominator);
                    break;
                case "+":
                    fraction1 = StringToFraction(tokens[0]);
                    fraction2 = StringToFraction(tokens[2]);
                    fractionResponse = _client.Add(fraction1.Numerator, fraction1.Denominator, fraction2.Numerator,
                        fraction2.Denominator);
                    break;
                default:
                    throw new Exception("Invalid Expression Syntax!");
            }

            return FractionToString(fractionResponse);
        }

        private FractionModel StringToFraction(string fractionString)
        {
            int numerator, denominator = 1;
            var fraction = fractionString.Split('/');
            if (fraction.Length == 1)
            {
                numerator = Convert.ToInt32(fraction[0]);
            }
            else
            {
                numerator = Convert.ToInt32(fraction[0]);
                denominator = Convert.ToInt32(fraction[1]);
            }

            return new FractionModel
            {
                Numerator = numerator,
                Denominator = denominator
            };
        }

        private string FractionToString(FractionResponse response)
        {
            if (response.Fraction.Denominator == 1)
                return $"{response.Fraction.Numerator}";
            return $"{response.Fraction.Numerator}/{response.Fraction.Denominator}";
        }
    }
}