using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace SigmaTask14
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!File.Exists(@"ProductsDataBase.db"))
            {
                Console.WriteLine("File is adsent");
            }
            else
            {
                Console.WriteLine("File Exists");
            }

            

            string path = @"C:\Users\Acer\source\repos\SigmaTask14\bin\Debug\netcoreapp3.1\ProductsDataBase.db";

            string connectionString = @"Data Source=" + Environment.CurrentDirectory + @"\ProductsDataBase.sqlite";

            //Console.WriteLine(connectionString);

            string connectionString2 = @"Data Source=test_dataBase.db";
            //Console.WriteLine(connectionString2);



            using (var connection = new SqliteConnection(@"Data Source=ProductsDataBase.db"))
            {
                connection.Open();
            }

            //DataBase db = new DataBase(connectionString);
        }
    }
}
