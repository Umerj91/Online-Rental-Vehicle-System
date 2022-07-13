using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRentalVehicleSystem.Models
{
    public class Buyer
    {
        
        public string name { get; set; }
        public string cnic { get; set; }
        public string address { get; set; }
        public DateTime hiredate { get; set; }
        public DateTime returndate { get; set; }
        public string time { get; set; }
        public string uid { get; set; }
        public string carid { get; set; }
        public string paymentmethod { get; set; }
        public int amount { get; set; }


    }
}