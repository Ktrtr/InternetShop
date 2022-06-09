using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InternetShopConsole
{
    class MenuClient : Menu
    {
        Client user;
        public MenuClient(int _menuSize, Client _user) : base(_user,_menuSize)
        {
            user = _user;
            menuCases =  new string[] { "1 -  Show catalog;" ,
                                        "2 -  Open personal information;",
                                        "3 -  Show basket;",
                                        "4 -  Check your Orders"
            };
        }

        public override void decision(int menuPosition)
        {
            switch (menuPosition)
            {
                case 0:
                    {
                        Catalog catalog = new Catalog();
                        FileWorker file = new FileWorker(Program.fileCatalogPath);
                        catalog.SetProducts(file.readProductListFromFile());
                        while (true)
                        {
                            catalog.ShowAllProducts();
                            Console.WriteLine("Press Enter if you want to add something or press Esc to escape this menu.");
                            if (Program.YesNoStatement())
                            {
                                user.AddToBasket(catalog);
                                Console.Clear();
                            }
                            else break;
                        }
                        file.writeProductListInFile(catalog.GetProducts());
                        break;
                    }
                case 1:
                    {
                        user.DisplayPersonalInfo();
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Basket");
                        FileWorker file = new FileWorker(Program.fileOrderPath);
                        user.ShowBasket();
                        Order order = new Order();
                        if (Program.IsFileExist(Program.fileOrderPath) && !Program.IsFileEmpty(Program.fileOrderPath))
                        {
                            order = file.readOrderFromFile();
                        }
                        if (order != null && order.GetState() == OrderState.none && user.GetBasket().Count != 0)
                        {
                            Console.WriteLine("Do you want to create new order?");
                            if (Program.YesNoStatement())
                            {
                                order = new Order(user, user.GetBasket());
                                file.writeOrderInFile(order);
                            }
                        }
                        else Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Order");
                        FileWorker file = new FileWorker(Program.fileOrderPath);
                        Order order = file.readOrderFromFile();
                        if (order != null) order.DisplayOrder();
                        else { Console.WriteLine("Order is empty"); }
                        if (order != null)
                        {
                            ChangingOrderCondition(order);
                            file.writeOrderInFile(order);
                        }
                        Console.ReadKey();
                        break;
                    }
                default: break;
            }
        }

        void ChangingOrderCondition(Order order)
        {
            switch (order.GetState())
            {
                case OrderState.none:
                    Console.WriteLine("Do you want to registrate this order");
                    if (Program.YesNoStatement())
                    {
                        order.SetNewState(OrderState.registrated);
                    }
                    break;
                case OrderState.registrated:
                    {
                        Console.WriteLine("Do you want to pay for this order");
                        if (Program.YesNoStatement())
                        {
                            user.PayTheOrder(order);
                        }
                        break;
                    }
                case OrderState.confirmed:
                    {
                        Console.WriteLine("Order was completely paid and confirmed by a seller");
                        Console.WriteLine("Choose if you want to recieve order by delivery:");
                        if (Program.YesNoStatement())
                        {
                            user.RecieveDeliveryOrder();
                        }
                        else
                        {
                            user.RecieveOrder(order);
                        }
                        break;
                    }                    
                case OrderState.paid:
                    {
                        Console.WriteLine("You have completely registrated and paid for order");
                        break;
                    }
                case OrderState.declined:
                    Console.WriteLine("There is no registrated orders");
                    break;
                case OrderState.sended:
                    {
                        Console.WriteLine("Order was send to your adress" +
                        "");
                        int x = Console.CursorLeft; int y = Console.CursorTop;
                        for (int i = 5; i > 0; i--)
                        {
                            Console.WriteLine("Order will be recieved in: " + i + "sec");
                            Console.SetCursorPosition(x, y);
                            Thread.Sleep(1000);
                        }
                        Program.ClearTheLine();
                        Console.WriteLine("Reload the page");
                        order.SetNewState(OrderState.recieved);
                        break;
                    }                  
                case OrderState.recieved:
                    {
                        Console.WriteLine("Order was completely recieved");
                        OrderCheck orderCheck = new OrderCheck(order,user);
                        orderCheck.DisplayTheCheck();
                        break;
                    }                    
            }
        }

    }
}
