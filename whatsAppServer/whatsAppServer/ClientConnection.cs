using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MyLibrary.Net;

namespace whatsAppServer
{
    class whatsMessage
    {

    }

    class ConnectMessage : IMessage
    {
        public string PhoneNumber { set; get; }

        public ConnectMessage(byte[] bytes, int size)
        {
        }
        public byte[] getBytes()
        {
           
        }

        public void setBytes(byte[] bytes, int size)
        {
            throw new NotImplementedException();
        }
    }
    class JoinMessage : IMessage
    {

        public byte[] getBytes()
        {
            
        }

        public void setBytes(byte[] bytes, int size)
        {
            throw new NotImplementedException();
        }
    }
    class whatsConnection : Connection
    {
        public string PhoneNumber { set; get; }
        public whatsConnection(Socket soc)
            : base(soc)
        {
            this.startReceiveMessage(messageReceived);
        }
        public void messageReceived(byte[] bytes, int size)
        {
            switch (bytes[0])
            {
                case 0:
                    ConnectMessage msg = new ConnectMessage(bytes, size);
                   this.PhoneNumber= msg.PhoneNumber;
                    break;
                case 1:

                    break;
            }
        }
    }
    class ClientConnection
    {
        public ClientConnection(Socket cls)
        {
            this.socket = cls;
            Thread th = new Thread(this.reseve);
            th.Start();
        }

        public bool Send(Message msg)
        {
            try
            {
                this.socket.Send(msg.getBytes());
            }
            catch (SocketException ex)
            {
                if (!socket.Connected)
                    onCloseConnection(this);
                return false;

            }
            return true;
        }
        public void reseve()
        {
            while(true)
            {
                byte [] msg=new byte[1000];
                int size=1000;
                try
                {
                     size = this.socket.Receive(msg);
                }
                catch (SocketException ex)
                {
                    //socket.Close();
                    onCloseConnection(this);
                    break;
                }
               switch ((MessageType) msg[0])
               {
                   case MessageType.newChatReq:
                       string targetPhNum=ASCIIEncoding.ASCII.GetString(msg,1,9);
                       bool found= ConnectionsManegment.customers.Contains(targetPhNum);
                       if (found)
                       {
                           socket.Send(new byte[] { (byte)MessageType.AcceptNewChat });
                       }
                       else
                       {
                           socket.Send(new byte[] { (byte)MessageType.reflectNewChat });
                       }
                       break;
                   case MessageType.MessageTo:
                       Thread th=new Thread(()=>
                       MessageMangement.messageArrived(msg, size, this.PhoneNumber));
                       th.Start();
                       //string targetPhNum2 = ASCIIEncoding.ASCII.GetString(msg, 1, 9);
                       //MessageContentType type = (MessageContentType)msg[10];
                       //string message = ASCIIEncoding.ASCII.GetString(msg, 11, size-11);
                       break;
               }
            }
        }
        public Action<ClientConnection> onCloseConnection;

        Socket socket;

        public Socket Socket
        {
            get { return socket; }
            set { socket = value; }
        }
        string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        IPAddress ipAddress;

        public IPAddress IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
    }
}
