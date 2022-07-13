using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRentalVehicleSystem.Models;
using System.Data.SqlClient;
namespace OnlineRentalVehicleSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        static string constr = " Data Source=DESKTOP-6SEK5AN;Initial Catalog=carrentalsystem;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        private List<Buyer> getusers(string cont, string SearchBy)
        {
            List<Buyer> bList = new List<Buyer>();
            SqlConnection con = new SqlConnection(constr);
            string q = "";
            con.Open();
            if (!String.IsNullOrEmpty(cont))
            {

                q = "select name,hiredate,returndate,time,address,cnic,userid,carrid,payment,amount from allocation where " + SearchBy + " like '" + cont + "%'";
            }

            else
            {

                q = "select name,hiredate,returndate,time,address,cnic,userid,carrid,payment,amount from allocation ";

            }
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Buyer b = new Buyer();
                b.name = sdr["name"].ToString();
                b.hiredate = DateTime.Parse(sdr["hiredate"].ToString());
                b.returndate = DateTime.Parse(sdr["returndate"].ToString());
                b.time = sdr["time"].ToString();
                b.address = sdr["address"].ToString();
                b.cnic = sdr["cnic"].ToString();
                b.uid = sdr["userid"].ToString();
                b.carid = sdr["carrid"].ToString();
                b.paymentmethod = sdr["payment"].ToString();
                b.amount = int.Parse(sdr["amount"].ToString());
             
                bList.Add(b);
            }

            con.Close();
            return bList;
        }
    
        [HttpGet]
        public ActionResult ApplicantRecords(string cont, string SearchBy)
        {
            List<Buyer> al = getusers(cont,SearchBy);
            return View(al);

        }








    }
}