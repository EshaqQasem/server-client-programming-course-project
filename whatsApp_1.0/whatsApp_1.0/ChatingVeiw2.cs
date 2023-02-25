using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace whatsApp_1._0
{
   public  partial class ChatingVeiw
    {
        void init(string t)
        {
            this.headerVeiw = new chatingVeiwHeader(t);
            this.messagesCout = new Panel();
            this.txtMsgInput = new TextBox();
            this.btnSendMsg = new Button();
            this.btnSendFile = new Button();
            //
            //  headerVeiw
            //
            

            //
            // messagesCout
            //
            this.messagesCout.AutoScroll = true;
            this.messagesCout.BackgroundImage = global::whatsApp_1._0.Properties.Resources.msgbg;
            this.messagesCout.Location = new System.Drawing.Point(3, 56);
            this.messagesCout.Name = "messagesCout";
            this.messagesCout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.messagesCout.Size = new System.Drawing.Size(308, 395);
            this.messagesCout.TabIndex = 3;
            //
            //txtMsgInput
            //
            this.txtMsgInput.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMsgInput.Location = new System.Drawing.Point(66, 457);
            this.txtMsgInput.Multiline = true;
            this.txtMsgInput.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtMsgInput.Height += 100; };
            this.txtMsgInput.Name = "txtMsgInput";
            this.txtMsgInput.Size = new System.Drawing.Size(233, 31);
            this.txtMsgInput.TabIndex = 1;
            //
            //btnSendMsg
            //
            this.btnSendMsg.BackgroundImage = global::whatsApp_1._0.Properties.Resources.chatBackground;
            this.btnSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMsg.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnSendMsg.Location = new System.Drawing.Point(7, 457);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(50, 31);
            this.btnSendMsg.TabIndex = 2;
            this.btnSendMsg.Text = "<";
            this.btnSendMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click+=btnSendMsg_Click;
            //
            // btnSendFile
            //
            this.btnSendFile.AutoSize = true;
            this.btnSendFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.Image = global::whatsApp_1._0.Properties.Resources.icons8_send_letter_48;
            this.btnSendFile.Location = new System.Drawing.Point(7, 400);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(56, 56);
            this.btnSendFile.Click += BtnSendFile_Click;
            this.btnSendFile.UseVisualStyleBackColor = true;
            //
            //this
            //
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BackgroundImage = global::whatsApp_1._0.Properties.Resources.chatBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
       
            this.Controls.Add(this.headerVeiw);
            this.Controls.Add(this.messagesCout);
            this.Controls.Add(this.txtMsgInput);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(btnSendFile);
            this.btnSendFile.BringToFront();
            this.Location = new System.Drawing.Point(-2, 2);
            this.Name = "pnlChating";
            this.Size = new System.Drawing.Size(311, 496);
            this.TabIndex = 1;
        }

        

        public  chatingVeiwHeader headerVeiw;
        private Panel messagesCout;
        private TextBox txtMsgInput;
        private Button btnSendMsg;
        private Button btnSendFile;
    }
}
