using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.IO;
using OnlineRentalVehicleSystem.Models;
namespace OnlineRentalVehicleSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        string status = "";
        public ActionResult SignUp()
        {
           
            return View();
        }

        //static string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        static string constr = " Data Source=DESKTOP-6SEK5AN;Initial Catalog=carrentalsystem;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            
            if (ModelState.IsValid)
            {
               

                    BinaryReader br = new BinaryReader(u.FileAttachment.InputStream);
                    u.Image = Convert.ToBase64String(br.ReadBytes(u.FileAttachment.ContentLength));
                    u.ImageType = u.FileAttachment.ContentType;

                    string uid = u.email.Split('@')[0].ToString();
                    ViewBag.Uid = uid;
                    con.Open();

                    string q = "insert into users values ('" + uid + "', '" + u.firstname + "', '" + u.lastname + "', '" + u.email + "','" + u.Age + "','" + u.city + "','" + u.cnic + "','" + u.password + "','" + u.ImageType + "','" + u.Image + "')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                
               
                    return View();
            }
            return View();

        }

        public ActionResult SignIn()
        {
            if (Session["uid"] != null && Session["uname"] != null)
            {
                return RedirectToAction("UserMenuPage");
            }
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User u)
        {
            con.Open();
            string q = "select userid,fname+' '+lname as username,imagetype,image from users where userid = '" + u.userid + "' and passwrord = '" + u.password + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {

                Session["uid"] = sdr["userid"].ToString();//user.id
                Session["uname"] = sdr["username"].ToString();//user.name
                Session["imagetype"] = sdr["imagetype"].ToString();
                Session["image"] = sdr["image"].ToString();
                
            }
            else
            {
                Response.Write("<script>alert('Invalid User or Password');</script>");
            }
            sdr.Close();
            con.Close();
            return RedirectToAction("UserMenuPage");
        }

        public ActionResult UserMenuPage()
        {
            if (Session["uid"] != null && Session["uname"] != null)
            {

                return View();
            }

            return RedirectToAction("SignIn");
        }

        public ActionResult logout()
        {

            Session.RemoveAll();

            return RedirectToAction("SignIn");
        }
        
        public ActionResult AdminSignIn()
        {
            if (Session["adminid"] != null && Session["uname"] != null)
            {
                return RedirectToAction("AdminUserMenuPage");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AdminSignIn(Admin u)
        {
            con.Open();
            string q = "select aid,fname+' '+lname as Adminname,imagetype,image from admins where aid = '" + u.adminid + "' and passwrord = '" + u.password + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {

                Session["adminid"] = sdr["aid"].ToString();//user.id
                Session["uname"] = sdr["adminname"].ToString();//user.name
                Session["imagetype"] = sdr["imagetype"].ToString();
                Session["image"] = sdr["image"].ToString();

            }
            else
            {
                Response.Write("<script>alert('Invalid User or Password');</script>");
            }
            sdr.Close();
            con.Close();
            return RedirectToAction("AdminUserMenuPage");
        }

        public ActionResult AdminUserMenuPage()
        {
            if (Session["adminid"] != null && Session["uname"] != null)
            {

                return View();
            }

            return RedirectToAction("AdminSignIn");
        }

        public ActionResult adminlogout()
        {

            Session.RemoveAll();

            return RedirectToAction("AdminSignIn");
        }

    }
}