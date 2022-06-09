using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    abstract class Menu
    {
        private User user;
        protected int x;
        protected int y;
        protected int menuSize;
        protected int menuPosition;
        protected string[] menuCases;
 
        public Menu(User _user,int _menuSize)
        {
            user = _user;
            x = 0;
            y = 0;
            menuSize = _menuSize;
            menuPosition = 0;
        }

        public void OpenMenu()
        {
            while (true)
            {
                Console.Clear();
                //x = Console.WindowWidth - ("Press Esc to back").Length;
                //y = Console.WindowHeight - 1;
                //Console.SetCursorPosition(x, y);
                Console.Write("Press Esc to back");
                //x = (Console.WindowWidth / 2) - ((user.definition.Length + user.id.Length + user.password.Length + 2) / 2);
               // Console.SetCursorPosition(x, 0);
                Console.WriteLine(user.definition + ":" + user.id + " " + user.password);
                for (int i = 0; i < menuSize; i++)
                {
                  //  x = (Console.WindowWidth / 2) - (menuCases[i].Length / 2);
                    //y = (Console.WindowHeight / 2) + i;
                    //Console.SetCursorPosition(x, y);
                    if (i == menuPosition)
                        Console.WriteLine("=>" + menuCases[i]);
                    else
                        Console.WriteLine("  " + menuCases[i]);
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape) return;
                scrollInfo(key);      
            }

        void scrollInfo(ConsoleKey key)
        {
                switch (key)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {
                            if (menuPosition < menuSize - 1) menuPosition++;
                            else if (menuPosition == menuSize - 1) menuPosition = 0;
                            break;
                        }
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        {
                            if (menuPosition > 0) menuPosition--;
                            else if (menuPosition == 0)
                                menuPosition = menuSize - 1;
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            Console.Clear();
                            decision(menuPosition);
                        }
                        break;
                }
            }
        }
        public virtual void decision(int menuPoisition)
        {
            Console.WriteLine("Virtual Shit");
            Console.ReadKey();
        }

        /*
        string[] IdParolFromDoc()
        {
            return;
        }
        */
    }
}
