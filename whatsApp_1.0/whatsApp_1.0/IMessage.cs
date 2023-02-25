using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsApp_1._0
{
    /*
    public enum MessageType { IdentityMessage, TextMessage };
    public interface IMessage
    {
        void setBytes(byte[] bytes, int index, int count);
        byte[] getBytes();
        string Sender { set; get; }
        string Reciever { set; get; }
        string Text { set; get; }
        MessageType MessageType { set; get; }
    }
    
    public class TextMessage : IMessage
    {
        public TextMessage(string sender, string rec, string message)
        {
            this.Sender = sender;
            this.Reciever = rec;
            this.MessageText = message;
            this.MessageType = MessageType.TextMessage;
        }
        public TextMessage()
        {
            this.MessageType = MessageType.TextMessage;
        }
        public TextMessage(byte[] bytes)
        {
            this.MessageType = MessageType.TextMessage;
            this.setBytes(bytes, 0, bytes.Length);
        }
        public string Sender { get => sender; set => sender = value; }
        public string Reciever
        {
            get => reciever; set =>
reciever = value;
        }

        string sender, reciever;
        public string MessageText { set; get; }
        public MessageType MessageType { get => messageType; set => messageType = value; }
        public string Text { get => "kk"; set { string tmp = value; } }

        MessageType messageType;
        public byte[] getBytes()
        {
            int msgSize = MessageText.Length;
            bytes = new byte[1 + 4 + 9 + 9 + msgSize];
            bytes[0] = (byte)this.messageType;
            byte[] msb = BitConverter.GetBytes(msgSize);
            bytes[1] = msb[0];
            bytes[2] = msb[1];
            bytes[3] = msb[2];
            bytes[4] = msb[3];

            byte[] tmp = Encoding.ASCII.GetBytes(this.sender);
            for (int i = 0; i < 9; i++)
                bytes[i + 5] = tmp[i];

            byte[] tmp2 = Encoding.ASCII.GetBytes(this.Reciever);
            for (int i = 0; i < 9; i++)
                bytes[i + 5 + 9] = tmp2[i];
            System.Windows.Forms.MessageBox.Show(this.MessageText);
            byte[] tmp3 = Encoding.ASCII.GetBytes(this.MessageText);
            for (int i = 0; i < msgSize; i++)
                bytes[i + 5 + 9 + 9] = tmp3[i];
            return bytes;
        }
        byte[] bytes;
        public void setBytes(byte[] bytes, int index, int count)
        {
            this.bytes = bytes;
            index = 5;
            Sender = Encoding.ASCII.GetString(bytes, index, 9);
            Reciever = Encoding.ASCII.GetString(bytes, index + 9, 9);
            int msgSize = BitConverter.ToInt32(bytes, 1);
            MessageText = Encoding.ASCII.GetString(bytes, index + 9 + 9, msgSize);
        }
    }
    public class IdentityMessage : IMessage
    {
        public IdentityMessage(string senderId)
        {
            this.MessageType = MessageType.IdentityMessage;
            Sender = senderId;
            reciever = "";
        }
        public string Sender { get => sender; set => sender = value; }
        public string Reciever
        {
            get => reciever; set =>
reciever = value;
        }

        string sender, reciever;
        //string MessageText { set; get; }
        public MessageType MessageType { get => messageType; set => messageType = value; }
        public string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        MessageType messageType;
        public byte[] getBytes()
        {
            bytes = new byte[1 + 4 + 9];
            bytes[0] = (byte)messageType;
            byte[] tmp = Encoding.ASCII.GetBytes(this.sender);
            for (int i = 0; i < 9; i++)
                bytes[i + 5] = tmp[i];
            return bytes;
        }
        byte[] bytes;
        public void setBytes(byte[] bytes, int index, int count)
        {
            //this.bytes = bytes;
            //Sender = Encoding.ASCII.GetString(bytes, index, 9);
            //Reciever = Encoding.ASCII.GetString(bytes, index + 9, 9);
            //int msgSize = BitConverter.ToInt32(bytes, 1);
            //MessageText = Encoding.ASCII.GetString(bytes, index + 9 + 9, msgSize);
        }
    }
    */
}