using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace whatsAppServer
{
    class DataAccessLayer
    {
        public static SqlConnection con=new SqlConnection();
        public static void Connect()
        {
            try
            {
                con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=WhatsAppServerdataBase;Integrated Security=True;Pooling=False";
                con.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Add(string phn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into client(phoneNumber,IpAddress)values('"+phn+"','"+phn+"')";
            try
            {

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
        }

    }
}
