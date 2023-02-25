using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MyLibrary.Net;

namespace whatsApp_1._0
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            chats = new List<Chat>();

        }
        ChatingVeiw ChatingVeiw;
        void cv_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.pnlChating.Controls.IndexOf( ((Panel)sender) ).ToString());
            this.panel1.Visible = false;
            this.pnlChating.Visible = false;
            this.btnNewChat.Visible = false;
            //  chatingVeiw = new ChatingVeiw(""
            // this.chatingVeiw.Visible = true;*/
            //  MessageBox.Show("kkkk");
            //throw new NotImplementedException();
        }
        List<Chat> chats;
        private void الدردشاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlChating.Visible = true;
            this.pnlSetting.Visible = false;
        }

        private void الاعداداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlChating.Visible = false;
            this.pnlSetting.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Program.serverConection.messageArrived = this.MessageArrived;
            ////this.pnlChating.Controls.Add(this.panel2);
            //this.Controls.Add(this.pnlChating);
            //Program.serverConection.messageArrived = MessageArrived;
            //if (!File.Exists("myPhoneNum.dt"))
            //{
            RegetrationWindow rw = new RegetrationWindow() { Dock = DockStyle.Fill };
            rw.onJoinSuccess = (con) => {
                this.Controls.Remove(con);
                this.Controls.Add(this.pnlChating);
                this.Text = Program.serverConection.Id;
                btnNewChat.BringToFront();
            };
            this.Controls.
                Add(rw);
            rw.BringToFront();
            //}
            //else
            //{

            //   this.Text= phoneNumber = File.ReadAllText("myPhoneNum.dt", ASCIIEncoding.ASCII);
            //showChats();
            // Program.serverConection.connectReq(phoneNumber);
            // this.Controls.Add(this.pnlChating);
            


        }

        delegate void msarr(string ms);
        delegate void Message_Invoke(IMessage message);
        void function(IMessage message)
        {
           if(message.MessageType== MessageType.FilePartMessage)
            {
                FilePartMessage filePartMessage = (FilePartMessage)message;             
                UncompleteFileMessage uncompleteFile = fileMessages.Find(ms => ms.Id == filePartMessage.Id);
                if(uncompleteFile!=null)
                    uncompleteFile.Append(filePartMessage);
                else
                {
                    MessageBox.Show("somthing went wroung PART file is received at client with id = " + filePartMessage.Id.ToString());
                }
                return;
            }
            Chat sender = chats.Find(ch => ch.Number == message.Sender);
            if (sender != null)
            {
               
                sender.Add(message);
                if (message.MessageType == MessageType.TextMessage)
                {
                    TextMessage tm = (TextMessage)message;
                    if (ChatingVeiw != null && ChatingVeiw.PhoneNumber == message.Sender)
                    {
                        ChatingVeiw.addMessage(tm, false);                       
                    }
                }
                else if(message.MessageType == MessageType.FileMessage)
                {                   
                    FileMessage fm = (FileMessage)message;
                   UncompleteFileMessage ucf = new UncompleteFileMessage(fm);
                    fileMessages.Add(ucf);
                    ucf.OnRecieveCompelete = (obj) => {
                        MessageBox.Show(obj.FileName + "has arivied from" + obj.Sender + " to " + obj.Reciever); };
                    if (ChatingVeiw != null && ChatingVeiw.PhoneNumber == message.Sender)
                    {
                        ChatingVeiw.addMessage(fm, false);
                    }
                }
            }
            else
            {
                addChat(message.Sender, "").Add(message);
            }
        }

        List<UncompleteFileMessage> fileMessages = new List<UncompleteFileMessage>();
        private void MessageArrived(IMessage message)
        {
            Message_Invoke message_Invoke = function;
            this.Invoke(message_Invoke, message);
            
        }

        Chat addChat(string pn, string n)
        {
            Chat tmp = new Chat(pn, n);
            this.chats.Add(tmp);
            tmp.onClick = (chat) =>
                {
                    this.ChatingVeiw = new ChatingVeiw(chat.Name, chat.Number);
                    foreach (IMessage ms in chat.Messages)
                    {
                            // MessageBox.Show("kk");
                      
                            string id = Program.serverConection.Id;
                            this.ChatingVeiw.addMessage(ms, ms.Sender == id ? true : false);
                        
                    }
                    this.ChatingVeiw.onSendMessage = sendMessage;
                    this.ChatingVeiw.headerVeiw.lblBackArow.Click += lblBackArow_Click;



                    this.Controls.Add(this.ChatingVeiw);
                };
            tmp.chatVeiw.Click += cv_Click;

            this.pnlChating.Controls.Add(tmp.chatVeiw);
            return tmp;
        }

        private void sendMessage(IMessage message)
        {
            if(message.MessageType== MessageType.FileMessage || message is FileMessage)
            {
                sendFile(message);
                return;
            }
           // MessageBox.Show(Program.serverConection.Id + "  " + reciever + "  " + messageText);
           // TextMessage message = new TextMessage(Program.serverConection.Id, reciever, messageText);
            Chat res = chats.Find(ch => ch.Number ==message.Reciever);
            if (res != null)
            {
                res.Add(message);
            }
            Program.serverConection.Send(message);
        }

        private void sendFile(IMessage message)
        {
            FileMessage fileMsg = (FileMessage)message;
           // FileInfoMessage fileInfoMessage = new FileInfoMessage();
            Program.serverConection.Send(fileMsg);
            Thread thread = new Thread(()=> sendFileParts(fileMsg));
            thread.Start();
            MessageBox.Show("File Send from client with id="+fileMsg.Id.ToString());
        }

        private void sendFileParts(FileMessage fileMsg)
        {
            FileStream stream = new FileStream(fileMsg.Path, FileMode.Open);
            long i;
            for (i = 0; i < stream.Length - 1000; i += 1000)
            {
                byte[] part = new byte[1000];
                stream.Read(part, 0, 1000);
                FilePartMessage filePart = new FilePartMessage(fileMsg, part);
                lock (new object())
                {
                    Program.serverConection.Send(filePart);
                }
            }
            byte[] part2 = new byte[stream.Length - i];
            stream.Read(part2, 0, part2.Length);
            FilePartMessage filePart2 = new FilePartMessage(fileMsg, part2);
            lock (new object())
            {
                Program.serverConection.Send(filePart2);
            }
            stream.Close();
            
        }
        private void showChats()
        {
            //{

            //    DataAccessLayer.Connect();
            //   // MessageBox.Show(DataAccessLayer.myContants.Count.ToString());   
            //   foreach(Contant con in DataAccessLayer.myContants)
            //    {

            //        addChat(con.PhoneNum, con.Name);

            //    }
        }

        string phoneNumber;
        public void lblBackArow_Click(object s, EventArgs e)
        {
            this.Controls.Remove(this.ChatingVeiw);
            this.panel1.Visible = true;
            this.pnlChating.Visible = true;
            btnNewChat.Visible = true;
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("jjjjjjjjj");
            this.pnlChating.Visible = false;
            this.pnlSetting.Visible = true;
            StreamReader file = new StreamReader("chat1.txt");
            string chating = file.ReadToEnd();
            string[] msgs = chating.Split(';');
            for (int i = 0; i < msgs.Length; i++)
            {
                // if (msgs[i,0] == '$') { }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            newChatingView ncv = new newChatingView();
            ncv.onAcceptNewChat = (s, pn, n) =>
            {
                this.Controls.Remove(s);
                btnNewChat.BringToFront();
                addChat(pn, n);
                //if (DataAccessLayer.myContants.Find(c => c.PhoneNum == pn) == null)
                //{
                //    addChat(pn, n);
                //    DataAccessLayer.Add(pn, n);
                //}
            };
            ncv.onReflectNewChat = (c) => { this.Controls.Remove(c); btnNewChat.BringToFront(); };
            this.Controls.Add(ncv);
            ncv.BringToFront();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.serverConection.DisConnect();
            //if (Program.serverConection.reciveThread.IsAlive)
            //   Program.serverConection.reciveThread.Abort();
        }
    }
}
