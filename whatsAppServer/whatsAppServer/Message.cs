using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsAppServer
{
    class Message
    {
       
        string fromNumber;

        public string FromNumber
        {
            get { return fromNumber; }
            set { fromNumber = value; }
        }
        string toNumber;

        public string ToNumber
        {
            get { return toNumber; }
            set { toNumber = value; }
        }
        MessageContentType type;

        public MessageContentType Type
        {
            get { return type; }
            set { type = value; }
        }
        string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public void setMessage(byte[] bytes,int s,int count,string from)
        {
            this.Type =(MessageContentType) bytes[s];
            this.ToNumber = Encoding.ASCII.GetString(bytes, s + 1, 9);
            this.FromNumber = from;
            this.value = Encoding.ASCII.GetString(bytes, s + 1+9+1, count);
        }
        void getBytes(byte[] ba, int bs, string txt)
        {
            byte[] b2 = Encoding.ASCII.GetBytes(txt);
            for (int i = 0; i < txt.Length; i++)
                ba[i + bs] = b2[i];
        }

        public byte[] getBytes()
        {
            byte[] bytes = new byte[2+9+value.Length];
            bytes[0] = (byte)MessageType.MessageTo;
            bytes[1] = (byte)Type;
            getBytes(bytes, 2, this.FromNumber);
            getBytes(bytes, 2 + this.FromNumber.Length, Value);
            return bytes;
        }
    }

   
}
