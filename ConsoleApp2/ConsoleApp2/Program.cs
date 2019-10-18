using System;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        class SqlHelper
        {
            public static SqlDataReader ExcecuteReader(String connString, String commandText)
            {
                SqlConnection conn = new SqlConnection(connString);
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    return reader;
                }
                return null;
            }
                   
        }
        static void Main(string[] args)
        {
            String connString = "Data Source=.; Initial Catalog=pubs; Integrated Security=true;";
            String commandText = "SELECT au_fname, au_lname FROM authors;";

            using (SqlDataReader reader = SqlHelper.ExcecuteReader(connString, commandText))
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["au_fname"].ToString() + " " + reader["au_lname"].ToString());
                }
            }

            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}


