using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace whatsApp_1._0
{
   public  class chatView:Panel
    {

        public Label lblChatTitel, lblLastMsg;
        public PictureBox pbxChatPhoto;
        public string Title
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value ;//!= null ? value : "none";
            }
        }
        public chatView(string t)
        {
            lblChatTitel = new Label();
            lblLastMsg = new Label();
            pbxChatPhoto = new PictureBox();

            this.lblChatTitel.Text = t;
            Init();
            }
        public chatView(string title, string lm, Bitmap photo)
        {
            
        }
        private void Init()
        {
            this.Size = new System.Drawing.Size(305, 69);

            //
            //pbxChatPhoto
            //
            this.pbxChatPhoto.Image = global::whatsApp_1._0.Properties.Resources._1;
            this.pbxChatPhoto.Size = new System.Drawing.Size(47, 50);
            this.pbxChatPhoto.Location = new System.Drawing.Point(this.Width - this.pbxChatPhoto.Width - 10, 9);
            this.pbxChatPhoto.Name = "pbxChatPhoto";

            this.pbxChatPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxChatPhoto.TabIndex = 0;
            this.pbxChatPhoto.TabStop = false;
            //
            //lblChatTitel
            //
           
            this.lblChatTitel.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
             this.lblChatTitel.Name = "lblChatTitel";
             this.lblChatTitel.Location = new System.Drawing.Point(14, 9);
            this.lblChatTitel.Size = new System.Drawing.Size(230, 23);
          
          
            this.lblChatTitel.TabIndex = 1;
           
            //
            //lblLastMsg
            //
            this.lblLastMsg.Location = new System.Drawing.Point(14, 32);
            this.lblLastMsg.Name = "lblLastMsg";
            this.lblLastMsg.Size = new System.Drawing.Size(230, 23);
            this.lblLastMsg.TabIndex = 2;
            this.lblLastMsg.Text = "no messages yet";
           
            // 
            //this
            //
            
            this.Controls.Add(this.lblChatTitel);
            this.Controls.Add(this.lblLastMsg);
            this.Controls.Add(this.pbxChatPhoto);
            this.Paint +=chatView_Paint;
            //this.Location = new System.Drawing.Point(7, 63);
            //this.Name = "panel2";
           
            //this.TabIndex = 1;
           
        }

        public void chatView_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            g.DrawLine(new Pen(Color.Black,(float)0.5), new Point(10, 62), new Point(240, 62));
        }
    }
}
