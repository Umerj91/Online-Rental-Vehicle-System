using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineRentalVehicleSystem.Models
{
    public class User
    {
        [Display(Name = "User Id")]
        public string userid { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        public string email { get; set; }
        // ------------------------
        [Required(ErrorMessage = "Enter Age")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        //------------
         [Required(ErrorMessage = "Enter City")]
        [Display(Name = "City")]
        public string city { get; set; }
        //-------------------
         [Required(ErrorMessage = " Enter Correct CNIC-14 Digit")]
        [Display(Name = "CNIC")]
        
        public string cnic { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm  Password")]
        [Required]
        [Compare("password", ErrorMessage = "The  password and confirmation  password  do  not  match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string ImageType { get; set; }
        public string Image { get; set; }

        [Required]
        [Display(Name = "Upload  Photo")]
        public HttpPostedFileBase FileAttachment { get; set; }
        
    }
}