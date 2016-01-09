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
            var _domain = FractionMapper.Map(_model);

            Assert.IsNotNull(_domain);

            Assert.AreEqual(_model.Numerator, _domain.Numerator);
            Assert.AreEqual(_model.Denominator, _domain.Denominator);
        }

        [Test]
        public void ShouldMapFractionToFractionModel()
        {
            var _model = FractionMapper.Map(_domain);

            Assert.IsNotNull(_model);

            Assert.AreEqual(_domain.Numerator, _model.Numerator);
            Assert.AreEqual(_domain.Denominator, _model.Denominator);
        }
    }
}
