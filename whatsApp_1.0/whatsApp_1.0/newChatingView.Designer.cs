namespace whatsApp_1._0
{
    partial class newChatingView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.btnStartNewChating = new System.Windows.Forms.Button();
            this.lblServerReply = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(75, 147);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(171, 20);
            this.txtPhoneNum.TabIndex = 0;
            // 
            // btnStartNewChating
            // 
            this.btnStartNewChating.Location = new System.Drawing.Point(111, 251);
            this.btnStartNewChating.Name = "btnStartNewChating";
            this.btnStartNewChating.Size = new System.Drawing.Size(75, 23);
            this.btnStartNewChating.TabIndex = 1;
            this.btnStartNewChating.Text = "اضافة دردشة";
            this.btnStartNewChating.UseVisualStyleBackColor = true;
            this.btnStartNewChating.Click += new System.EventHandler(this.btnStartNewChating_Click);
            // 
            // lblServerReply
            // 
            this.lblServerReply.AutoSize = true;
            this.lblServerReply.Location = new System.Drawing.Point(130, 91);
            this.lblServerReply.Name = "lblServerReply";
            this.lblServerReply.Size = new System.Drawing.Size(0, 13);
            this.lblServerReply.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 121);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(171, 20);
            this.txtName.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "رجوع";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // newChatingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblServerReply);
            this.Controls.Add(this.btnStartNewChating);
            this.Controls.Add(this.txtPhoneNum);
            this.Name = "newChatingView";
            this.Size = new System.Drawing.Size(308, 503);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Button btnStartNewChating;
        private System.Windows.Forms.Label lblServerReply;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
    }
}
