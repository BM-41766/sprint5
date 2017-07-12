using facebook1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace facebook1.Controllers
{
    public class oldHomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("Index");
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Index(ModelClass1 mc, string cmd, HttpPostedFileBase img1,string X_emailaddress, string X_paswrd)
        {
            if (cmd == "Login")
            {
                ServiceReference1.Service1Client sc1 = new ServiceReference1.Service1Client();
                string msg = sc1.login(X_emailaddress,X_paswrd);
                //string msg = mc.login();
                if (msg.Contains("Responce code:200"))
                {
                    return View("Homepage");
                }
                return Content("<script language='javascript'type='text/javascript'>alert('" + msg + "');</script>");
                //return View(mc);

            }


            if (cmd == "create an account")
            {
                int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int year = Convert.ToInt32(mc.X_year);
                int age = currentYear - year;
                if (age >= 13)
                {
                    if (img1 != null && img1.ContentLength > 0)
                    {
                        string path = Path.Combine(Server.MapPath("~/profileimgs"),
                                                   Path.GetFileName(img1.FileName));
                        img1.SaveAs(path);
                        string msgg = mc.signup(path);
                    }
                    // return Content("<script language='javascript'type='text/javascript'>alert('" + msgg + "');</script>");
                    return View("Vpage");
                }

            }
            return null;
        }
        ServiceReference1.Service1Client sr1 = new ServiceReference1.Service1Client();
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Homepage(ModelClass1 mc, string X_firstname, string cmd1)
        {
            if (cmd1 == "s")
            {
               //string m1;
               //m1 = sr1.searching(X_firstname);
                //SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
                //CONN.Open();
                //SqlCommand CMD = CONN.CreateCommand();
                //CMD.CommandText = "select loginid,firstname,surname,profilepic,emailaddress from Userloggin where firstname like'" + X_firstname + "'";
                //SqlDataReader sdr = CMD.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);
                 
                //List<friendserch> lst = new List<friendserch>();
                //foreach(DataRow row in dt.Rows)
                //{
                //   friendserch lst1=new friendserch()
                //   {
                //       loginid = row["loginid"].ToString(),
                //       X_firstname = row["firstname"].ToString(),
                //       X_surname = row["surname"].ToString(),
                //       profilepic = row["profilepic"].ToString(),
                //       emailaddress=row["emailaddress"].ToString()
                       
                //   };
                //   lst.Add(lst1);
                //}
                //return View("Homepage", lst);
                return View("Homepage");
                
            }
            return null;

        }

    public string getfriends(string name)
        {
            string str =sr1.searching(name);
            return str;
        }
        public String getuser()
    {
        return "hi";
    }
    }
}
