using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class MenuAdmin : Menu
    {
        Admin user;
        const string filePath = @"c:\IntertnetShop\InternetShopConsole\catalog.txt";
        public MenuAdmin( int _menuSize, Admin _user) : base( _user,_menuSize)
        {
            menuCases = new string[] { "1 -  Open catalog;" ,
                                   "2 -  Exit;" };
            user = _user;
        }

        public override void decision(int menuPosition)
        {
            switch (menuPosition)
            {
                case 0:
                    {
                        Catalog catalog = new Catalog();
                        FileWorker file = new FileWorker(filePath);
                        catalog.SetProducts(file.readProductListFromFile());
                        Menu menuCatalog = new MenuCatalog(user, 4, catalog);
                        menuCatalog.OpenMenu();
                        file.writeProductListInFile(catalog.GetProducts());
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
