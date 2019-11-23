using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matcher.SignalR
{
    public class HomeHub : Hub
    {
        [HubMethodName("HideWindows")]
         public async Task HideAllWindows()
        {
            await Clients.All.SendAsync("HideWindows");
        }
    }
}
