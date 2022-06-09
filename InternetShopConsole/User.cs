using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    abstract class User
    {
        public string id { get; set; }
        public string password { get; set; }
        public string definition { get; set; }

        public User() { }
        public User(string _id, string _password)
        {
            id = _id;
            password = _password;
            Console.WriteLine("User constructor has been done");
        }

        public virtual void DisplayPersonalInfo() { }

    }
}
