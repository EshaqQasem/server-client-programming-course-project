using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using MyLibrary.Net;
using System.Threading;
namespace whatsApp_1._0
{
    public enum messageFrom { Me, Sender };
    public partial class ChatingVeiw : Panel
    {
        string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public ChatingVeiw(string t, string num)
        {
            init(t);
            this.phoneNumber = num;
            this.headerVeiw.lblBackArow.Click += lblBackArow_Click;

        }

        public void lblBackArow_Click(object s, EventArgs e)
        {
            this.Visible = false;
            this.messagesCout.Controls.Clear();
        }

        int newMsgY = 5;
        public void addMessage(IMessage message, bool fromMe = true)
        {
            Control messageView;                    
            messageView = new messageVeiw();
            ((messageVeiw)messageView).setText(message.Text);
            
            if(message.MessageType == MessageType.FileMessage)
            {
                FileMessage fm = (FileMessage)message;
                if (MyLibrary.General.IsImage(fm.Path))
                {
                    messageView = new PictureBox()
                    { Height = 150, Width = 150,SizeMode = PictureBoxSizeMode.Zoom};
                    if(fm.IsComplete)
                    {
                        ((PictureBox)messageView).Image = Image.FromFile(fm.Path);
                    }
                }
                if(fm.IsComplete)
                {
                    
                    messageView.ForeColor = Color.Blue;
                    messageView.Click += delegate
                    {
                        System.Diagnostics.Process.Start(fm.Path);
                    };
                }
                else
                {
                    messageView.ForeColor = SystemColors.Control;
                }
            }         
            this.messagesCout.Controls.Add(messageView);
            if (fromMe)
            {
                messageView.BackColor = System.Drawing.Color.Chartreuse;
                messageView.Location = new System.Drawing.Point(3, newMsgY);
            }
            else
            {
                messageView.BackColor = Color.White;
                messageView.Location = new System.Drawing.Point(this.Width - 15 - messageView.Width, newMsgY);

            }
            newMsgY += messageView.Height + 3;
        }

        public Action<IMessage> onSendMessage;
        public void btnSendMsg_Click(object sender, EventArgs e)
        {
            TextMessage textMessage = new TextMessage(Program.serverConection.Id, this.phoneNumber, txtMsgInput.Text);
            this.addMessage(textMessage);
            onSendMessage(textMessage);
            txtMsgInput.Clear();
        }
        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                FileMessage fileMessage = new FileMessage(fileName, Program.serverConection.Id, this.phoneNumber);
                onSendMessage(fileMessage);
                this.addMessage(fileMessage);
                
            }
        }


    }
}
