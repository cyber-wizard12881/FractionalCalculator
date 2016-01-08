using FractionalCalculator.DataAccess;
using FractionalCalculator.Domain;
using NUnit.Framework;

namespace FractionalCalculator.Unit.Tests.DataAccess
{
    [TestFixture]
    public class OperationsTests
    {
        private Fraction _fraction1;
        private Fraction _fraction2;

        private IOperations<Fraction> _operations;
        [SetUp]
        public void Setup()
        {
            _operations = new Operations<Fraction>();
        }

        #region Addition
        [Test]
        public void ShouldAdd2PositiveFractions()
        {
            _fraction1 = new Fraction(3, 4);
            _fraction2 = new Fraction(2, 3);

            var sum = _operations.Add(_fraction1, _fraction2);

            Assert.IsNotNull(sum);

            Assert.AreEqual(17, sum.Numerator);
            Assert.AreEqual(12, sum.Denominator);
        }

        [Test]
        public void ShouldAdd2NegativeFractions()
        {
            _fraction1 = new Fraction(-3, 4);
            _fraction2 = new Fraction(2, -3);

            var sum = _operations.Add(_fraction1, _fraction2);

            Assert.IsNotNull(sum);

            Assert.AreEqual(-17, sum.Numerator);
            Assert.AreEqual(12, sum.Denominator);
            Assert.AreEqual(true, sum.IsNegative);
        }

        [Test]
        public void ShouldAdd1PostiveAnd1NegativeFractions()
        {
            _fraction1 = new Fraction(3, 7);
            _fraction2 = new Fraction(2, -3);

            var sum = _operations.Add(_fraction1, _fraction2);

            Assert.IsNotNull(sum);

            Assert.AreEqual(-5, sum.Numerator);
            Assert.AreEqual(21, sum.Denominator);
            Assert.AreEqual(true, sum.IsNegative);
        }

        [Test]
        public void ShouldAdd1NegativeAnd1PostiveFractions()
        {
            _fraction1 = new Fraction(3, -7);
            _fraction2 = new Fraction(2, 3);

            var sum = _operations.Add(_fraction1, _fraction2);

            Assert.IsNotNull(sum);

            Assert.AreEqual(5, sum.Numerator);
            Assert.AreEqual(21, sum.Denominator);
            Assert.AreEqual(false, sum.IsNegative);
        }

        #endregion

        #region Subtraction
        [Test]
        public void ShouldSubtract2PositiveFractions()
        {
            _fraction1 = new Fraction(3, 4);
            _fraction2 = new Fraction(2, 3);

            var diff = _operations.Sub(_fraction1, _fraction2);

            Assert.IsNotNull(diff);

            Assert.AreEqual(1, diff.Numerator);
            Assert.AreEqual(12, diff.Denominator);
        }

        [Test]
        public void ShouldSubtract2NegativeFractions()
        {
            _fraction1 = new Fraction(-3, 4);
            _fraction2 = new Fraction(2, -3);

            var sum = _operations.Sub(_fraction1, _fraction2);

            Assert.IsNotNull(sum);

            Assert.AreEqual(-1, sum.Numerator);
            Assert.AreEqual(12, sum.Denominator);
            Assert.AreEqual(true, sum.IsNegative);
        }

        [Test]
        public void ShouldSubtract1PostiveAnd1NegativeFractions()
        {
            _fraction1 = new Fraction(3, 7);
            _fraction2 = new Fraction(2, -3);

            var sum = _operations.Sub(_fraction1, _fraction2);

            Assert.IsNotNull(sum);

            Assert.AreEqual(23, sum.Numerator);
            Assert.AreEqual(21, sum.Denominator);
            Assert.AreEqual(false, sum.IsNegative);
        }

        [Test]
        public void ShouldSubtract1NegativeAnd1PostiveFractions()
        {
            _fraction1 = new Fraction(3, -7);
            _fraction2 = new Fraction(2, 3);

            var sum = _operations.Sub(_fraction1, _fraction2);

            Assert.IsNotNull(sum);

            Assert.AreEqual(-23, sum.Numerator);
            Assert.AreEqual(21, sum.Denominator);
            Assert.AreEqual(true, sum.IsNegative);
        }

        #endregion

        #region Multiplication
        [Test]
        public void ShouldMultiply2PositiveFractions()
        {
            _fraction1 = new Fraction(3, 4);
            _fraction2 = new Fraction(2, 3);

            var prod = _operations.Mul(_fraction1, _fraction2);

            Assert.IsNotNull(prod);

            Assert.AreEqual(6, prod.Numerator);
            Assert.AreEqual(12, prod.Denominator);
        }

