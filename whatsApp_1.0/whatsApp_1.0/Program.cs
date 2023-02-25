using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace whatsApp_1._0
{
    static class Program
    {
        public static ServerConection serverConection;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            serverConection = new ServerConection();
            
            mainForm mf = new mainForm();
            

            Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mf);
        }
    }
}
