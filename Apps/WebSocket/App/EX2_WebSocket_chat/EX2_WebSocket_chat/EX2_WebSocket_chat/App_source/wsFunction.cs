using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//--------------
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
using Newtonsoft.Json;
namespace EX2_WebSocket_chat.App_source

{
    public class wsFunction
    {
        public async  Task listenAcceptAync(HttpContext context)
        {
            WebSocket ws = await context.WebSockets.AcceptWebSocketAsync();
            string Uname = context.Request.Query["name"];
            UserWebSocket uws = new UserWebSocket();
            uws.UserName = Uname;
            uws.UserWS = ws;
            UserList.ListDic.Add(Uname,uws);
            await ReciveAsync(uws);
        }

        public async Task ReciveAsync(UserWebSocket uws)
        {
            WebSocket ws = uws.UserWS;
            string UserName = uws.UserName;
            byte[] buff;

            while (ws.State==WebSocketState.Open)
            {
                buff = new byte[wsConfig.BufferSize];
                WebSocketReceiveResult result = await ws.ReceiveAsync(
                                                new ArraySegment<byte>(array:buff,offset:0,count:buff.Length)
                                                ,
                                                CancellationToken.None
                                                );
                if (result!=null)
                {
                    if(result.MessageType==WebSocketMessageType.Text)
                    {
                        string strMsg = Encoding.UTF8.GetString(buff);
                        ReciveMessage RecMsg = JsonConvert.DeserializeObject<ReciveMessage>(strMsg);

                        UserWebSocket RecUWS = UserList.ListDic[RecMsg.Reciver];

                        SenderMessage SendMsg = new SenderMessage() {
                            Message=RecMsg.Message,
                            Sender= UserName
                        };

                        await SendAsync(RecUWS.UserWS, SendMsg);
                    }

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        UserList.ListDic.Remove(UserName);
                        //----
                        return;
                    }

                }


            }

        }


        public async Task SendAsync(WebSocket ws,SenderMessage msg)
        {
            string StrMsg = JsonConvert.SerializeObject(msg);
            byte[] buff = Encoding.UTF8.GetBytes(StrMsg);

            await ws.SendAsync(
                              new ArraySegment<byte>(array:buff,offset:0,count:buff.Length),
                              WebSocketMessageType.Text,
                              true,
                              CancellationToken.None
                );
        }
    }
}
