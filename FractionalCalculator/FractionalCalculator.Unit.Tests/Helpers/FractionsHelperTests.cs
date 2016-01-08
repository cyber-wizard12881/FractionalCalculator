using FractionalCalculator.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FractionalCalculator.Unit.Tests.Helpers
{
    [TestFixture]
    public class FractionsHelperTests
    {
        [Test]
        public void ShouldReturnNegativeIfNumeratorIsNegative()
        {
            bool isNegative = FractionsHelper.IsNegative(-7, 17);

            Assert.IsNotNull(isNegative);
            Assert.IsTrue(isNegative);
        }

        [Test]
        public void ShouldReturnNegativeIfDenominatorIsNegative()
        {
            bool isNegative = FractionsHelper.IsNegative(7, -17);

            Assert.IsNotNull(isNegative);
            Assert.IsTrue(isNegative);
        }

        [Test]
        public void ShouldReturnPositiveIfNumeratorAndDenominatorArePositive()
        {
            bool isNegative = FractionsHelper.IsNegative(7, 17);

            Assert.IsNotNull(isNegative);
            Assert.IsFalse(isNegative);
        }

        [Test]
        public void ShouldReturnPositiveIfNumeratorAndDenominatorAreNegative()
        {
            bool isNegative = FractionsHelper.IsNegative(-7, -17);

            Assert.IsNotNull(isNegative);
            Assert.IsFalse(isNegative);
        }
    }
}
