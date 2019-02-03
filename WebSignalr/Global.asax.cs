using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebSignalr.Models;
using WebSignalr.signalr.Hubs;

namespace WebSignalr
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }




        protected void Session_Start(Object sender, EventArgs e)
        {
            // get current context
            HttpContext currentContext = HttpContext.Current;

            if (currentContext != null)
            {
                if (!currentContext.Request.Browser.Crawler)
                {
                    WebVisitor currentVisitor = new WebVisitor(currentContext);
                    OnlineVisitorsContainer.Visitors[currentVisitor.SessionId] = currentVisitor;
                    new SystemHub().SendOnlineVisitorsContainer(OnlineVisitorsContainer.Visitors.Values.ToList());
                }
            }
        }

        protected void Session_End(Object sender, EventArgs e)
        {

            string sessionId = this.Session.SessionID;

            WebVisitor visitor;
            OnlineVisitorsContainer.Visitors.TryRemove(sessionId, out visitor);

            new SystemHub().SendOnlineVisitorsContainer(OnlineVisitorsContainer.Visitors.Values.ToList());
            if (visitor.UserNameID != null)
            {
                System_Model.Instance.SetIsOfflineUserByID(visitor.UserNameID);

            }
        }

     

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs eventArgs)
        {
            HttpContext currentContext = HttpContext.Current;

            if (currentContext != null)
            {
                var account = (Account) HttpContext.Current.Session["user"];

                if (account != null)
                {
                    var visitor = OnlineVisitorsContainer.Visitors
                        .SingleOrDefault(q => q.Key == currentContext.Session.SessionID).Value;
                    if (visitor.UserNameID != account.AccountID)
                    {
                        if (visitor.UserNameID == null)
                        {
                            System_Model.Instance.SetIsOnlineUserByID(account.AccountID);
                        }
                        else
                        {
                            System_Model.Instance.SetIsOfflineUserByID(visitor.UserNameID);
                            System_Model.Instance.SetIsOnlineUserByID(account.AccountID);
                        }

                        WebVisitor currentVisitor = new WebVisitor(currentContext);
                        OnlineVisitorsContainer.Visitors[currentVisitor.SessionId] = currentVisitor;
                        new SystemHub().SendOnlineVisitorsContainer(OnlineVisitorsContainer.Visitors.Values.ToList());
                    }

                }
            }

        }
    }
}