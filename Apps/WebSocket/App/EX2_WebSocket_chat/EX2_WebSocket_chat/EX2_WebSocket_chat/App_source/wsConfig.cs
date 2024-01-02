using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//-----------------------
using Microsoft.AspNetCore.Builder;
namespace EX2_WebSocket_chat.App_source
{
    public class wsConfig
    {

        public static int BufferSize = 4 * 1024;
        public static string wschatPath = "/wschat";
        public static  WebSocketOptions GetOptions()
        {
            WebSocketOptions wso = new WebSocketOptions() {

                ReceiveBufferSize = BufferSize,
                KeepAliveInterval=TimeSpan.FromSeconds(120)

            };
            return wso;
        }
    }
}
