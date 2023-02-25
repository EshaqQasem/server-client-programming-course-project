using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using MyLibrary.Data;

namespace whatsApp_1._0
{
    public enum MessageContentType
    {
        Text = 1
    }
    public class Message
    {

        //string number;

        //public string Number
        //{
        //    get { return number; }
        //    set { number = value; }
        //}
        //int flag;

        //public int Flag
        //{
        //    get { return flag; }
        //    set { flag = value; }
        //}
        //MessageContentType type;

        //public MessageContentType Type
        //{
        //    get { return type; }
        //    set { type = value; }
        //}
        //string value;

        //public string Value
        //{
        //    get { return this.value; }
        //    set { this.value = value; }
        //}

        //public void setMessage(byte[] bytes, int s, int size)
        //{
        //    this.Type = (MessageContentType)bytes[s];
        //    this.Number = Encoding.ASCII.GetString(bytes, s + 1, 9);
        //    // this.Number = from;
        //    this.value = Encoding.ASCII.GetString(bytes, s + 1 + 9 + 1, size - s - 1 - 1 - 9);
        //}
        //void getBytes(byte[] ba, int bs, string txt)
        //{
        //    byte[] b2 = Encoding.ASCII.GetBytes(txt);
        //    for (int i = 0; i < txt.Length; i++)
        //        ba[i + bs] = b2[i];
        //}
        //public byte[] getBytes()
        //{
        //    byte[] bytes = new byte[2 + 9 + value.Length];
        //    bytes[0] = (byte)MessageType.MessageTo;
        //    bytes[1] = (byte)Type;
        //    getBytes(bytes, 2, this.Number);
        //    getBytes(bytes, 2 + this.Number.Length, Value);
        //    return bytes;
        //}
    }
    public class Contant
    {
        string phoneNum;

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    class DataAccessLayer
    {

        //public DataAccessLayer()
        //{
        //    try
        //    {
        //        con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        //            + System.IO.Directory.GetCurrentDirectory() + "\\whatsAppDatabase.accdb");
        //    }
        //    catch (OleDbException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //public static OleDbConnection con;
        //public void Connect()
        //{
        //    try
        //    {
        //        if (con.State != System.Data.ConnectionState.Open)
        //            con.Open();
        //    }
        //    catch (OleDbException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    // getContant();
        //}

        ////public static List<Contant> myContants = new List<Contant>();

        //static void getContant()
        //{
        //    // MessageBox.Show(";;");
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "select * from chat";
        //    try
        //    {

        //        OleDbDataReader rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            // MessageBox.Show(";;");
        //            myContants.Add(new Contant() { PhoneNum = rd[0].ToString(), Name = rd[1].ToString() });
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //public static void Add(string phn, string name)
        //{
        //    if (con.State == System.Data.ConnectionState.Closed)
        //        Connect();
        //    myContants.Add(new Contant() { PhoneNum = phn, Name = name });

        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "insert into chat(phone_num,name)values('" + phn + "','" + phn + "')";
        //    try
        //    {

        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (OleDbException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //public static void saveMsg(string fromOrTo, string value, int flag)
        //{

        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "insert into message(fromTo,dateTame,valu,flag)values('" + fromOrTo + "','" + value + "','" + DateTime.Now.ToString() + "'," + flag.ToString() + ")";
        //    try
        //    {

        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (OleDbException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //public static List<Message> getMessages(string phn)
        //{
        //    List<Message> msgs = new List<Message>();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "select value,dateTime,flag from message where fromTo='" + phn + "' order by dateTime";
        //    try
        //    {

        //        OleDbDataReader rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            msgs.Add(new Message() { Value = (string)rd["value"], Flag = Convert.ToInt32(rd["flag"].ToString()) });
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return msgs;
        //}
    }


}
