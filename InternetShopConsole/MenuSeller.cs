using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class MenuSeller : Menu
    {
        Seller user;
        public MenuSeller(Seller _user, int _menuSize) : base(_user, _menuSize)
        {
            user = _user;
            menuCases = new string[] { "1 - Orders;" };
        }
        public override void decision(int menuPosition)
        {
            switch (menuPosition)
            {
                case 0:
                    {
                        Console.WriteLine("Orders");
                        FileWorker file = new FileWorker(Program.fileOrderPath);
                        Order order = file.readOrderFromFile();
                        order.DisplayOrder();
                        if (order.GetState() == OrderState.paid)
                        {
                            user.ConfirmOrder(order);
                            file.writeOrderInFile(order);
                        }
                        else Console.WriteLine("Order can't be confirmed");
                        Console.ReadKey();
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Exit");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
