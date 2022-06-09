using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class Admin : User
    {
        string name { get; set; }

        public Admin(string _id, string _parol, string _name) : base(_id, _parol)
        {
            name = _name;
            definition = "Admin";
            Console.WriteLine("Admin constructor has been done");
        }
    }
}
