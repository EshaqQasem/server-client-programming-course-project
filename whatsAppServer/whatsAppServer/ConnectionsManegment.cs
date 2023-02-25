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
    public enum MessageContentType
    {
        Text=1
    }
    public enum MessageType
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
    class ConnectionsManegment
    {
        static Socket serverSocket;
        IPEndPoint serverIPEndPoint;
        public ConnectionsManegment()
        {
            Server server = new Server(5000);
            server.startAcceptConnections(newConnectionAccepted);

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),5000);
          
            serverSocket.Bind(serverIPEndPoint);
            serverSocket.Listen(1000);

        }

        public void  newConnectionAccepted(Connection con)
        {
            Connections.Add(con);
            whatsConnection c= (whatsConnection)con;
           // con.startReceiveMessage(
        }
        public static List<Connection> Connections = new List<Connection>();
    public static List<ClientConnection> connectedClients = new List<ClientConnection>();
     public  static List<string> customers = new List<string>();
     public static List<string> connectedCustomers = new List<string>(); 
        public static void newConStaplish(Socket soc)
       {
         a: 
         byte[]connectMessage=new byte[10];
         try
         {
             soc.Receive(connectMessage);
         }
         catch (SocketException ex)
         {
             soc.Close();
             Thread.CurrentThread.Abort();
             return;
         }
           string phn = ASCIIEncoding.ASCII.GetString(connectMessage, 1, 9);
           switch ((MessageType)connectMessage[0])
           {
               case MessageType.joinReqiured:
                   bool numberReseved = customers.Contains(phn);
                   if (!numberReseved)
                   {
                       soc.Send(new byte[] { (byte)MessageType.joinSuccess });
                       addClient(soc, phn);
                       addCustomer(phn);
                   }
                   else
                   {
                       soc.Send(new byte[] { (byte)MessageType.joinFiled });
                       goto a;
                   }
                   break;
               case MessageType.connectReqiured:
                   addClient(soc, phn);

                   break;
           }                     
         
       }

       static void addCustomer(string phn)
       {
           customers.Add(phn);
       }
       static void addClient(Socket soc,string phn)
       {
           ClientConnection clc = new ClientConnection(soc) { PhoneNumber = phn};
           clc.onCloseConnection += clientColseConnection;

           lock (connectedClients)
           {
               connectedClients.Add(clc);
           }
           Thread th = new Thread(() => MessageMangement.clientOpenConnection(clc));
           th.Start();
       }
       
      public  static void acceptConnections()//main fun
      {
          while (true)
          {
              Socket tmp;
              tmp = serverSocket.Accept();
              Thread th = new Thread(() => newConStaplish(tmp));
              th.Start();
          }
      }
      public static void clientColseConnection(ClientConnection clc)
      {
          clc.Socket.Close();
          connectedClients.Remove(clc);// connectedClients.Find(c => c.PhoneNumber == phNum));
      }
    }
}
