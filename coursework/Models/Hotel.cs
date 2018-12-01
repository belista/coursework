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
        
        [Display(Name = "Город отеля")]
        public string City { get; set; }
        
        [Display(Name = "Название отеля")]
        public string Name { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }
        
        [Display(Name = "Стоимость проживания")]
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