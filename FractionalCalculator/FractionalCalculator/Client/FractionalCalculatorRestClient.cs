using System;
using System.Configuration;
using System.Net;
using FractionalCalculator.Domain;
using FractionalCalculator.Models;
using FractionalCalculator.Request;
using FractionalCalculator.Response;
using RestSharp;

namespace FractionalCalculator.Client
{
    public class FractionalCalculatorRestClient : IFractionalCalculatorRestClient
    {
        private readonly IRestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["FractionalCalculatorUrl"];

        public FractionalCalculatorRestClient()
        {
            _client = new RestClient(_url);
        }

        public FractionalCalculatorRestClient(IRestClient client)
        {
            _client = client;
        }

        public FractionResponse Add(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            FractionModel fraction1 = new FractionModel
            {
                Numerator = numerator1,
                Denominator = denominator1
            };

            FractionModel fraction2 = new FractionModel
            {
                Numerator = numerator2,
                Denominator = denominator2
            };

            FractionRequest fractionRequest = new FractionRequest
            {
                Fraction1 = fraction1,
                Fraction2 = fraction2
            };

            var request = new RestRequest("api/Fractions/Add", Method.POST){ RequestFormat = DataFormat.Json };
            request.AddBody(fractionRequest);

            var response = _client.Execute<FractionResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public FractionResponse Subtract(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            FractionModel fraction1 = new FractionModel
            {
                Numerator = numerator1,
                Denominator = denominator1
            };

            FractionModel fraction2 = new FractionModel
            {
                Numerator = numerator2,
                Denominator = denominator2
            };

            FractionRequest fractionRequest = new FractionRequest
            {
                Fraction1 = fraction1,
                Fraction2 = fraction2
            };

            var request = new RestRequest("api/Fractions/Subtract", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(fractionRequest);

            var response = _client.Execute<FractionResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public FractionResponse Multiply(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            FractionModel fraction1 = new FractionModel
            {
                Numerator = numerator1,
                Denominator = denominator1
            };

            FractionModel fraction2 = new FractionModel
            {
                Numerator = numerator2,
                Denominator = denominator2
            };

            FractionRequest fractionRequest = new FractionRequest
            {
                Fraction1 = fraction1,
                Fraction2 = fraction2
            };

            var request = new RestRequest("api/Fractions/Multiply", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(fractionRequest);

            var response = _client.Execute<FractionResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public FractionResponse Divide(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            FractionModel fraction1 = new FractionModel
            {
                Numerator = numerator1,
                Denominator = denominator1
            };

            FractionModel fraction2 = new FractionModel
            {
                Numerator = numerator2,
                Denominator = denominator2
            };

            FractionRequest fractionRequest = new FractionRequest
            {
                Fraction1 = fraction1,
                Fraction2 = fraction2
            };

            var request = new RestRequest("api/Fractions/Divide", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(fractionRequest);

            var response = _client.Execute<FractionResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public FractionResponse Power(int numerator, int denominator, int power)
        {
            FractionModel fraction = new FractionModel
            {
                Numerator = numerator,
                Denominator = denominator
            };

            FractionPowerRequest fractionRequest = new FractionPowerRequest
            {
                Fraction = fraction,
                Power = power
            };

            var request = new RestRequest("api/Fractions/Power", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(fractionRequest);

            var response = _client.Execute<FractionResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }
    }
}