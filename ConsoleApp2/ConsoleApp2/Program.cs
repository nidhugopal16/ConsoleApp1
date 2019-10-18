using ConsoleApp2.Models;
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
                    Console.WriteLine("\n Getting by manually making connecting to sql\n");
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
                Console.WriteLine("\n Getting authors through entity framework scafold database \n");

                var db = new pubsContext();
                foreach (Authors author in db.Authors)
                {
                    Console.WriteLine(author.AuFname + " " + author.AuLname);
                }
                Console.WriteLine("\n Getting Title through scafold database \n");
                foreach (Titles title in db.Titles)
                {
                    Console.WriteLine(title.Title);
                }
            }

            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}


