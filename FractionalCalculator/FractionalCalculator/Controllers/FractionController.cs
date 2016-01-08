using System;
using System.Web.Http;
using System.Web.Http.Description;
using FractionalCalculator.Mappers;
using FractionalCalculator.Request;
using FractionalCalculator.Response;
using FractionalCalculator.Services;

namespace FractionalCalculator.Controllers
{
    [RoutePrefix("api/Fractions")]
    public class FractionController : ApiController
    {
        private readonly IOperationsService _service;

        public FractionController()
        {
            _service = new OperationsService();
        }

        public FractionController(IOperationsService service)
        {
            _service = service;
        }

        // POST api/values
        [Route("Add")]
        [HttpPost]
        [ResponseType(typeof(FractionResponse))]
        public IHttpActionResult Add([FromBody]FractionRequest request)
        {
            try
            {
                var fraction = _service.Add(FractionMapper.Map(request.Fraction1), FractionMapper.Map(request.Fraction2));
                return Ok(new FractionResponse {Fraction = FractionMapper.Map(fraction)});
            }
            catch (FractionException exception) when (exception.Message == "Result is NaN as Denominator is 0.")
            {
                return InternalServerError(exception);
            }
            catch (FractionException exception) when (exception.Message == "Fraction is NaN as Denominator is 0.")
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [Route("Subtract")]
        [HttpPost]
        [ResponseType(typeof(FractionResponse))]
        public IHttpActionResult Subtract([FromBody]FractionRequest request)
        {
            try
            {
                var fraction = _service.Sub(FractionMapper.Map(request.Fraction1), FractionMapper.Map(request.Fraction2));
                return Ok(new FractionResponse {Fraction = FractionMapper.Map(fraction)});
            }
            catch (FractionException exception) when (exception.Message == "Result is NaN as Denominator is 0.")
            {
                return InternalServerError(exception);
            }
            catch (FractionException exception) when (exception.Message == "Fraction is NaN as Denominator is 0.")
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [Route("Multiply")]
        [HttpPost]
        [ResponseType(typeof(FractionResponse))]
        public IHttpActionResult Multiply([FromBody]FractionRequest request)
        {
            try
            {
                var fraction = _service.Mul(FractionMapper.Map(request.Fraction1), FractionMapper.Map(request.Fraction2));
                return Ok(new FractionResponse {Fraction = FractionMapper.Map(fraction)});
            }
            catch (FractionException exception) when (exception.Message == "Result is NaN as Denominator is 0.")
            {
                return InternalServerError(exception);
            }
            catch (FractionException exception) when (exception.Message == "Fraction is NaN as Denominator is 0.")
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [Route("Divide")]
        [HttpPost]
        [ResponseType(typeof(FractionResponse))]
        public IHttpActionResult Divide([FromBody]FractionRequest request)
        {
            try
            {
                var fraction = _service.Div(FractionMapper.Map(request.Fraction1), FractionMapper.Map(request.Fraction2));
                return Ok(new FractionResponse {Fraction = FractionMapper.Map(fraction)});
            }
            catch (FractionException exception) when (exception.Message == "Result is NaN as Denominator is 0.")
            {
                return InternalServerError(exception);
            }
            catch (FractionException exception) when (exception.Message == "Fraction is NaN as Denominator is 0.")
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [Route("Power")]
        [HttpPost]
        [ResponseType(typeof(FractionResponse))]
        public IHttpActionResult Power([FromBody]FractionPowerRequest request)
        {
            try
            {
                var fraction = _service.Pow(FractionMapper.Map(request.Fraction), request.Power);
                return Ok(new FractionResponse {Fraction = FractionMapper.Map(fraction)});
            }
            catch (FractionException exception) when (exception.Message == "Result is NaN as Denominator is 0.")
            {
                return InternalServerError(exception);
            }
            catch (FractionException exception) when (exception.Message == "Fraction is NaN as Denominator is 0.")
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
    }
}
