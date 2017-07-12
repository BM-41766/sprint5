using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace myservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        string login(string X_emailaddress, string X_password);
        [OperationContract]
        string signupMethod(string X_firstname, string X_surname, string X_emailaddress, string X_password, string proflepic, DateTime DT_dob, string X_gender);
        [OperationContract]
        String searching(string X_firstname);
        [OperationContract]
        void getlogindetails(string X_emailaddress, string X_password ,out string tempvar,out  string X_loginid,out string fname,out string surname,out string proficpic);
        [OperationContract]
        void addfriend(string reciverid, string senderid);
        [OperationContract]
        string frndapproval(string reciverId, string senderId);
        [OperationContract]
        void confrm(string reciverid, string senderid);
        [OperationContract]
        void delete(string reciverid, string senderid);
        [OperationContract]
        string frndserch(string loginid);
        [OperationContract]
        void unfrnd(string reciverid, string senderid);
        [OperationContract]
        string posting(string loginid,string posting1);
        [OperationContract]
        String postingimge(string loginid, string postingimg, string header);

    }
    public class userlogin
    {
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public string profilepic { get; set; }
        [DataMember]
        public string emailaddress { get; set; }
        [DataMember]
        public int loginid { get; set; }
        [DataMember]
        public string X_loginid { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string password { get; set; }
    }
    public class signup
    {
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string surname { get; set; }
        [DataMember]
        public string emailadress { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string proflepic { get; set; }
        [DataMember]
        public DateTime DT_dob { get; set; }
        [DataMember]
        public string gender { get; set; }
    }

}