using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace InternetShopConsole
{
    class Order
    {
        List<Product> products;
        decimal cost;
        string id;
        OrderState orderState;

        public Order() { }

        public Order(Client _client, List<Product> _products)
        {
            id = _client.id + "idOrder";
            products = _products;
            cost = CountCost(_products);
            orderState = OrderState.none;
        }
        ~Order()
        {
            id = null;
            cost = 0;
            orderState = OrderState.none;
            products.Clear();
        }
        public Order(MainOrderInfo mainOrderInfo, List<Product> _products)
        {
            id = mainOrderInfo.id;
            cost = mainOrderInfo.cost;
            orderState = mainOrderInfo.orderState;
            products = _products;
        }

        decimal CountCost(List<Product> products)
        {
            decimal resultCost = 0;
            foreach(Product product in products)
            {
                resultCost += (product.GetCost() * product.GetQantity());
            }
            return resultCost;
        }

        public string MainOrderInfoToJson()
        {
            MainOrderInfo mainOrderInfo = new MainOrderInfo(id, cost, orderState);
            return JsonConvert.SerializeObject(mainOrderInfo);
        }

        public string ProductsOrderInfoToJson()
        {
            string info = "";
            foreach(Product product in products)
            {
                info += (JsonConvert.SerializeObject(product) + "\n") ;
            }
            return info;
        }

        public void DisplayOrder()
        {
            Console.WriteLine($" |id: {id,-38}|");
            Console.WriteLine($" |cost: {cost,-36}|");
            Console.WriteLine($" |state: " + ((orderState == OrderState.none) ? "none".PadRight(34)
                                            : (orderState == OrderState.confirmed) ? "confirmed".PadRight(35)
                                            : (orderState == OrderState.declined) ? "declined".PadRight(27)
                                            : (orderState == OrderState.paid) ? "payed".PadRight(35)
                                            : (orderState == OrderState.registrated) ? "registred".PadRight(27)
                                            : (orderState == OrderState.sended) ? "sended".PadRight(35)
                                            : "recieved".PadRight(35)) + "|");
            if (products.Count != 0)
            {
                foreach (Product product in products)
                {
                    product.DisplayProduct();
                }
            }
        }

        public void SetNewState(OrderState _orderState)
        {
            orderState = _orderState;
        }

        public decimal GetCost()
        {
            return cost;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void SetProducts(List<Product> _products)
        {
            products = _products;
        }

        public OrderState GetState()
        {
            return orderState;
        }

        public void DeclineOrder()
        {
            id = null;
            cost = 0;
            orderState = OrderState.none;
            products.Clear();
        }
    }
}
