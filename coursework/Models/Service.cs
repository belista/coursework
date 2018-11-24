using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Service
    {
        public Service()
        {
            HotelServices = new List<HotelService>();
        }

        #region Fields
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Cost { get; set; }
        #endregion

        #region Relationship
        public List<HotelService> HotelServices { get; set; }
        #endregion
    }
}