using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace InternetShopConsole
{
    class Product
    {
        public string id;
        public string name;
        public decimal cost;
        public int quantity;

        public Product()
        {
           
        }

        public Product(string _id, string _name, decimal _cost, int _quantity)
        {
            id = _id;
            name = _name;
            cost = _cost;
            quantity = _quantity;
        }
        public void DisplayProduct()
        {
            Console.WriteLine($" |{id,-3}|{name,-12}|{cost,-12}|{quantity,-12}|");
        }

        public string ProductToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        
        public  Product ProductFromJson(string line)
        {
            return JsonConvert.DeserializeObject<Product>(line);
        }

        public string GetId()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
        public decimal GetCost()
        {
            return cost;
        }
        public int GetQantity()
        {
            return quantity;
        }

        public void DecreaseQuantity(int _quantity)
        {
            quantity -= _quantity;
        }

        public void IncreaseQuantity(int _quantity)
        {
            quantity += _quantity;
        }

        public void SetQuantity(int _quantity)
        {
            quantity = _quantity;
        }
    }
}
