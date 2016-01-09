using FractionalCalculator.Domain;
using FractionalCalculator.Mappers;
using FractionalCalculator.Models;
using NUnit.Framework;

namespace FractionalCalculator.Unit.Tests.Mappers
{
    [TestFixture]
    public class FractionMapperTests
    {
        private FractionModel _model;
        private Fraction _domain;

        [SetUp]
        public void SetUp()
        {
            _model = new FractionModel
            {
                Numerator = 3,
                Denominator = 7
            };

            _domain = new Fraction(5, 17);
        }

        [Test]
        public void ShouldMapFractionModelToFraction()
        {
            var domain = FractionMapper.Map(_model);

            Assert.IsNotNull(domain);

            Assert.AreEqual(_model.Numerator, domain.Numerator);
            Assert.AreEqual(_model.Denominator, domain.Denominator);
        }

        [Test]
        public void ShouldMapFractionToFractionModel()
        {
            var model = FractionMapper.Map(_domain);

            Assert.IsNotNull(model);

            Assert.AreEqual(_domain.Numerator, model.Numerator);
            Assert.AreEqual(_domain.Denominator, model.Denominator);
        }
    }
}
