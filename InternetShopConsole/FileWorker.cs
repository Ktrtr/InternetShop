using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace InternetShopConsole
{
    class FileWorker
    {
        string filePath;

        public FileWorker(string _filePath)
        {
            filePath = _filePath;
        }

        ~FileWorker()
        {
            filePath = null;
        }
        public void writeProductListInFile(List<Product> products)
        {
            try
            {
                using (StreamWriter fileIn = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    foreach (Product product in products)
                    {
                        fileIn.WriteLine(product.ProductToJson());
                    }
                    fileIn.WriteLine("~");
                    fileIn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Product> readProductListFromFile()
        {
            List<Product> tempProducts = new List<Product>() { };
            using (StreamReader fileOut = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                string line =  fileOut.ReadLine(); 
                while ((line != null) && (line != "~"))
                {
                    Product product = new Product();
                    product = product.ProductFromJson(line);
                    tempProducts.Add(product);
                    line = fileOut.ReadLine();
                }
                fileOut.Close();
            }
            return tempProducts;
        }

        public void writeOrderInFile(Order order)
        {
            try
            {
                using (StreamWriter fileIn = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    fileIn.WriteLine(order.MainOrderInfoToJson());
                    fileIn.Write(order.ProductsOrderInfoToJson());
                    fileIn.WriteLine("~");
                    fileIn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Order readOrderFromFile()
        {
            MainOrderInfo mainOrderInfo;
            List<Product> products;
            if (!Program.IsFileExist(filePath))
            {
                StreamWriter fileIn = new StreamWriter(filePath, false, System.Text.Encoding.Default);
                fileIn.Close();
            }
            using (StreamReader fileOut = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                string line = fileOut.ReadLine();
                if (line == null || line == "~") return null;
                mainOrderInfo = MainOrderInfo.mainOrderInfoFromJsons(line);
                products = new List<Product>() { };
                while ((line = fileOut.ReadLine()) != "~")
                {
                    Product product = new Product();
                    product = product.ProductFromJson(line);
                    products.Add(product);
                }
                fileOut.Close();
            }
            return new Order(mainOrderInfo, products);
        }

        public void writeClientToFile(Client client)
        {
            try
            {
                using (StreamWriter fileIn = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    fileIn.WriteLine(client.ClientInfoToJson());
                    fileIn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Client readClientFromFile()
        {
            Client client = new Client() ;
            if (!Program.IsFileExist(filePath))
            {
                StreamWriter fileIn = new StreamWriter(filePath, false, System.Text.Encoding.Default);
                fileIn.Close();
            }
            using (StreamReader fileOut = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                string line = fileOut.ReadLine();
                client = client.ClientInfoFromJson(line);
                fileOut.Close();
            }
            return client;
        }
    }
}
