using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FractionalCalculator.Client;
using FractionalCalculator.Helpers;
using FractionalCalculator.Models;

namespace FractionalCalculator.Controllers
{
    public class HomeController : Controller
    {
        private FractionalCalculator.Helpers.IExpressionHelper _helper;

        public HomeController()
        {
            _helper = new Helpers.ExpressionHelper();
        }

        public HomeController(IExpressionHelper helper)
        {
            _helper = helper;
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ExpressionModel model = new ExpressionModel();
            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Index([FromBody] ExpressionModel model)
        {
            try
            {
                model.Result = _helper.ParseExpression(model.Expression);
            }
            catch (Exception exception)
            {
                model.Result = exception.Message;
            }
            ModelState.Clear();
            return View(model);
        }
    }
}
