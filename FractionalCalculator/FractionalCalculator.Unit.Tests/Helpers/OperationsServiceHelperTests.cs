using FractionalCalculator.Domain;
using FractionalCalculator.Services;
using NUnit.Framework;

namespace FractionalCalculator.Unit.Tests.Helpers
{
    [TestFixture]
    public class OperationsServiceHelperTests
    {
        private IOperationsServiceHelper _operationsServiceHelper;

        [SetUp]
        public void SetUp()
        {
            _operationsServiceHelper = new OperationsServiceHelper();
        }

        [Test]
        public void ShouldReturnValidFraction()
        {
            var isFractionValid = _operationsServiceHelper.IsFractionValid(new Fraction(3, 19));

            Assert.IsNotNull(isFractionValid);
            Assert.IsTrue(isFractionValid);
        }

        [Test]
        public void ShouldReturnInValidFraction()
        {
            var isFractionValid = _operationsServiceHelper.IsFractionValid(new Fraction(3, 0));

            Assert.IsNotNull(isFractionValid);
            Assert.IsFalse(isFractionValid);
        }

        [Test]
        public void ShouldReturnNormalizedFraction()
        {
            var normalizedFraction = _operationsServiceHelper.Normalize(new Fraction(3, 36));

            Assert.IsNotNull(normalizedFraction);
            Assert.AreEqual(1, normalizedFraction.Numerator);
            Assert.AreEqual(12, normalizedFraction.Denominator);
        }

        [Test]
        public void ShouldReturnNonNormalizableFraction()
        {
            var normalizedFraction = _operationsServiceHelper.Normalize(new Fraction(3, 19));

            Assert.IsNotNull(normalizedFraction);
            Assert.AreEqual(3, normalizedFraction.Numerator);
            Assert.AreEqual(19, normalizedFraction.Denominator);
        }
    }
}
