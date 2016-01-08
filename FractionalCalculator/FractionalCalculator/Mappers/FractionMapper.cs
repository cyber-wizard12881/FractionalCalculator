using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FractionalCalculator.Domain;
using FractionalCalculator.Models;

namespace FractionalCalculator.Mappers
{
    public class FractionMapper
    {
        public static Fraction Map(FractionModel model)
        {
            return new Fraction(model.Numerator, model.Denominator);
        }

        public static FractionModel Map(Fraction domain)
        {
            return  new FractionModel
            {
                Numerator = domain.Numerator,
                Denominator = domain.Denominator
            };
        }
    }
}