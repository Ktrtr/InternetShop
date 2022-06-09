using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace InternetShopConsole
{
    class MainOrderInfo
    {
        public decimal cost { get; set; }
        public string id { get; set; }
        public OrderState orderState { get; set; }

        public MainOrderInfo(string id, decimal cost, OrderState orderState)
        {
            this.id = id;
            this.cost = cost;
            this.orderState = orderState;
        }
        
        public static MainOrderInfo mainOrderInfoFromJsons(string line)
        {
            return JsonConvert.DeserializeObject<MainOrderInfo>(line);
        }
    }
}
