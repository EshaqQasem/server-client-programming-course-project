using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace whatsApp_1._0
{
   public  class chatingVeiwHeader:chatView
    {
        public Label lblBackArow;
        public Label lblOptions;

        public chatingVeiwHeader(string t):base(t)
        {
            this.lblBackArow = new Label();
            this.lblOptions = new Label();

            

            this.pbxChatPhoto.Image = global::whatsApp_1._0.Properties.Resources._1;
            this.pbxChatPhoto.Location = new System.Drawing.Point(231, 9);

            
            this.lblChatTitel.AutoSize = true;
            this.lblChatTitel.Font = new System.Drawing.Font("Tempus Sans ITC", 15F);
            this.lblChatTitel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblChatTitel.Location = new System.Drawing.Point(144, 10);

            this.lblBackArow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblBackArow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBackArow.Location = new System.Drawing.Point(277, 17);
            this.lblBackArow.Name = "label1";
            this.lblBackArow.Size = new System.Drawing.Size(28, 19);
            this.lblBackArow.TabIndex = 0;
            this.lblBackArow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBackArow.Text = "->";
            //this.lblBackArow.Click+=lblBackArow_Click;

            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOptions.Location = new System.Drawing.Point(12, 16);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(15, 19);
            this.lblOptions.TabIndex = 1;
            this.lblOptions.Text = ":";

            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(310, 58);

            this.Controls.Remove(this.lblLastMsg);
            this.Controls.Add(this.lblBackArow);
            this.Controls.Add(this.lblOptions);
        }

      
    }
}
