using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace FormSendEmail
{
    public class Mail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string DoNotCall { get; set; }
        public string Industry { get; set; }
        public string LeadSource { get; set; }
        public string Description { get; set; }
    }

    public class BajadevMail : Page
    {

        private string XmlUri { get { return "~/MailList.xml"; } }

        private string To { get; set; }
        private string From { get; set; }
        private string CC { get; set; }
        private string Subject { get; set; }

        private XmlNodeList GetXMLNode(string fileRoute)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath(this.XmlUri));
            return xmlDoc.DocumentElement.SelectNodes(fileRoute);
        }

        public BajadevMail()
        {
            var nodeList = GetXMLNode("/Emails/email");
            foreach (XmlNode xmlNode in nodeList)
            {
                From = xmlNode.SelectSingleNode("from").InnerText;
                To = xmlNode.SelectSingleNode("to").InnerText;
                Subject = xmlNode.SelectSingleNode("subject").InnerText;
                CC = xmlNode.SelectSingleNode("cc").InnerText;
            }
        }

        public void SendMail(Mail dto)
        {
            string body = "";
            body += "<table style=\"width:100%;\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Nombre: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.FirstName + "&nbsp;" + "</td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Apellido: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.LastName + "</a></td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Tel&eacute;fono/Oficina/M&oacute;vil: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.Phone + "</td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Email: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; <a href=\"mailto:" + dto.Email + "\">" + dto.Email + "</a></td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Ciudad/Pa&iacute;s: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.City + "/" + dto.Country + "</td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&iquest;Desea recibir ofertas?: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.DoNotCall + "</td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Tipo de Proyecto: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.Industry + "</td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Como supo de nosotros?: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.LeadSource + "</td></tr>";
            body += "<tr><td align=\"left\" bgcolor=\"#F0F0F0\" style=\"width:23%; color: #06578E; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">Mensaje: </td><td style=\"width:77%; font-family: Arial, Helvetica, sans-serif; font-size: 12px; \">&nbsp; " + dto.Description + "</td></tr>";
            body += "</table>";


            var mailNew = new MailMessage(From, To, Subject, body);

            string[] toCopies = CC.Split(',');
            foreach (string toCopy in toCopies)
            {
                mailNew.CC.Add(new MailAddress(toCopy));
            }

            mailNew.Subject = Subject;
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