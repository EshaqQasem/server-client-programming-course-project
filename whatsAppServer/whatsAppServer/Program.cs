using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using MyLibrary.Net;

namespace whatsAppServer
{
    class Program
    {
        //public static FileInfo  reservedNumberFilePath =new FileInfo( Directory.GetCurrentDirectory() + "ReservedNumber.txt");
        //public static string num;
        //public static void isNumberReserved(string s)
        //{
        //    while (reservedNumberFilePath.Attributes == FileAttributes.Hidden) { }

        //    reservedNumberFilePath.Attributes = FileAttributes.Hidden;
        //    StreamReader st = new StreamReader(reservedNumberFilePath.FullName);
        //    string temp = st.ReadToEnd();
        //    st.Close();
        //    reservedNumberFilePath.Attributes = FileAttributes.Hidden;



        //}

            
      
        static void Main(string[] args)
        {
           
            ConnectionsManegment cm = new ConnectionsManegment();
            ConnectionsManegment.acceptConnections();



            //Thread t = new Thread(isNumberReserved);
            //t.Start("kk");
            //for (int i = 0; i < 10; i++) 
            //Console.WriteLine("main");
            Console.ReadKey();
        }
    }
}
