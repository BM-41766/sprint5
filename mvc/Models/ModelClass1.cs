using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace facebook1.Models
{
    public class ModelClass1
    {
        public string name = "";
        public string pwd = "";
        public string X_emailaddress
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string X_paswrd
        {
            get
            {
                return pwd;
            }
            set
            {
                pwd = value;
            }
        }
        string msg;
        public string login()
        {
            try
            {
                ServiceReference1.Service1Client sc1 = new ServiceReference1.Service1Client();
                msg = sc1.login(X_emailaddress, X_paswrd);
                //return msg;
            }
            catch (Exception ex)
            {
                //errorloginfile.SendError(ex);
            }
            return msg;
        }
        public string fname = "";
        public string sname = "";
        public string email = "";
        public string pswrd = "";
        public string proflpic = "";
        public string dy = "";
        public string mnth = "";
        public string yer = "";
        public string gndr = "";
        public string X_frstname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }
        public string X_srname
        {
            get
            {
                return sname;
            }
            set
            {
                sname = value;
            }
        }
        public string X_emailadress
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string X_pawrd
        {
            get
            {
                return pswrd;
            }
            set
            {
                pswrd = value;
            }
        }
        public string proflepic
        {
            get
            {
                return proflpic;
            }
            set
            {
                proflpic = value;
            }
        }

        public string X_day
        {
            get
            {
                return dy;
            }
            set
            {
                dy = value;
            }
        }
        public string X_month
        {
            get
            {
                return mnth;
            }
            set
            {
                mnth = value;
            }
        }
        public string X_year
        {
            get
            {
                return yer;
            }
            set
            {
                yer = value;
            }
        }
        public string X_gendr
        {
            get
            {
                return gndr;
            }
            set
            {
                gndr = value;
            }
        }

        public string signup(string profpic)
        {

            string msge;
            ServiceReference1.Service1Client sr = new ServiceReference1.Service1Client();
            DateTime DT_dob = Convert.ToDateTime(X_day + "/" + X_month + "/" + X_year);
            msge = sr.signupMethod(X_frstname, X_srname, X_emailadress, X_pawrd, profpic, DT_dob, X_gendr);
            return msge;
        }
       
        // public string finame = "";
        // public string X_firstname
        //{
        // get
        //  {
        // return finame;
        //  }
        // set
        //  {
        //   finame = value;
        //   }
        // }
        //public string search()
        //{
        //string m1;
        //    ServiceReference1.Service1Client sr1 = new ServiceReference1.Service1Client();
        //     m1 = sr1.searching(X_firstname);
        //    return m1;
        // }
        

    }
    public class friendserch
    {
        public string loginid { get; set; }
        public string X_firstname { get; set; }
        public string X_surname { get; set; }
        public string emailaddress { get; set; }
        public string profilepic { get; set; }
       
    }
}