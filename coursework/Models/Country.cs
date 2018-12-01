using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Country
    {
        #region Fields
        public int Id { get; set; }
        
        [Display(Name = "Название страны")]
        public string Name { get; set; }
        #endregion

        #region Relationship
        public List<Hotel> Hotels { get; set; }
        #endregion
    }
}