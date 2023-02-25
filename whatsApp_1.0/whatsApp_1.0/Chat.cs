using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MyLibrary.Net;
namespace whatsApp_1._0
{
    class Chat
    {
        private string number;
        private string name;
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {if(value==null || value=="" )
                name = this.Number ;
            else
               name= value ;
            }
        }


        private Bitmap photo;
        public Bitmap Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }

      
        //public ChatingVeiw chatingVeiw;
        //public ChatingVeiw ChatingVeiw
        //{
        //    get
        //    {
        //        return chatingVeiw;
        //    }
        //    set
        //    {
        //        chatingVeiw = value;
        //    }
        //}
        public chatView chatVeiw;
        public chatView ChatVeiw
        {
            get
            {
                return chatVeiw;
            }
            set
            {
                chatVeiw = value;
            }
        }

       

        // public ChatingVeiw chatingveiw;

        public Chat(string n,string t)
        {
            this.Number = n;
            this.Name = t;
            

            chatVeiw = new chatView(this.Name );
            chatVeiw.Dock = DockStyle.Top;
            //chatVeiw.Title = this.Name != null ? this.Name : this.Number;
           //this.chatingVeiw = new ChatingVeiw(this.Name);
           // chatingVeiw.Visible = false;


            chatVeiw.Click += delegate { onClick(this); };
        }
        public Action<Chat> onClick;
        public List<IMessage> Messages = new List<IMessage>();
        
        public void hi(object s, EventArgs e)
        {
           //List<Message> msgs= DataAccessLayer.getMessages(this.Number);
           //foreach (Message ms in msgs)
           //{
           //    this.ChatingVeiw.addMessage(ms.Value, (messageFrom)ms.Flag);
           //}
            //StreamReader f = new StreamReader(Number + ".txt");
            //string t = f.ReadToEnd();
            //f.Close();

            //string[] msgs = t.Split('#');
            //for (int i = 0; i < msgs.Length; i++)
            //{
            //    string ts=msgs[i];
            //    if (ts[0] == '$')
            //    {
            //        this.ChatingVeiw.addMessage(msgs[i].Substring(1), messageFrom.Me);
            //    }
            //    else
            //    {
            //        this.ChatingVeiw.addMessage(msgs[i].Substring(1), messageFrom.Sender);
            //    }

            //}

           // this.ChatingVeiw.Visible = true;
             
        }

        public void Add(IMessage message)
        {
            this.Messages.Add(message);
            //this.chatVeiw.lblLastMsg.Text = message.Text;
        }
    }
}
