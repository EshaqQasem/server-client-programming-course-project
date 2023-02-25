using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsAppServer
{
    class MessageMangement
    {
        public static List<Message> unSendMessage = new List<Message>();

        public static void messageArrived(byte []msg,int size,string from)
        {
            Message nmsg = new Message();
            nmsg.setMessage(msg, 1,size,from);
            ClientConnection clc = ConnectionsManegment.connectedClients.Find(c => c.PhoneNumber == nmsg.ToNumber);
            if (clc != null)
            {
                clc.Send(nmsg);
            }
            else
            {
                unSendMessage.Add(nmsg);
            }
        }

        public static void clientOpenConnection(ClientConnection clc)
        {
            foreach(Message msg in unSendMessage)
            {
                  if (msg.ToNumber == clc.PhoneNumber)
                {
                    if (clc.Send(msg))
                    {
                        unSendMessage.Remove(msg);
                    }else
                    {
                        return;
                    }
                }
            }
        
            //unSendMessage.ForEach((msg) => {
            //    if (msg.ToNumber == clc.PhoneNumber)
            //    {
            //        if (clc.Send(msg))
            //        {
            //            unSendMessage.Remove(msg);
            //        }else
            //        {
            //            return
            //    }
            //});
        }
    }
}
