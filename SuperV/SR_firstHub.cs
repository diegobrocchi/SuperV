using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;

namespace SuperV
{
    public class SR_firstHub : Hub
    {

        public void GetLastData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<SR_firstHub>();
            context.Clients.All.refreshData(DateTime.Now.ToLongTimeString());
        }
    }

    public class Updater
    {
        private readonly Timer _timer;
        private readonly static Lazy<Updater> _instance = new Lazy<Updater>(() => new Updater(GlobalHost.ConnectionManager.GetHubContext<SR_firstHub>().Clients));


        private Updater(IHubConnectionContext<dynamic> clients)
        {
            Timer _timer = new Timer(GetUpdatedData, null, 250, 250);
            Clients = clients;
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public static Updater Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public void GetUpdatedData(object state)
        {
            Clients.All.DateTime.Now.ToLongTimeString();
        }
    }
}