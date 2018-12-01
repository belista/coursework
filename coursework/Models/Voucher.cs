using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Voucher
    {
        #region Fields
        public int Id { get; set; }

        [Display(Name = "Стоимость путевки")]
        public int Cost { get; set; }

        [Display(Name = "Дата начала")]
        public DateTimeOffset Start { get; set; }

        [Display(Name = "Дата окончания")]
        public DateTimeOffset Ending { get; set; }
        #endregion

        #region Relationship
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int TouristId { get; set; }

        public Tourist Tourist { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }
        #endregion
    }
}