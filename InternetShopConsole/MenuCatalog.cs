using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class MenuCatalog : Menu
    {
        Catalog catalog;
        public MenuCatalog(User _user, int _menuSize, Catalog _catalog) : base(_user, _menuSize)
        {
            menuCases = new string[] { "1 - Show products;",
                                   "2 - Add new products in catalog;",
                                   "3 - Delete all products from catalog;",
                                   "4 - Delete particular product from catalog;",
                                   };
            catalog = _catalog;
        }

        public override void decision(int menuPoisition)
        {
            switch (menuPoisition)
            {
                case 0:
                    {
                        x = (Console.WindowWidth / 2) - (("--- All products from catalog is here ----").Length / 2);
                        Console.SetCursorPosition(x, 0);
                        Console.WriteLine("--- All products from catalog is here ----");
                        catalog.ShowAllProducts();
                        Console.ReadKey();
                        break;
                    }
                case 1:
                    {
                        x = (Console.WindowWidth / 2) - (("--- Add new products in catalog is here ----").Length / 2);
                        Console.SetCursorPosition(x, 0);
                        Console.WriteLine("--- Add new products in catalog is here ----");
                        catalog.AddProducts();
                        break;
                    }
                case 2:
                    {
                        x = (Console.WindowWidth / 2) - (("--- Delete all products from catalog is here ----").Length / 2);
                        Console.SetCursorPosition(x, 0);
                        Console.WriteLine("--- Delete all products from catalog is here ----");
                        catalog.DeteleAllProducts();
                        break;
                    }
                case 3:
                    {
                        x = (Console.WindowWidth / 2) - (("--- Delete paricular product from catalog is here ----").Length / 2);
                        Console.SetCursorPosition(x, 0);
                        Console.WriteLine("--- Delete paricular product from catalog is here ----");
                        Console.Write("Write product id: "); string id = Console.ReadLine();
                        Catalog.DeleteParticularProduct(id, catalog.GetProducts());
                        return;
                    }
            }
        }
    }
}
