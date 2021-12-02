using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigmaTask14
{
    class Product
    {
        public int id { get; private set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public int Amount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Product()
        {

        }
        public Product(int _id, string name, double price, double weight,
            int amount, DateTime expirationDate)
        {
            this.id = _id;
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
            this.Amount = amount;
            this.ExpirationDate = expirationDate;
        }

        public static Product Create(IDataRecord data)
        {
            try
            {
                Product newProduct = new Product(Convert.ToInt32(data["_id"]), data["Name"].ToString(),
                    Convert.ToDouble(data["Price"]), Convert.ToDouble(data["Weight"]),
                    Convert.ToInt32(data["Amount"]), DateTime.Parse(data["ExpirationDate"].ToString()));
                return newProduct;
            }
            catch (Exception ex)
            {
                throw new DataException("Can`t read from Data Base");
            }
        }

        public override string ToString()
        {
            return $"{id}: {Name}--{Price}--{Weight}--{Amount}--{ExpirationDate.ToShortDateString()}";
        }
    }
}
