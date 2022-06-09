using System;
using System.Text;
using System.IO;

namespace InternetShopConsole
{
    class Program
    {
        static User user;
        static Menu menu;
        static int menuSizeClient = 4;
        static int menuSizeSeller = 1;
        static int menuSizeAdmin = 2;

        public static string fileOrderPath = @"c:\IntertnetShop\InternetShopConsole\order.txt";
        public static string fileCatalogPath = @"c:\IntertnetShop\InternetShopConsole\catalog.txt";
        public static string fileClientPath;
        static void Main(string[] args)
        {
            OpenStartMenu();
            menu.OpenMenu();
        }
        static void OpenStartMenu()
        {
            Console.Write("Enter your role: ");
            string id = Console.ReadLine();
            Console.Write("Enter your password:");
            string password = Console.ReadLine();
            switch (id)
            {
                case "Client":
                    {
                        Console.WriteLine("Would you enter the adress, please?");
                        if (YesNoStatement())
                        {
                            Console.Write("Enter adress:"); string adress = Console.ReadLine();
                            user = new Client(id, password, adress);
                        }
                        else
                        {
                            user = new Client(id, password);
                        }
                        fileClientPath = @"c:\InternetShop\InternetShopConsole\" + user.id + ".txt";
                        FileWorker file = new FileWorker(fileClientPath);
                        if (IsFileExist(fileClientPath))
                        {
                            user = file.readClientFromFile();
                        }
                        else file.writeClientToFile((Client)user);
                        menu = new MenuClient(menuSizeClient, (Client)user);
                        break;
                    }
                case "Seller":
                    {
                        Console.Write("Enter cashboxNumber: "); int cashboxNumber = Convert.ToInt32(Console.ReadLine());
                        user = new Seller(id, password, cashboxNumber);
                        menu = new MenuSeller((Seller)user, menuSizeSeller);
                        break;
                    }
                case "Admin":
                    {
                        Console.Write("Name yourself!"); string name = Console.ReadLine();
                        user = new Admin(id, password, name);
                        menu = new MenuAdmin(menuSizeAdmin, (Admin)user);
                        break;
                    }
                default: { break; }
            }
            Console.WriteLine("Authorization successful...");
            return;
        }

        public static void ClearTheLine()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.Write(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(x, y);
        }

        public static bool YesNoStatement()
        {
            int menuPosition = 0;
            const int menuSize = 2;
            string[] stance = { "Yes", "No" };
            int _x = Console.CursorLeft;
            int _y = Console.CursorTop;
            while (true)
            {
                Console.SetCursorPosition(_x, _y);
                for (int i = 0; i < menuSize; i++)
                {
                    if (menuPosition == i)
                    {
                        Console.Write("=>" + stance[i]);
                    }
                    else
                    { 
                        Console.Write("  " + stance[i]);
                    }
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (menuPosition > 0) menuPosition--;
                        else if (menuPosition == 0)
                            menuPosition = menuSize - 1;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (menuPosition < menuSize - 1) menuPosition++;
                        else if (menuPosition == menuSize - 1) menuPosition = 0;
                        break;
                    case ConsoleKey.Enter:
                        return (menuPosition == 0) ? true : false;
                }
            }
        }

        public static bool YesNoStatement(string one, string two)
        {
            int menuPosition = 0;
            const int menuSize = 2;
            string[] stance = { one, two };
            int _x = Console.CursorLeft;
            int _y = Console.CursorTop;
            while (true)
            {
                Console.SetCursorPosition(_x, _y);
                for (int i = 0; i < menuSize; i++)
                {
                    if (menuPosition == i)
                    {
                        Console.Write("=>" + stance[i]);
                    }
                    else
                    {
                        Console.Write("  " + stance[i]);
                    }
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (menuPosition > 0) menuPosition--;
                        else if (menuPosition == 0)
                            menuPosition = menuSize - 1;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (menuPosition < menuSize - 1) menuPosition++;
                        else if (menuPosition == menuSize - 1) menuPosition = 0;
                        break;
                    case ConsoleKey.Enter:
                        return (menuPosition == 0) ? true : false;
                }
            }
        }

        public static bool IsFileExist(string _filePath)
        {
            return ((new FileInfo(_filePath)).Exists) ? true : false;
        }

        public static bool IsFileEmpty(string _filePath)
        {
            return ((new FileInfo(_filePath)).Length == 0)? true : false;
        }

    }
   
}
