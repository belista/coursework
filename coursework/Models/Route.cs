using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Route
    {
        #region Fields
        public int Id { get; set; }
        
        [Display(Name = "Город")]
        public string City { get; set; }
        
        [Display(Name = "Маршрут")]
        public string Itinerary { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Display(Name = "Стоимость полета")]
        public int CostOfFlight { get; set; }
        
        [Display(Name = "Комиссия за перевод")]
        public int TransferFee { get; set; }
        
        [Display(Name = "Длительность")]
        public int Duration { get; set; }
        #endregion

        #region Relationship
        public List<Voucher> Vouchers { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
        #endregion
    }
}