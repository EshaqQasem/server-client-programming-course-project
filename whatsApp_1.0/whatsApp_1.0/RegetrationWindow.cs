using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyLibrary.Net;
namespace whatsApp_1._0
{
    public partial class RegetrationWindow : UserControl
    {
        public RegetrationWindow()
        {
            InitializeComponent();
        }
        public Action<Control> onJoinSuccess;
        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtPhNum.Text.Trim();
            //byte[] x = Encoding.ASCII.GetBytes(id);
            //int n= x.Length;
            //MessageBox.Show(n.ToString()+x[0].ToString());
            //return;
            if(id.Length!=9 )
            {
                MessageBox.Show("phone number must be 9 digits");
            }
            else
            {
                Program.serverConection.Connect();
                Program.serverConection.Id=id;
                IdentityMessage identityMessage = new IdentityMessage(id);
                Program.serverConection.Send(identityMessage);
                onJoinSuccess(this);
            }
           //lblServerReplay.Text = "Waiting Server Reply";
           //bool reply= Program.serverConection.joinReqiured(txtPhNum.Text);
           //if (reply)
           //{
           //    File.WriteAllText("myPhoneNum.dt",txtPhNum.Text, ASCIIEncoding.ASCII);
           //    onJoinSuccess(this);
           //}
           //else
           //{
           //    lblServerReplay.Text = "The Number " + txtPhNum.Text + " is Reserved";
           //}
        }
    }
}
