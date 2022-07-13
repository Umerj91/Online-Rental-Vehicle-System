using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OnlineRentalVehicleSystem.Models;
using System.Data.SqlClient;
//using PagedList;
namespace OnlineRentalVehicleSystem.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult CarEntry()
        {

            return View();
        }
        static string constr = " Data Source=DESKTOP-6SEK5AN;Initial Catalog=carrentalsystem;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);

        [HttpPost]
        public ActionResult CarEntry(Car c)
        {

            if (ModelState.IsValid)
            {
                var allowedExtensions = new[] { ".bmp", ".png", ".jpg", ".gif" };

                var ext = Path.GetExtension(c.FileAttachment.FileName);

                //getting  the  extension(ex-.jpg)
                if (allowedExtensions.Contains(ext))  //check  what  type of  extension
                {
                    //~/Images  is  relative  path  for  images  in  root  directory
                    var path = Path.Combine(Server.MapPath("~/Images"), c.FileAttachment.FileName);
                    c.Image = "~/Images/" + c.FileAttachment.FileName;
                    //saving  photo  of  employee  in  the  image  folder
                    //  file.SaveAs  Saves  the  contents  of  an  uploaded  file  to  a  specified path on the Web server.
                    c.FileAttachment.SaveAs(path);
                    c.ImageType = ext;

                }
                else
                {
                    ViewBag.message = "Please  choose  only  Image  file";
                    return View(c);
                }

                con.Open();

                string q = "insert into car values ('" + c.carid + "', '" + c.carname + "', '" + c.cartype + "', '" + c.Etype + "','" + c.Rcity + "','" + c.Myear + "','" + c.ImageType + "','" + c.Image + "','"+c.rent+"')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //return View(c);
                return RedirectToAction("CarRecords");
            }
            return View(c);
        }



        private List<Car> getCars(string cont, string SearchBy)
        {
            string constr = " Data Source=DESKTOP-6SEK5AN;Initial Catalog=carrentalsystem;Integrated Security=True";

            List<Car> alist = new List<Car>();
            SqlConnection con = new SqlConnection(constr);
            string q = "";
            con.Open();
            if (!String.IsNullOrEmpty(cont))
            {
                //q = "select * from books b inner join author a on a.aid=b.bid where "+ SearchBy + " like '"+ cont + "%'";
                q = "select carrid,cname,ctype,engine,rcity,myear,rent,image from Car where " + SearchBy + " like '" + cont + "%'";
            }
            else
            {
                //q = "select * from books b inner join author a on a.aid=b.bid ";
                q = "select carrid,cname,ctype,engine,rcity,myear,rent,image from Car";
            }

            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Car c = new Car();
                c.carid = sdr["carrid"].ToString();
                c.carname = sdr["cname"].ToString();
                c.cartype = sdr["ctype"].ToString();
                c.Etype = sdr["engine"].ToString();
                c.Rcity = sdr["rcity"].ToString();
                c.Myear = sdr["myear"].ToString();
                c.rent = int.Parse(sdr["rent"].ToString());
                
                c.Image = sdr["image"].ToString();
                alist.Add(c);
            }

            con.Close();
            return alist;
        }


        [HttpGet]
        public ActionResult CarRecords(string cont, string SearchBy, int? page)
        {
            List<Car> al = getCars(cont, SearchBy);
            return View(al);

        }


        [HttpGet]
        public ActionResult CarsList()
        {

            return View();

        }

        private Car SearchCar(string id)
        {

            string q = "Select carrid,cname,ctype,Engine,rcity,myear,image,rent from Car where carrid = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
                Car c = new Car();
                c.carid = sdr["carrid"].ToString();
                c.carname = sdr["cname"].ToString();
                c.cartype = sdr["ctype"].ToString();
                c.Etype = sdr["engine"].ToString();
                c.Rcity = sdr["rcity"].ToString();
                c.Myear = sdr["myear"].ToString();
                // c.Etype = sdr["engine"].ToString();
                c.Image = sdr["image"].ToString();
                c.rent = int.Parse(sdr["rent"].ToString());

            sdr.Close();
                con.Close();


                return c;
            }
        public ActionResult Search(string id)
        {

            return View(SearchCar(id));

        }

        public ActionResult Buy()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Buy(Buyer b)
        {
            con.Open();

            string q = "insert into Allocation(name,hiredate,returndate,address,cnic,time,userid,carrid,payment,amount) values ( '" + b.name + "', '" + b.hiredate + "', '" +b.returndate + "','" + b.address + "','"+b.cnic+"','"+b.time+"','"+b.uid+"','"+b.carid+"','"+b.paymentmethod+"','"+b.amount+"')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return View(); 

        }
      

    }
    }
