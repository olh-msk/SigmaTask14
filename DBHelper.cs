using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigmaTask14
{
    static class DBHelper
    {
        //sql
        public static Product GetProduct(this DataBase db, string name)
        {
            return db.GetList<Product>($"select * from Products where Name like '{name}%' limit 1", Product.Create).FirstOrDefault();
        }
        //linq
        public static Product GetProductLinq(this DataBase db, string name)
        {
            return db.GetProductList().Where(x => x.Name == name).FirstOrDefault();
        }
        public static List<Product> GetProductList(this DataBase db)
        {
            return db.GetList<Product>("select * from Products", Product.Create);
        }
    }
}
