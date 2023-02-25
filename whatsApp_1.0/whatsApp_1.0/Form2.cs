using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace whatsApp_1._0
{
    public partial class Form2 : Form
    {
        messageVeiw msg,msg2;
        public Form2()
        {
            InitializeComponent();
            msg = new messageVeiw();
            this.msg.BackColor = System.Drawing.Color.Chartreuse;
            this.msg.Font = new System.Drawing.Font("Tahoma", 10F);
            this.msg.Location = new System.Drawing.Point(3, 113);
            this.msg.Name = "msg";
            this.msg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            //this.msg.Size = new System.Drawing.Size(209, 23);
            //this.msg.TabIndex = 4;
            //this.msg.Text = "1234567890123456789012345678";
            this.msg.setText("صباح الخير ارجو انك تكون بخير ايها الرجل الهمام");
            this.pnl.Controls.Add(msg);

            /*msg2 = new messageVeiw();
            this.msg2.BackColor = System.Drawing.Color.White;
            this.msg2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.msg2.setText("صباح الخير ارجو انك تكون بخير ايها الرجل الهمام");
            this.msg2.Location = new System.Drawing.Point(290-this.msg2.Width, this.msg.Location.Y + this.msg.Size.Height);
            this.msg2.Name = "msg2";
            this.msg2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            //this.msg2.Size = new System.Drawing.Size(209, 23);
            //this.msg2.TabIndex = 4;
            //this.msg2.Text = "1234567890123456789012345678";
             * 
             * */
            for (int i = 0; i < 20; i++)
            {
                msg2 = new messageVeiw();
                this.msg2.BackColor = System.Drawing.Color.White;
                this.msg2.Font = new System.Drawing.Font("Tahoma", 10F);
                this.msg2.setText("صباح الخير ارجو انك تكون بخير ايها الرجل الهمام");
               // this.msg2.Location = new System.Drawing.Point(290 - this.msg2.Width, this.msg.Location.Y + this.msg.Size.Height);
                this.msg2.Name = "msg2";
                this.msg2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                this.msg2.Location = new System.Drawing.Point(290 - this.msg2.Width, 113 + this.msg2.Size.Height * i);

                this.pnl.Controls.Add(msg2);
            }

             cvh = new chatingVeiwHeader("eshaq");
            this.pnlChating.Controls.Add(this.cvh);
        }
        chatingVeiwHeader cvh;
        private void Form2_Load(object sender, EventArgs e)
        {
            //this.pictureBox1.ImageLocation
        }
    }
}
