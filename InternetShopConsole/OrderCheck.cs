using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class OrderCheck
    {
        Order order;
        Client client;

        public OrderCheck(Order _order, Client _client)
        {
            order = _order;
            client = _client;
        }
        
        public void DisplayTheCheck()
        {
            Console.WriteLine();
            Console.WriteLine("Here is you OrderCheck");
            PrintTheHeader();
            client.DisplayPersonalInfo();
            PrintTheBody();
            order.DisplayOrder();
            PrintUnderGround();
        }
       
        void PrintTheHeader()
        {
            Console.WriteLine(" ==================OrderCheck================");
            Console.WriteLine(" |               Client Info                |");
            Console.WriteLine(" ============================================");
        }

        void PrintTheBody()
        {
            Console.WriteLine(" ============================================");
            Console.WriteLine(" |               Order Info                 |");
            Console.WriteLine(" ============================================");
        }
        void PrintUnderGround()
        {
            Console.WriteLine(" ============================================");
        }
    }
}
