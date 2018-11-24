using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Hotel
    {
        public Hotel()
        {
            HotelServices = new List<HotelService>();
        }

        #region Fields
        public int Id { get; set; }
        
        public string City { get; set; }
        
        public string Name { get; set; }

        public string Status { get; set; }
        
        public int RoomRate { get; set; }
        #endregion

        #region Relationship
        public int CountryId { get; set; }

        public Country Country { get; set; }


        public List<HotelService> HotelServices { get; set; }

        public List<Route> Routes { get; set; }
        #endregion
    }
}