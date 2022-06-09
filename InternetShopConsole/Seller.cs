using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class Seller : User
    {
        int cashboxNumber { get; set; }

        public Seller(string _id, string _password, int _cashboxNumber) : base(_id, _password)
        {
            cashboxNumber = _cashboxNumber;
            definition = "Seller";
        }

        public void ConfirmOrder(Order order)
        {
            Console.WriteLine("Do you want to confirm?");
            if (Program.YesNoStatement())
            {
                order.SetNewState(OrderState.confirmed);
                Console.WriteLine("Confirmed!");
            }
        }

        
    }
}
