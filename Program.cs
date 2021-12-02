using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Data;

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

            //string connectionString = "Data Source=ProductsDataBase.db";

            DataBase db = new DataBase(@"Data Source=ProductsDataBase.db");

            Console.WriteLine("List");
            foreach (Product prod in db.GetProductList())
            {
                Console.WriteLine(prod);
            }

            Console.WriteLine("Product By Name");
            Console.WriteLine(db.GetProduct("Eggs"));
            Console.WriteLine(db.GetProductLinq("Rice"));
        }
    }
}
