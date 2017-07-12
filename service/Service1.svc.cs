using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace myservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void DoWork()
        {

        }
        public string login(string X_emailaddress, string X_password)
        {
            SqlConnection CON = new SqlConnection(@"Data Source=DESKTOP-GGK19TE\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");

            CON.Open();
            SqlCommand CMD = CON.CreateCommand();
            CMD.CommandText = "select * from Userloggin where emailaddress='" + X_emailaddress + "'and password='" + X_password + "'";
            SqlDataReader sdr = CMD.ExecuteReader();
            userlogin login = new userlogin();
            login.emailaddress = X_emailaddress;
            login.password = X_password;
            try
            {
                while (sdr.Read())
                {
                    if ((login.emailaddress.Equals(sdr["emailaddress"].ToString())) && (login.password.Equals(sdr["password"].ToString())))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["surname"].ToString();
                        login.emailaddress = sdr["emailaddress"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "\"loginid:\" " + login.X_loginid + "   \"emailaddress:\" " + login.emailaddress + "       \"firstname:\" " + login.firstname + "        \"surname:\" " + login.lastname + "        \"profilepic:\" " + login.profilepic + "    \"Responce code:200      Msg:Sucess\" ";
                        return str;

                    }
                    else if ((login.emailaddress.Equals(sdr["emailaddress"].ToString())) || (login.password.Equals(sdr["password"].ToString())))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["surname"].ToString();
                        login.emailaddress = sdr["emailaddress"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "\"emailaddress:\" " + login.emailaddress + "   \"profilepic:\" " + login.profilepic + "    \"Responce code:500   Msg:password incorrect\" ";
                        return str;

                    }
                    else if (!(login.emailaddress.Equals(sdr["emailaddress"].ToString())) && (!(login.password.Equals(sdr["password"].ToString()))))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["surname"].ToString();
                        login.emailaddress = sdr["emailaddresss"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "    \"Responce code:404    Msg:Email id doesnot exit\" ";
                        return str;

                    }


                }
            }
            catch (Exception ex)
            {
                //errorloginfile.SendError(ex);

            }


            // CON.Close();
            // CMD.Dispose();
            return null;
        }

        public string signupMethod(string X_firstname, string X_surname, string X_emailaddress, string X_password, string proflepic, DateTime DT_dob, string X_gender)
        {
            SqlConnection CNN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            string STR;
            CNN.Open();
            signup sign = new signup();
            sign.firstname = X_firstname;
            sign.surname = X_surname;
            sign.emailadress = X_emailaddress;
            sign.password = X_password;
            sign.proflepic = proflepic;
            sign.DT_dob = DT_dob;
            sign.gender = X_gender;
            STR = "insert into Userloggin(firstname,surname,profilepic,emailaddress,password,dob,gender,accountstatus) values('" + sign.firstname + "','" + sign.surname + "','" + sign.proflepic + "','" + sign.emailadress + "','" + sign.password + "','" + sign.DT_dob + "','" + sign.gender + "',0)";
            SqlCommand COD = new SqlCommand(STR, CNN);
            int res = COD.ExecuteNonQuery();
            COD.Dispose();
            CNN.Close();
            if (res > 0)
            {
                mailservice();
                return "success";
            }
            else
            {
                return "false";
            }


        }
        public void mailservice()
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("harishmahari1502@gmail.com");
            msg.To.Add("harishmahari1502@gmail.com");
            msg.Subject = "verification";
            msg.Body = "Welcome to facebook";
            msg.IsBodyHtml = true;
            //msg.Attachments.Add(new Attachment("C:\\Users\\ADMIN\\Desktop\\test.txt"));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("harishmahari1502@gmail.com", "8301ha0882ri");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);

            }
            catch (Exception ex)
            {


            }
        }
        public String searching(string X_firstname)
        {
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
           // CMD.CommandText = "select loginid,firstname,surname,profilepic from Userloggin where firstname like'" + X_firstname + "%'";
            CMD.CommandText = "select Userloggin.loginid,Userloggin.firstname,Userloggin.surname,Userloggin.profilepic,frndconfrm.relation,frndconfrm.senderid,frndconfrm.reciverid,frndconfrm.firstname,frndconfrm.surname,frndconfrm.profilepic from Userloggin left outer join frndconfrm on Userloggin.loginid=frndconfrm.reciverid where Userloggin.firstname like '" + X_firstname + "%' order by frndconfrm.reciverid desc";
            SqlDataReader sdr = CMD.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            string str = datatabletojson(dt);
            //str.Replace("\\", "");
            return str;
            /*SqlCommand cmd = new SqlCommand("select * from userlogin where firstname Like '%'+@Name+'%'", CONN);
            cmd.Parameters.AddWithValue("@Name", X_firstname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);*/
            //SqlCommand CAMD = new SqlCommand("select * from userlogin where firstname='" + X_firstname + "'",CONN);
            //CAMD.CommandText = "select * from userlogin where firstname='" + X_firstname + "'";
            //SqlDataAdapter da = new SqlDataAdapter(CAMD);
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            //SqlDataAdapter da = new SqlDataAdapter(sld);
            /* DataTable dt = new System.Data.DataTable();
             da.Fill(dt);*/

            /*string frstname = sdr["firstname"].ToString();
             string srname = sdr["surname"].ToString();
             string prfpic = sdr["profilepic"].ToString();
             string emailadres = sdr["emailaddress"].ToString();*/
            //string str= "firstname:" +frstname+ "surname:" +srname+ "profilepic:" +prfpic+ "emailaddress:" +emailadres+
            // return null;
            //return sdr.ToString();

        }
        public string datatabletojson(DataTable table)
        {
            return JsonConvert.SerializeObject(table);
        }
        string str;

        public void getlogindetails(string X_emailaddress, string X_password,out  string tempvar, out string X_loginid,out string fname,out string surname,out string proficpic)
        {
            tempvar = "";
            X_loginid = "";
            fname = "";
            surname = "";
            proficpic = "";
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "select loginid,firstname,surname,profilepic from Userloggin where emailaddress='" + X_emailaddress + "'and password='" + X_password + "'";
            SqlDataReader sdr = CMD.ExecuteReader();
            while (sdr.Read())
            {
                X_loginid = sdr["loginid"].ToString();
                fname = sdr["firstname"].ToString();
                surname = sdr["surname"].ToString();
                proficpic = sdr["profilepic"].ToString();
            }


        }
        string fnmae;
        string surname;
        string profpic;
        public void addfriend(string  reciverid, string senderid)
        {
            int N_loginid = Convert.ToInt32(senderid);
            int id = Convert.ToInt32(reciverid);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText=("update Userloggin set accountstatus=2 where loginid=" + N_loginid);
            CMD.ExecuteNonQuery();
            CONN.Close();
            CONN.Open();
            CMD.CommandText= "select firstname,surname,profilepic from Userloggin where loginid=" + id ;
            SqlDataReader sdr = CMD.ExecuteReader();
            while (sdr.Read())
            {
                fnmae = sdr["firstname"].ToString();
                surname = sdr["surname"].ToString();
                profpic = sdr["profilepic"].ToString();
            }
            sdr.Close();
            CMD.CommandText="insert into frndconfrm(N_loginid,relation,status,senderid,reciverid,firstname,surname,profilepic)values('" +N_loginid+ "','" + 0 + "','" + "" + "','" + N_loginid + "','" + id + "','" + fnmae + "','" + surname + "','" + profpic + "')";
            CMD.ExecuteNonQuery();
        }
        public string frndapproval(string reciverId,string senderId)
        {
            int reviver = Convert.ToInt32(reciverId);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "select Userloggin.loginid,Userloggin.firstname,Userloggin.surname,Userloggin.profilepic,frndconfrm.relation,frndconfrm.status from Userloggin left outer join frndconfrm on frndconfrm.reciverid=" + reviver + " where Userloggin.loginid=frndconfrm.senderid order by frndconfrm.reciverid desc";
            SqlDataReader sdr = CMD.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            string str = datatabletojson(dt);
            return str;
        }
       public void confrm(string reciverid, string senderid)

        {
            int N_loginid = Convert.ToInt32(senderid);
            int id = Convert.ToInt32(reciverid);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "update frndconfrm set relation=1 where senderid="+N_loginid+"and reciverid="+id;
            CMD.ExecuteNonQuery();
            confrmationmail(reciverid);
            
        }
       string name,sname,propic;
        public void confrmationmail(string reciverid)
       {
           int reciver = Convert.ToInt32(reciverid);
           SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
           CONN.Open();
           SqlCommand CMD = CONN.CreateCommand();
           CMD.CommandText = "select firstname,surname,profilepic from Userloggin where loginid=" + reciver;
           SqlDataReader sdr = CMD.ExecuteReader();
            while(sdr.Read())
            {
                name = sdr["firstname"].ToString();
                sname = sdr["surname"].ToString();
                propic = sdr["profilepic"].ToString();
            }
           MailMessage msg = new MailMessage();
           msg.From = new MailAddress("harishmahari1502@gmail.com");
           msg.To.Add("harishmahari1502@gmail.com");
           msg.Subject = "conformation mail";
           msg.Body = "'"+name+"','"+sname+"','"+propic+"' wants to be friends on facebook ";
           msg.IsBodyHtml = true;
           SmtpClient smtp = new SmtpClient();
           smtp.Host = "smtp.gmail.com";
           smtp.Credentials = new NetworkCredential("harishmahari1502@gmail.com", "8301ha0882ri");
           smtp.EnableSsl = true;
           try
           {
               smtp.Send(msg);

           }
           catch (Exception ex)
           {


           }
       }
        public void delete(string reciverid,string senderid)
        {
            int recid = Convert.ToInt32(reciverid);
            int senid = Convert.ToInt32(senderid);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "delete from frndconfrm where reciverid=" + recid+"and senderid="+senid;
            CMD.ExecuteNonQuery();
        }
        public string frndserch(string loginid)
        {
            int nloginid = Convert.ToInt32(loginid);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "select Userloggin.loginid,Userloggin.firstname,Userloggin.surname,Userloggin.profilepic,frndconfrm.relation,frndconfrm.senderid,frndconfrm.reciverid,frndconfrm.firstname,frndconfrm.surname,frndconfrm.profilepic from Userloggin left outer join frndconfrm on Userloggin.loginid=frndconfrm.reciverid where frndconfrm.reciverid=" + loginid + " order by frndconfrm.reciverid  desc";
            SqlDataReader sdr = CMD.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            string str = datatabletojson(dt);
            return str;
        }
        public void unfrnd(string reciverid, string senderid)
        {
            int recid = Convert.ToInt32(reciverid);
            int senid = Convert.ToInt32(senderid);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "delete from frndconfrm where reciverid=" + recid + "and senderid=" + senid;
            CMD.ExecuteNonQuery();
        }
        string f1, s1, profpic1;
        public string posting(string loginid,string posting1)
        {
            int id = Convert.ToInt32(loginid);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "select firstname,surname,profilepic from Userloggin where loginid=" + id;
            CMD.ExecuteNonQuery();
            SqlDataReader sdr = CMD.ExecuteReader();
            while (sdr.Read())
            {
                f1 = sdr["firstname"].ToString();
                s1 = sdr["surname"].ToString();
                profpic1 = sdr["profilepic"].ToString();
            }
            sdr.Close();
            CMD.CommandText = "insert into posting(loginid,firstname,surname,profilepic,postingstatus)values('" + id + "','" + f1 + "','" + s1 + "','" + profpic1 + "','" + posting1 + "')";
            CMD.ExecuteNonQuery();
            CONN.Close();
            CONN.Open();
            CMD = CONN.CreateCommand();
            CMD.CommandText = "select postingid,loginid,firstname,surname,profilepic,postingstatus from posting where loginid=" + id + " order by postingid desc";
            sdr = CMD.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            string str = datatabletojson(dt);
            return str;
        }
     
 public String postingimge(string loginid,string postingimg,string header)
        {
            int id = Convert.ToInt32(loginid);
            SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            CONN.Open();
            SqlCommand CMD = CONN.CreateCommand();
            CMD.CommandText = "select firstname,surname,profilepic from Userloggin where loginid=" + id;
            CMD.ExecuteNonQuery();
            SqlDataReader sdr = CMD.ExecuteReader();
            while (sdr.Read())
            {
                f1 = sdr["firstname"].ToString();
                s1 = sdr["surname"].ToString();
                profpic1 = sdr["profilepic"].ToString();
            }
            sdr.Close();
            CMD.CommandText="insert into posting(loginid,firstname,surname,profilepic,postingimage,postingheader)values("+id+",'"+f1+"','"+s1+"','"+profpic1+"','"+postingimg+"','"+header+"')";
            CMD.ExecuteNonQuery();
            //CMD.CommandText = "insert into posting(loginid,firstname,surname,profilepic,postingimage,postingheader)values(" + id + ",'" + f1 + "','" + s1 + "','" + profpic1 + "','" + postingimg + "','" + header + "')";
            //CMD.ExecuteNonQuery();
            CONN.Close();
            CONN.Open();
            CMD = CONN.CreateCommand();
            CMD.CommandText = "select loginid,firstname,surname,profilepic,postingimage,postingheader from posting where loginid=" + id + " order by postingid desc";
            sdr = CMD.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            string str = datatabletojson(dt);
            return str;
        }


   }    
}