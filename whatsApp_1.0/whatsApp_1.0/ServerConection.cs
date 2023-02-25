using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using MyLibrary;
using MyLibrary.Net;
namespace whatsApp_1._0
{
    public enum oldMessageType
    {
        joinReqiured = 1,
        connectReqiured,
        joinFiled,
        joinSuccess,
        newChatReq,
        AcceptNewChat,
        reflectNewChat,
        MessageTo
    }
    public class ServerConection
    {
        string phNumber;
        Socket serverSocket;
        IPEndPoint serverIPEndPoint;

        public ServerConection()
        {
           // phNumber = phNum;

        }
        
        public void Connect()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
          
            try
            {
                serverSocket.Connect(serverIPEndPoint);
                reciveThread  = new Thread(this.reseve);
                reciveThread.Start();
            }
            catch (SocketException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
           
        }
        public string Id { set; get; }
        

        public  Thread reciveThread;
        public void reseve()
        {

            while (true)
            {
                byte[] buffer = new byte[1027];
                int size = 1000;
                try
                {
                    size = this.serverSocket.Receive(buffer);

                }
                catch (SocketException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    serverSocket.Close();
                    //onCloseConnection(this);
                    break;
                }
                IMessage message = new TextMessage(buffer);
                switch ((MessageType)buffer[0])
                {
                   
                    case MessageType.TextMessage:
                         message = new TextMessage(buffer);
                        break;
                    case MessageType.FileMessage:
                        message = new FileMessage(buffer);                        
                        break;
                    case MessageType.FilePartMessage:
                        message = new FilePartMessage(buffer);
                        break;
                }
            
            
                
              messageArrived(message);
                

            }
        }
        public Action<IMessage> messageArrived;
        public Action newChatAccepted;
        public Action newChatRevlected;
        public void Send(IMessage msg)
        {           
             this.serverSocket.Send(msg.getBytes());
           // MessageBox.Show(msg.getBytes().Length.ToString());
        }

        internal void DisConnect()
        {
            this.reciveThread.Abort();
            if (this.reciveThread.IsAlive)
                MessageBox.Show("recive thread at client stil alive");
            this.serverSocket.Close();
        }

        //public void connectReq(string phNum)
        //{
        //    byte[] b = new byte[10];
        //    b[0] = (byte)MessageType.connectReqiured;
        //    getBytes(b, 1, phNum);
        //    //byte[] b2 = Encoding.ASCII.GetBytes(phNum);
        //    //for (int i = 0; i < 9; i++)
        //    //    b[i + 1] = b2[i];

        //    serverSocket.Send(b);
        //    reciveThread.Start();
        //}

        //void getBytes(byte[] ba, int bs, string txt)
        //{
        //    byte[] b2 = Encoding.ASCII.GetBytes(txt);
        //    for (int i = 0; i < txt.Length; i++)
        //        ba[i + bs] = b2[i];
        //}
        //public bool joinReqiured(string phNum)
        //{
        //   // this.Connect();
        //    byte[] b = new byte[10];
        //    b[0] = (byte)MessageType.joinReqiured;
        //    getBytes(b, 1, phNum);

        //    serverSocket.Send(b);
        //    byte []reply=new byte[1];
        //    serverSocket.Receive(reply);
        //    if (reply[0] == (byte)MessageType.joinSuccess)
        //    {
        //        reciveThread.Start();
        //        return true;
        //    }
        //    return false;
        //}

        //public void newChatReq(string phn)
        //{
        //  //  reciveThread.Abort();
        //    byte[] b = new byte[10];
        //    b[0] = (byte)MessageType.newChatReq;
        //    getBytes(b, 1, phn);

        //    serverSocket.Send(b);
        //    //byte[] reply = new byte[1];
        //    //serverSocket.Receive(reply);
        //    //reciveThread.Start();
        //    //return reply[0] == (byte)MessageType.AcceptNewChat;
        //}
    }
}
