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


        protected void SendRequest_Click(object sender, EventArgs e)
        {
            string _doNotCall = Request.Form["doNotCall"];

            if (_doNotCall == null)            
                _doNotCall = "No";            
            else
            {
                if (_doNotCall.Equals("1"))
                {
                    _doNotCall = "Si";
                }
            }

            var mail = new Mail()
            {
                FirstName = Request.Form["first_name"],
                LastName = Request.Form["last_name"],
                Phone = Request.Form["phone"],
                Email = Request.Form["email"],
                City = Request.Form["city"],
                Country = Request.Form["country"],
                DoNotCall = _doNotCall,
                Industry = Request.Form["industry"],
                LeadSource = Request.Form["lead_source"],
                Description = Request.Form["description"],
            };

            new BajadevMail().SendMail(mail);

        }
    }
}