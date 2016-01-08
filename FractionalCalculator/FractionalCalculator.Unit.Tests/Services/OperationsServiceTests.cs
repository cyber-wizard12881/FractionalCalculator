using FractionalCalculator.DataAccess;
using FractionalCalculator.Domain;
using FractionalCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Rhino.Mocks;
using Assert = NUnit.Framework.Assert;

namespace FractionalCalculator.Unit.Tests.Services
{
    [TestFixture]
    public class OperationsServiceTests
    {
        private IOperations<Fraction> _operations;
        private IOperationsService _service;
        private IOperationsServiceHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _operations = MockRepository.GenerateMock<IOperations<Fraction>>();
            _helper = MockRepository.GenerateMock<IOperationsServiceHelper>();
            _service = new OperationsService(_operations, _helper);
        }

        #region Addition
        [Test]
        public void ShouldAdd2Fractions()
        {
            Fraction fraction1 = new Fraction(3, 4);
            Fraction fraction2 = new Fraction(2, 3);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Add(fraction1, fraction2)).Return(new Fraction(17, 12));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(17, 12));
            var sum = _service.Add(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();
            Assert.IsNotNull(sum);

            Assert.AreEqual(17, sum.Numerator);
            Assert.AreEqual(12, sum.Denominator);
            Assert.AreEqual(false, sum.IsNegative);
        }

        [Test]
        public void ShouldAdd2FractionsAndNormalize()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 8);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Add(fraction1, fraction2)).Return(new Fraction(36, 48));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(3, 4));
            var sum = _service.Add(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();

            Assert.IsNotNull(sum);

            Assert.AreEqual(3, sum.Numerator);
            Assert.AreEqual(4, sum.Denominator);
            Assert.AreEqual(false, sum.IsNegative);
        }

        [Test]
        [ExpectedException(typeof(FractionException), noExceptionMessage: "Fraction is NaN as Denominator is 0.")]
        public void ShouldThrowExceptionIfDenominatorIsZeroWhenAdding()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 0);

            Assert.Throws<FractionException>(() => _service.Add(fraction1, fraction2));
        }
        #endregion

        #region Subtraction
        [Test]
        public void ShouldSubtract2Fractions()
        {
            Fraction fraction1 = new Fraction(3, 4);
            Fraction fraction2 = new Fraction(2, 3);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Sub(fraction1, fraction2)).Return(new Fraction(1, 12));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(1, 12));
            var diff = _service.Sub(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();
            Assert.IsNotNull(diff);

            Assert.AreEqual(1, diff.Numerator);
            Assert.AreEqual(12, diff.Denominator);
            Assert.AreEqual(false, diff.IsNegative);
        }

        [Test]
        public void ShouldSubtract2FractionsAndNormalize()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 8);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Sub(fraction1, fraction2)).Return(new Fraction(12, 48));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(1, 4));
            var diff = _service.Sub(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();

            Assert.IsNotNull(diff);

            Assert.AreEqual(1, diff.Numerator);
            Assert.AreEqual(4, diff.Denominator);
            Assert.AreEqual(false, diff.IsNegative);
        }

        [Test]
        [ExpectedException(typeof(FractionException), noExceptionMessage: "Fraction is NaN as Denominator is 0.")]
        public void ShouldThrowExceptionIfDenominatorIsZeroWhenSubtracting()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 0);

            Assert.Throws<FractionException>(() => _service.Sub(fraction1, fraction2));
        }
        #endregion

        #region Multiplication
        [Test]
        public void ShouldMultiply2Fractions()
        {
            Fraction fraction1 = new Fraction(2, 5);
            Fraction fraction2 = new Fraction(3, 7);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Mul(fraction1, fraction2)).Return(new Fraction(6, 35));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(6, 35));
            var prod = _service.Mul(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();
            Assert.IsNotNull(prod);

            Assert.AreEqual(6, prod.Numerator);
            Assert.AreEqual(35, prod.Denominator);
            Assert.AreEqual(false, prod.IsNegative);
        }

        [Test]
        public void ShouldMultiply2FractionsAndNormalize()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 8);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Mul(fraction1, fraction2)).Return(new Fraction(6, 48));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(1, 8));
            var prod = _service.Mul(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();

            Assert.IsNotNull(prod);

            Assert.AreEqual(1, prod.Numerator);
            Assert.AreEqual(8, prod.Denominator);
            Assert.AreEqual(false, prod.IsNegative);
        }

        [Test]
        [ExpectedException(typeof(FractionException), noExceptionMessage: "Fraction is NaN as Denominator is 0.")]
        public void ShouldThrowExceptionIfDenominatorIsZeroWhenMultiplying()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 0);

            Assert.Throws<FractionException>(() => _service.Mul(fraction1, fraction2));
        }
        #endregion

        #region Division
        [Test]
        public void ShouldDivide2Fractions()
        {
            Fraction fraction1 = new Fraction(2, 5);
            Fraction fraction2 = new Fraction(3, 7);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Div(fraction1, fraction2)).Return(new Fraction(14, 15));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(14, 15));
            var div = _service.Div(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();
            Assert.IsNotNull(div);

            Assert.AreEqual(14, div.Numerator);
            Assert.AreEqual(15, div.Denominator);
            Assert.AreEqual(false, div.IsNegative);
        }

        [Test]
        public void ShouldDivide2FractionsAndNormalize()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 8);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Div(fraction1, fraction2)).Return(new Fraction(24, 12));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(2, 1));
            var div = _service.Div(fraction1, fraction2);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();

            Assert.IsNotNull(div);

            Assert.AreEqual(2, div.Numerator);
            Assert.AreEqual(1, div.Denominator);
            Assert.AreEqual(false, div.IsNegative);
        }

        [Test]
        [ExpectedException(typeof(FractionException), noExceptionMessage: "Fraction is NaN as Denominator is 0.")]
        public void ShouldThrowExceptionIfDenominatorIsZeroWhenDividing()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(2, 0);

            Assert.Throws<FractionException>(() => _service.Div(fraction1, fraction2));
        }

        [Test]
        [ExpectedException(typeof(FractionException), noExceptionMessage: "Fraction is NaN as Denominator is 0.")]
        public void ShouldThrowExceptionIfDenominatorIsZeroWhenDividingByZero()
        {
            Fraction fraction1 = new Fraction(3, 6);
            Fraction fraction2 = new Fraction(0, 1);
            var fraction = new Fraction(3, 0);

            _helper.Expect(helper => helper.IsFractionValid(fraction1)).Return(true);
            _helper.Expect(helper => helper.IsFractionValid(fraction2)).Return(true);
            _helper.Expect(helper => helper.IsFractionValid(fraction)).Return(false);

            _operations.Expect(operation => operation.Div(Arg<Fraction>.Is.Anything, Arg<Fraction>.Is.Anything))
                .Return(fraction);

            Assert.Throws<FractionException>(() => _service.Div(fraction1, fraction2));
            _operations.VerifyAllExpectations();
        }

        #endregion

        #region Power (Exponentiation)
        [Test]
        public void ShouldPowerFraction()
        {
            Fraction fraction1 = new Fraction(2, 5);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Pow(fraction1, 3)).Return(new Fraction(8, 125));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(8, 125));
            var pow = _service.Pow(fraction1, 3);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();
            Assert.IsNotNull(pow);

            Assert.AreEqual(8, pow.Numerator);
            Assert.AreEqual(125, pow.Denominator);
            Assert.AreEqual(false, pow.IsNegative);
        }

        [Test]
        public void ShouldPowerFractionAndNormalize()
        {
            Fraction fraction1 = new Fraction(2, 4);

            _helper.Expect(helper => helper.IsFractionValid(Arg<Fraction>.Is.Anything)).Return(true);
            _operations.Expect(operation => operation.Pow(fraction1, 3)).Return(new Fraction(8, 64));
            _helper.Expect(helper => helper.Normalize(Arg<Fraction>.Is.Anything)).Return(new Fraction(1, 8));
            var pow = _service.Pow(fraction1, 3);

            _operations.VerifyAllExpectations();
            _helper.VerifyAllExpectations();
            Assert.IsNotNull(pow);

            Assert.AreEqual(1, pow.Numerator);
            Assert.AreEqual(8, pow.Denominator);
            Assert.AreEqual(false, pow.IsNegative);
        }

        [Test]
        [ExpectedException(typeof(FractionException), noExceptionMessage: "Fraction is NaN as Denominator is 0.")]
        public void ShouldThrowExceptionIfDenominatorIsZeroWhenExponentiating()
        {
            Fraction fraction = new Fraction(2, 0);

            Assert.Throws<FractionException>(() => _service.Pow(fraction, 3));
        }
        #endregion
    }
}
