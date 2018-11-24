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
        
        public string City { get; set; }
        
        public string Itinerary { get; set; }

        public string Description { get; set; }
        
        public int CostOfFlight { get; set; }
        
        public int TransferFee { get; set; }
        
        public int Duration { get; set; }
        #endregion

        #region Relationship
        public List<Voucher> Vouchers { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
        #endregion
    }
}