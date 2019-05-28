using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace FormSendEmail
{
    
    public partial class Form : System.Web.UI.Page
    {      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public XmlNodeList GetXML(string file, string fileRoute)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath(file));
            return xmlDoc.DocumentElement.SelectNodes(fileRoute);
        }

        protected void sendRequest_Click(object sender, EventArgs e)
        {
            string to = string.Empty, subject = string.Empty, cc = string.Empty, from = string.Empty;

            string _name = Request.Form["first_name"] + " " + Request.Form["last_name"];
            string _phone = Request.Form["phone"];
            string _email = Request.Form["email"];
            string _city = Request.Form["city"];
            string _country = Request.Form["country"];
            string _doNotCall = Request.Form["doNotCall"];
            string _industry = Request.Form["industry"];
            string _leadSource = Request.Form["lead_source"];
            string _description = Request.Form["description"];

           XmlNodeList list = GetXML("~/MailList.xml", "/Emails/emails");
       

            foreach (XmlNode xmlNode in list)
            {
                from = xmlNode.SelectSingleNode("from").InnerText;
                to = xmlNode.SelectSingleNode("to").InnerText;
                cc = xmlNode.SelectSingleNode("cc").InnerText;
                subject = xmlNode.SelectSingleNode("subject").InnerText;
            }

            string body = "";
            var mailNew = new MailMessage(from, to, subject, body);

            string[] toCopies = cc.Split(',');
            foreach (string toCopy in toCopies)
            {
                mailNew.CC.Add(new MailAddress(toCopy));
            }

            mailNew.Subject = subject;
            mailNew.Body = body;
            mailNew.IsBodyHtml = true;
            mailNew.Priority = MailPriority.High;

            var ss = new SmtpClient
            {
                Host = "smtpout.secureserver.net",
                Port = 3535, // https://mx.godaddy.com/help/what-do-i-do-if-i-have-trouble-connecting-to-my-email-account-319
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("no-reply@securepaycc.com", "123456")
            };

            ss.Send(mailNew);
        }
    }
}