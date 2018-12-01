using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Passport
    {
        [Display(Name = "Номер")]
        public int PassportNum { get; set; }

        [Display(Name = "Серия")]
        public string PassportSeries { get; set; }
    }
}