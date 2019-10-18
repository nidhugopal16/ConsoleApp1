using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            String connString = "Data Source=.; Initial Catalog=pubs; Integrated Security=true;";
            String commandText = "SELECT au_fname, au_lname FROM authors;";
            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
