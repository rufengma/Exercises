using System;
using System.Data.SqlClient;


namespace Exercise6
{
    class A {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sq_Myproc", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
