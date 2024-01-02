using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//------------------------------
using System.Net.WebSockets;

namespace EX2_WebSocket_chat.App_source
{
    public class UserWebSocket
    {
        public string UserName { get; set; }
        public WebSocket UserWS { get; set; }
    }
}
