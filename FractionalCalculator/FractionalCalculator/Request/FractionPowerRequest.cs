using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FractionalCalculator.Models;

namespace FractionalCalculator.Request
{
    public class FractionPowerRequest
    {
        [Required]
        public FractionModel Fraction { get; set; }
        [Required]
        public int Power { get; set; }
    }
}