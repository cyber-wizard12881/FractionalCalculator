using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FractionalCalculator.Domain;
using FractionalCalculator.Models;

namespace FractionalCalculator.Request
{
    public class FractionRequest
    {
        [Required]
        public FractionModel Fraction1 { get; set; } 
        [Required]
        public FractionModel Fraction2 { get; set; }
    }
}