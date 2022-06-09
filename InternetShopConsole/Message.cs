using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class Message
    {
        string userId, text;

        public Message(string _userId, string _text)
        {
            userId = _userId;
            text = _text;
        }

        public void DisplayMessage()
        {
            Console.WriteLine(userId + " : " + text );
        }

        public string GetId()
        {
            return userId;
        }

        public string GetText()
        {
            return text;
        }
    }
}
