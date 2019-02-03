using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSignalr.Models
{
    public class WebVisitor
    {
        public string SessionId { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public string UserNameID { get; set; }

        public string UserName { get; set; }


        public string SessionStarted { get; set; }

        public WebVisitor(HttpContext context)
        {
            if (context != null && context.Request != null && context.Session != null)
            {
                this.SessionId = context.Session.SessionID;

                this.SessionStarted = DateTime.Now.ToString();
            
                //this.UserAgent = String.IsNullOrEmpty(context.Request.UserAgent) ? "" : context.Request.UserAgent;
                this.UserAgent = context.Request.UserAgent ?? String.Empty;

                this.IpAddress = context.Request.UserHostAddress;

                if (context.Session["user"] != null)
                {
                    var acc = (Account)context.Session["user"];
                    this.UserName = acc.Account_Name;
                 
                    this.UserNameID = acc.AccountID;
                }

            }
        }
    }

    /// <summary>
    /// Online visitors list
    /// </summary>
    public static class OnlineVisitorsContainer
    {
        public static readonly ConcurrentDictionary<string, WebVisitor> Visitors = new ConcurrentDictionary<string, WebVisitor>();
    }
}
