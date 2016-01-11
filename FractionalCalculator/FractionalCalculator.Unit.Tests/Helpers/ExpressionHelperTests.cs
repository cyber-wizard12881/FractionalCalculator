using System;
using FractionalCalculator.Client;
using FractionalCalculator.Helpers;
using FractionalCalculator.Models;
using FractionalCalculator.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Rhino.Mocks;
using Assert = NUnit.Framework.Assert;

namespace FractionalCalculator.Unit.Tests.Helpers
{
    [TestFixture]
    public class ExpressionHelperTests
    {
        private IExpressionHelper _helper;
        private IFractionalCalculatorRestClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = MockRepository.GenerateMock<IFractionalCalculatorRestClient>();
            _helper = new ExpressionHelper(_client);
        }

        [Test]
        public void ShouldAdd2Fractions()
        {
            var fractionResponse = new FractionResponse { Fraction = new FractionModel { Numerator = 22, Denominator = 15 } };
            _client.Expect(c => c.Add(2, 3, 4, 5)).Return(fractionResponse);

            var result = _helper.ParseExpression("2/3 + 4/5");

            Assert.IsNotNull(result);
            Assert.AreEqual("22/15", result);
        }

        [Test]
        public void ShouldSubtract2Fractions()
        {
            var fractionResponse = new FractionResponse { Fraction = new FractionModel { Numerator = -2, Denominator = 15 } };
            _client.Expect(c => c.Subtract(2, 3, 4, 5)).Return(fractionResponse);

            var result = _helper.ParseExpression("2/3 - 4/5");

            Assert.IsNotNull(result);
            Assert.AreEqual("-2/15", result);
        }

        [Test]
        public void ShouldMultiply2Fractions()
        {
            var fractionResponse = new FractionResponse { Fraction = new FractionModel { Numerator = 8, Denominator = 15 } };
            _client.Expect(c => c.Multiply(2, 3, 4, 5)).Return(fractionResponse);

            var result = _helper.ParseExpression("2/3 * 4/5");

            Assert.IsNotNull(result);
            Assert.AreEqual("8/15", result);
        }

        [Test]
        public void ShouldDivide2Fractions()
        {
            var fractionResponse = new FractionResponse { Fraction = new FractionModel { Numerator = 5, Denominator = 6 } };
            _client.Expect(c => c.Divide(2, 3, 4, 5)).Return(fractionResponse);

            var result = _helper.ParseExpression("2/3 / 4/5");

            Assert.IsNotNull(result);
            Assert.AreEqual("5/6", result);
        }

        [Test]
        public void ShouldPowerFraction()
        {
            var fractionResponse = new FractionResponse { Fraction = new FractionModel { Numerator = 8, Denominator = 27 } };
            _client.Expect(c => c.Power(2, 3, 3)).Return(fractionResponse);

            var result = _helper.ParseExpression("2/3 ^ 3");

            Assert.IsNotNull(result);
            Assert.AreEqual("8/27", result);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowException()
        {
            Assert.Throws<Exception>(() => _helper.ParseExpression("2/3 ~ 3"));
        }
    }
}
