using System.Web.Http;
using System.Web.Http.Results;
using FractionalCalculator.Controllers;
using FractionalCalculator.Domain;
using FractionalCalculator.Models;
using FractionalCalculator.Request;
using FractionalCalculator.Response;
using FractionalCalculator.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace FractionalCalculator.Unit.Tests.Controllers
{
    [TestFixture]
    public class FractionControllerTests
    {
        private FractionController _controller;
        private IOperationsService _service;
        
        [SetUp]
        public void SetUp()
        {
            _service = MockRepository.GenerateMock<IOperationsService>();
            _controller = new FractionController(_service);
        }

        [Test]
        public void ShouldAdd2Fractions()
        {
            FractionRequest request = new FractionRequest
            {
                Fraction1 = new FractionModel
                {
                    Numerator = 2,
                    Denominator = 3
                },
                Fraction2 = new FractionModel
                {
                    Numerator = 4,
                    Denominator = 5
                }
            };

            _service.Expect(service => service.Add(Arg<Fraction>.Is.Anything, Arg<Fraction>.Is.Anything))
                .Return(new Fraction(22, 15));

            var fractionResponse = _controller.Add(request) as OkNegotiatedContentResult<FractionResponse>;
           
            _service.VerifyAllExpectations();

            Assert.IsNotNull(fractionResponse);
            Assert.AreEqual(22, fractionResponse.Content.Fraction.Numerator);
            Assert.AreEqual(15, fractionResponse.Content.Fraction.Denominator);
        }

        [Test]
        public void ShouldSubtract2Fractions()
        {
            FractionRequest request = new FractionRequest
            {
                Fraction1 = new FractionModel
                {
                    Numerator = 2,
                    Denominator = 3
                },
                Fraction2 = new FractionModel
                {
                    Numerator = 4,
                    Denominator = 5
                }
            };

            _service.Expect(service => service.Sub(Arg<Fraction>.Is.Anything, Arg<Fraction>.Is.Anything))
                .Return(new Fraction(-2, 15));

            var fractionResponse = _controller.Subtract(request) as OkNegotiatedContentResult<FractionResponse>;

            _service.VerifyAllExpectations();

            Assert.IsNotNull(fractionResponse);
            Assert.AreEqual(-2, fractionResponse.Content.Fraction.Numerator);
            Assert.AreEqual(15, fractionResponse.Content.Fraction.Denominator);
        }

        [Test]
        public void ShouldMultiply2Fractions()
        {
            FractionRequest request = new FractionRequest
            {
                Fraction1 = new FractionModel
                {
                    Numerator = 2,
                    Denominator = 3
                },
                Fraction2 = new FractionModel
                {
                    Numerator = 4,
                    Denominator = 5
                }
            };

            _service.Expect(service => service.Mul(Arg<Fraction>.Is.Anything, Arg<Fraction>.Is.Anything))
                .Return(new Fraction(8, 15));

            var fractionResponse = _controller.Multiply(request) as OkNegotiatedContentResult<FractionResponse>;

            _service.VerifyAllExpectations();

            Assert.IsNotNull(fractionResponse);
            Assert.AreEqual(8, fractionResponse.Content.Fraction.Numerator);
            Assert.AreEqual(15, fractionResponse.Content.Fraction.Denominator);
        }

        [Test]
        public void ShouldDivide2Fractions()
        {
            FractionRequest request = new FractionRequest
            {
                Fraction1 = new FractionModel
                {
                    Numerator = 2,
                    Denominator = 3
                },
                Fraction2 = new FractionModel
                {
                    Numerator = 4,
                    Denominator = 5
                }
            };

            _service.Expect(service => service.Div(Arg<Fraction>.Is.Anything, Arg<Fraction>.Is.Anything))
                .Return(new Fraction(5, 6));

            var fractionResponse = _controller.Divide(request) as OkNegotiatedContentResult<FractionResponse>;

            _service.VerifyAllExpectations();

            Assert.IsNotNull(fractionResponse);
            Assert.AreEqual(5, fractionResponse.Content.Fraction.Numerator);
            Assert.AreEqual(6, fractionResponse.Content.Fraction.Denominator);
        }

        [Test]
        public void ShouldExponentiate2Fractions()
        {
            FractionPowerRequest request = new FractionPowerRequest
            {
                Fraction = new FractionModel
                {
                    Numerator = 2,
                    Denominator = 3
                },
                Power = 3
            };

            _service.Expect(service => service.Pow(Arg<Fraction>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new Fraction(16, 27));

            var fractionResponse = _controller.Power(request) as OkNegotiatedContentResult<FractionResponse>;

            _service.VerifyAllExpectations();

            Assert.IsNotNull(fractionResponse);
            Assert.AreEqual(16, fractionResponse.Content.Fraction.Numerator);
            Assert.AreEqual(27, fractionResponse.Content.Fraction.Denominator);
        }

    }
}
