using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace InternetShopConsole
{
    class Client : User
    {
        List<Product> basket = new List<Product>() { };
        public string adress { get; set; }
        public decimal money { get; set; }
        public Client(string _id, string _password) : base(_id, _password)
        {
            definition = "Client";
            money = 200000;
        }
        public Client() { }
        public Client(string _id, string _password, string _adress) : base(_id, _password)
        {
            adress = _adress;
            money = 200000;
            definition = "Client";
        }
        public void ShowBasket()
        {
            if (basket.Count != 0)
            {
                Console.WriteLine("Users basket is here:");
                foreach (Product product in basket)
                {
                    product.DisplayProduct();
                }
            }
            else
            {
                Console.WriteLine("Basket is empty");
            }
            
        }

        public override void DisplayPersonalInfo()
        {
            Console.WriteLine($" |{definition, -42}|");
            Console.WriteLine($" |Id {id,-39}|");
            Console.WriteLine($" |Password {password,-33}|");
            Console.WriteLine($" |Balance {money,-34}|");
            if (adress != null) Console.WriteLine($" |Adress {adress,-35}|");
        }

        public void AddToBasket(Catalog _catalog)
        {
            Console.Write("Enter Id of product: ");
            Program.ClearTheLine();
            string answerId = Console.ReadLine();
            Console.Write("Enter quantity: ");
            Program.ClearTheLine();
            int answerQantity = Convert.ToInt32(Console.ReadLine()); 
            Product nesseccaryProduct = Catalog.FindParticularProduct(answerId, _catalog.GetProducts());
            if (nesseccaryProduct != null && answerQantity < nesseccaryProduct.GetQantity())
            {
                Catalog.FindParticularProduct(answerId, _catalog.GetProducts()).DecreaseQuantity(answerQantity);
                if ((basket.Find(x => x.id.Contains(answerId)))  != null) 
                {
                    basket.Find(x => x.id.Contains(answerId)).IncreaseQuantity(answerQantity);
                }
                else
                {
                    basket.Add(new Product(nesseccaryProduct.GetId(), nesseccaryProduct.GetName(), nesseccaryProduct.GetCost(), answerQantity));
                }
                
            }
        }

        public List<Product> GetBasket()
        {
            return basket;
        }

        public string GetAdress()
        {
            return adress;
        }

        public void SetAdress(string _adress)
        {
            adress = _adress;
        }

        public void PayTheOrder(Order order)
        {
           if (order.GetCost() <= money)
           {
                money -= order.GetCost();
                order.SetNewState(OrderState.paid);
                Console.WriteLine("Transaction complete");
                FileWorker file = new FileWorker(Program.fileClientPath);
                file.writeClientToFile(this);
           }
           else Console.WriteLine("You don't have enough money");
        }

        public void RecieveDeliveryOrder()
        {
            if (adress == null)
            {
                Console.Write("Enter your adress, please: ");
                adress = Console.ReadLine();
            }
            SetAdress(adress);
        }

        public void RecieveOrder(Order order)
        {
            order.SetNewState(OrderState.recieved);
        }

        public string ClientInfoToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        
        public Client ClientInfoFromJson(string line)
        {
            return JsonConvert.DeserializeObject<Client>(line);
        }

        public bool CompareWithOrder(Order order)
        {
            return (new HashSet<Product>(basket).SetEquals(order.GetProducts())) ? true : false;
        }
    }
}
