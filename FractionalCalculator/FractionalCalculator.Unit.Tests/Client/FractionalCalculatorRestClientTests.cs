using System;
using System.Net;
using FractionalCalculator.Client;
using FractionalCalculator.Models;
using FractionalCalculator.Request;
using FractionalCalculator.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using Rhino.Mocks;
using Assert = NUnit.Framework.Assert;

namespace FractionalCalculator.Unit.Tests.Client
{
    [TestFixture]
    public class FractionalCalculatorRestClientTests
    {
        private IFractionalCalculatorRestClient _client;
        private IRestClient _restClient;

        [SetUp]
        public void SetUp()
        {
            _restClient = MockRepository.GenerateMock<IRestClient>();
            _client = new FractionalCalculatorRestClient(_restClient);
        }

        #region Addition
        [Test]
        public void ShouldAddTwoFractionsCallingFractionServiceWebApi()
        {
            FractionModel fraction = new FractionModel { Numerator = 5, Denominator = 6 };

            FractionResponse fractionResponse = new FractionResponse { Fraction = fraction };

            var response = new RestResponse<FractionResponse> { Data = fractionResponse, StatusCode = HttpStatusCode.OK };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Add"))))
                .Return(response);

            var result = _client.Add(1, 2, 1, 3);

            _restClient.VerifyAllExpectations();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Fraction.Numerator);
            Assert.AreEqual(6, result.Fraction.Denominator);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExcedptionWhenAddingTwoFractionsCallingFractionServiceWebApi()
        {
            var response = new RestResponse<FractionResponse> { StatusCode = HttpStatusCode.BadRequest };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Add"))))
                .Return(response);

            Assert.Throws<Exception>(() => _client.Add(1, 2, 1, 0));

            _restClient.VerifyAllExpectations();
        }
        #endregion

        #region Subtraction
        [Test]
        public void ShouldSubtractTwoFractionsCallingFractionServiceWebApi()
        {
            FractionModel fraction = new FractionModel { Numerator = 1, Denominator = 6 };

            FractionResponse fractionResponse = new FractionResponse { Fraction = fraction };

            var response = new RestResponse<FractionResponse> { Data = fractionResponse, StatusCode = HttpStatusCode.OK };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Subtract"))))
                .Return(response);

            var result = _client.Subtract(1, 2, 1, 3);

            _restClient.VerifyAllExpectations();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Fraction.Numerator);
            Assert.AreEqual(6, result.Fraction.Denominator);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExcedptionWhenSubtractingTwoFractionsCallingFractionServiceWebApi()
        {
            var response = new RestResponse<FractionResponse> { StatusCode = HttpStatusCode.BadRequest };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Subtract"))))
                .Return(response);

            Assert.Throws<Exception>(() => _client.Subtract(1, 2, 1, 0));

            _restClient.VerifyAllExpectations();
        }
        #endregion

        #region Multiplication
        [Test]
        public void ShouldMuliplyTwoFractionsCallingFractionServiceWebApi()
        {
            FractionModel fraction = new FractionModel { Numerator = 1, Denominator = 6 };

            FractionResponse fractionResponse = new FractionResponse { Fraction = fraction };

            var response = new RestResponse<FractionResponse> { Data = fractionResponse, StatusCode = HttpStatusCode.OK };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Multiply"))))
                .Return(response);

            var result = _client.Multiply(1, 2, 1, 3);

            _restClient.VerifyAllExpectations();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Fraction.Numerator);
            Assert.AreEqual(6, result.Fraction.Denominator);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExcedptionWhenMultiplyingTwoFractionsCallingFractionServiceWebApi()
        {
            var response = new RestResponse<FractionResponse> { StatusCode = HttpStatusCode.BadRequest };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Multiply"))))
                .Return(response);

            Assert.Throws<Exception>(() => _client.Multiply(1, 2, 1, 0));

            _restClient.VerifyAllExpectations();
        }
        #endregion

        #region Division
        [Test]
        public void ShouldDivideTwoFractionsCallingFractionServiceWebApi()
        {
            FractionModel fraction = new FractionModel { Numerator = 3, Denominator = 2 };

            FractionResponse fractionResponse = new FractionResponse { Fraction = fraction };

            var response = new RestResponse<FractionResponse> { Data = fractionResponse, StatusCode = HttpStatusCode.OK };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Divide"))))
                .Return(response);

            var result = _client.Divide(1, 2, 1, 3);

            _restClient.VerifyAllExpectations();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Fraction.Numerator);
            Assert.AreEqual(2, result.Fraction.Denominator);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionWhenDividingTwoFractionsCallingFractionServiceWebApi()
        {
            var response = new RestResponse<FractionResponse> { StatusCode = HttpStatusCode.BadRequest };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Divide"))))
                .Return(response);

            Assert.Throws<Exception>(() => _client.Divide(1, 2, 1, 0));

            _restClient.VerifyAllExpectations();
        }
        #endregion

        #region Power (Exponentiation)
        [Test]
        public void ShouldExponentiateFractionCallingFractionServiceWebApi()
        {
            FractionModel fractionResult = new FractionModel { Numerator = 1, Denominator = 8 };

            FractionResponse fractionResponse = new FractionResponse { Fraction = fractionResult };

            var response = new RestResponse<FractionResponse> { Data = fractionResponse, StatusCode = HttpStatusCode.OK };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Power"))))
                .Return(response);

            var result = _client.Power(1, 2, 3);

            _restClient.VerifyAllExpectations();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Fraction.Numerator);
            Assert.AreEqual(8, result.Fraction.Denominator);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionWhenExponentiatingFractionCallingFractionServiceWebApi()
        {
            var response = new RestResponse<FractionResponse> { StatusCode = HttpStatusCode.BadRequest };

            _restClient.Expect(
                rc =>
                    rc.Execute<FractionResponse>(
                        Arg<RestRequest>.Matches(
                            rr => rr.Method == Method.POST && rr.Resource.Equals("api/Fractions/Power"))))
                .Return(response);

            Assert.Throws<Exception>(() => _client.Power(1, 0, 3));

            _restClient.VerifyAllExpectations();
        }
        #endregion
    }
}
