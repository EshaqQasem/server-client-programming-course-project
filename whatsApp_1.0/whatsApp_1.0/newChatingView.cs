using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace whatsApp_1._0
{
    public partial class newChatingView : UserControl
    {
        public newChatingView()
        {
            InitializeComponent();
        }
        public Action<Control,string,string> onAcceptNewChat;
        public Action<Control> onReflectNewChat;
        private void btnStartNewChating_Click(object sender, EventArgs e)
        {
            string phnum = txtPhoneNum.Text.Trim();
            string name = txtName.Text.Trim();
            if (phnum.Length != 9)
            {
                MessageBox.Show("phone number must be 9");
            }
            else
            {
                onAcceptNewChat(this, phnum, name);
            }
        }

        //    lblServerReply.Text = "Waiting Server Reply";
        //     Program.serverConection.newChatReq(txtPhoneNum.Text);
        //    //if (accepted)
        //    //{
        //    //    onAcceptNewChat(this,this.txtPhoneNum.Text,txtName.Text);
        //    //}
        //    //else
        //    //{
        //    //   // onReflectNewChat();
        //    //    lblServerReply.Text = "no Number";
        //    //}
        //}
        //public void newChAccept()
        //{
        //    this.Invoke(new empty(()=>  onAcceptNewChat(this, this.txtPhoneNum.Text, txtName.Text)));
        //}
        //delegate void empty();
        //public void newChRef()
        //{
        //   this.Invoke(new empty(()=>  lblServerReply.Text = "no Number"));
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            onReflectNewChat(this);
        }
    }
}
