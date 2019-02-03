using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebSignalr.Models;

namespace WebSignalr.signalr.Hubs
{
    public class SystemHub : Hub
    {
        public void SendOnlineVisitorsContainer(List<WebVisitor> websiteVisitor)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SystemHub>();
            hubContext.Clients.All.listOnlineVisitorsContainer(websiteVisitor);
           
        }
    }
}