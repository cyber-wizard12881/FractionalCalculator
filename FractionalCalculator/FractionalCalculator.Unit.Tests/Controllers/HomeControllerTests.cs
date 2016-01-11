using System;
using System.Web.Mvc;
using FractionalCalculator.Client;
using FractionalCalculator.Controllers;
using FractionalCalculator.Helpers;
using FractionalCalculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Rhino.Mocks;
using Assert = NUnit.Framework.Assert;

namespace FractionalCalculator.Unit.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private IExpressionHelper _helper;
        private ExpressionModel _model;

        [SetUp]
        public void SetUp()
        {
            _helper = MockRepository.GenerateMock<IExpressionHelper>();
            _controller = new HomeController(_helper);
        }

        [Test]
        public void ShouldParseExpressionAndEvaluateResult()
        {
            _helper.Expect(c => c.ParseExpression("2/3 + 4/5")).Return("22/15");
            _model = new ExpressionModel
            {
                Expression = "2/3 + 4/5"
            };
            var actionResult = _controller.Index(_model) as ViewResult;

            _helper.VerifyAllExpectations();
            Assert.IsNotNull(actionResult);

            var model = actionResult.Model as ExpressionModel;

            Assert.IsNotNull(model);
            Assert.AreEqual("22/15", model.Result);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ShouldParseExpressionAndThrowException()
        {
            _helper.Expect(c => c.ParseExpression("2/3 ~ 4/5")).Throw(new Exception("Invalid Expression Syntax!"));
            _model = new ExpressionModel
            {
                Expression = "2/3 ~ 4/5"
            };
            var actionResult = _controller.Index(_model) as ViewResult;

            _helper.VerifyAllExpectations();
            Assert.IsNotNull(actionResult);

            var model = actionResult.Model as ExpressionModel;

            Assert.IsNotNull(model);
            Assert.AreEqual("Invalid Expression Syntax!", model.Result);
        }
    }
}
