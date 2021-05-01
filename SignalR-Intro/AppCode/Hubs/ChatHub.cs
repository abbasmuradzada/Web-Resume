using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Intro.AppCode.Hubs
{
    public class ChatHub: Hub
    {
        static ConcurrentDictionary<string, string> clients = new ConcurrentDictionary<string, string>();

        public override Task OnConnectedAsync()
        {
            HttpContext http = Context.GetHttpContext();

            var mail = http.Request.Query["email"].ToString();

            if (!string.IsNullOrWhiteSpace(mail))
            {
                clients.AddOrUpdate(mail, Context.ConnectionId, (k, v) =>
                {
                    return v;
                });
            }

            return base.OnConnectedAsync();
                //.ContinueWith(r =>
                //SendAllAsync("Salam")
                //.Wait());
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }


        //public async Task SendAllAsync(string message)
        //{
        //    await Clients.All.SendAsync("qebulEt", message, DateTime.Now);
        //    await Clients.Caller.SendAsync("qebulEt", message, DateTime.Now);
        //    await Clients.Others.SendAsync("qebulEt", message, DateTime.Now);
        //}

        public async Task Send(string user, string message)
        {
            if (clients.TryGetValue(user, out string connectionId))
            {
                await Clients.Client(connectionId)
                    .SendAsync("receive", message);
            }
            else
            {
                await Clients.Caller.SendAsync("receive", $"{user} Setde Deyil");
            }
            //await Clients.All.SendAsync("qebulEt", message, DateTime.Now);
            //await Clients.Caller.SendAsync("qebulEt", message, DateTime.Now);
            //await Clients.Others.SendAsync("qebulEt", message, DateTime.Now);
        }
    }
}
