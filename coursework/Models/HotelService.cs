﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class HotelService
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}