        [Test]
        public void ShouldMultiply2NegativeFractions()
        {
            _fraction1 = new Fraction(-3, 4);
            _fraction2 = new Fraction(2, -3);

            var prod = _operations.Mul(_fraction1, _fraction2);

            Assert.IsNotNull(prod);

            Assert.AreEqual(6, prod.Numerator);
            Assert.AreEqual(12, prod.Denominator);
            Assert.AreEqual(false, prod.IsNegative);
        }

        [Test]
        public void ShouldMultiply1PostiveAnd1NegativeFractions()
        {
            _fraction1 = new Fraction(3, 7);
            _fraction2 = new Fraction(2, -3);

            var prod = _operations.Mul(_fraction1, _fraction2);

            Assert.IsNotNull(prod);

            Assert.AreEqual(-6, prod.Numerator);
            Assert.AreEqual(21, prod.Denominator);
            Assert.AreEqual(true, prod.IsNegative);
        }

        [Test]
        public void ShouldMultiply1NegativeAnd1PostiveFractions()
        {
            _fraction1 = new Fraction(3, -7);
            _fraction2 = new Fraction(2, 3);

            var prod = _operations.Mul(_fraction1, _fraction2);

            Assert.IsNotNull(prod);

            Assert.AreEqual(-6, prod.Numerator);
            Assert.AreEqual(21, prod.Denominator);
            Assert.AreEqual(true, prod.IsNegative);
        }

        #endregion

        #region Division
        [Test]
        public void ShouldDivide2PositiveFractions()
        {
            _fraction1 = new Fraction(3, 4);
            _fraction2 = new Fraction(2, 3);

            var div = _operations.Div(_fraction1, _fraction2);

            Assert.IsNotNull(div);

            Assert.AreEqual(9, div.Numerator);
            Assert.AreEqual(8, div.Denominator);
        }

        [Test]
        public void ShouldDivide2NegativeFractions()
        {
            _fraction1 = new Fraction(-3, 4);
            _fraction2 = new Fraction(2, -3);

            var div = _operations.Div(_fraction1, _fraction2);

            Assert.IsNotNull(div);

            Assert.AreEqual(9, div.Numerator);
            Assert.AreEqual(8, div.Denominator);
            Assert.AreEqual(false, div.IsNegative);
        }

        [Test]
        public void ShouldDivide1PostiveAnd1NegativeFractions()
        {
            _fraction1 = new Fraction(3, 7);
            _fraction2 = new Fraction(2, -3);

            var div = _operations.Div(_fraction1, _fraction2);

            Assert.IsNotNull(div);

            Assert.AreEqual(-9, div.Numerator);
            Assert.AreEqual(14, div.Denominator);
            Assert.AreEqual(true, div.IsNegative);
        }

        [Test]
        public void ShouldDivide1NegativeAnd1PostiveFractions()
        {
            _fraction1 = new Fraction(3, -7);
            _fraction2 = new Fraction(2, 3);

            var div = _operations.Div(_fraction1, _fraction2);

            Assert.IsNotNull(div);

            Assert.AreEqual(-9, div.Numerator);
            Assert.AreEqual(14, div.Denominator);
            Assert.AreEqual(true, div.IsNegative);
        }

        #endregion

        #region Power (Exponential Operation)
        [Test]
        public void ShouldPowerPositiveFraction()
        {
            _fraction1 = new Fraction(3, 4);

            var pow = _operations.Pow(_fraction1, 3);

            Assert.IsNotNull(pow);

            Assert.AreEqual(27, pow.Numerator);
            Assert.AreEqual(64, pow.Denominator);
        }

        [Test]
        public void ShouldPower0PositiveFraction()
        {
            _fraction1 = new Fraction(3, 4);

            var pow = _operations.Pow(_fraction1, 0);

            Assert.IsNotNull(pow);

            Assert.AreEqual(1, pow.Numerator);
            Assert.AreEqual(1, pow.Denominator);
        }

        [Test]
        public void ShouldNegativePowerPositiveFraction()
        {
            _fraction1 = new Fraction(3, 4);

            var pow = _operations.Pow(_fraction1, -2);

            Assert.IsNotNull(pow);

            Assert.AreEqual(16, pow.Numerator);
            Assert.AreEqual(9, pow.Denominator);
        }

        #endregion
    }
}
