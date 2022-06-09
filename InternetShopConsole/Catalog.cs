using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace InternetShopConsole
{
    class Catalog
    {
        static List<Product> products = new List<Product>();
        public void AddProducts()
        {
            Console.WriteLine("Creating new products, use Esc if you want to stop this...");
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape) break;
                Console.Write("Product id: "); string id = Console.ReadLine();
                Console.Write("Product name: "); string  name = Console.ReadLine();
                Console.Write("Product cost: "); decimal cost = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Product quantity: "); int quantity = Convert.ToInt32(Console.ReadLine());
                Product product = new Product(id, name, cost, quantity);
                products.Add(product);
            }
        }

        public static void DeleteParticularProduct(string productId, List<Product> _products)
        {
            _products.Remove(FindParticularProduct(productId, _products));
        }

        public static Product FindParticularProduct(string productId, List<Product> _products)
        {
            return _products.Find(x => x.GetId().Contains(productId));
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void SetProducts(List<Product> _products)
        {
            products = _products;
        }

        public void DeteleAllProducts()
        {
            products.Clear();
        }

        public void ShowAllProducts()
        {
            Console.WriteLine(" |id |    name    |    cost    |  quantity  | ");
            foreach (Product product in products)
            {
                product.DisplayProduct();
            }
        }
    }
}
