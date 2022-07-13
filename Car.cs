using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineRentalVehicleSystem.Models
{
    public class Car
    {
        [Display(Name = "Car Id")]
        public string carid { get; set; }

        [Required(ErrorMessage = "Enter Car Name")]
        [Display(Name = "Car Name")]
        public string carname { get; set; }

        [Required(ErrorMessage = "Car Type")]
        [Display(Name = "Enter Car Type")]
        public string cartype { get; set; }

        [Required(ErrorMessage = "Enter Engine Type")]
        [Display(Name = "Engine")]
        public string Etype { get; set; }

        [Required(ErrorMessage = "Enter Registered City")]
        [Display(Name = "City")]
        public string Rcity { get; set; }

        [Required(ErrorMessage = "Enter Model Year")]
        [Display(Name = "Year")]
        public string Myear { get; set; }

        
        public string ImageType { get; set; }
        public string Image { get; set; }

        [Required]
        [Display(Name = "Upload  Photo")]
        public HttpPostedFileBase FileAttachment { get; set; }
        public int rent { get; set; }
    }
}