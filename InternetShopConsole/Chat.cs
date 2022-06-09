using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopConsole
{
    class Chat
    {
        string chatId;
        string userId;
        List<Message> chatInfos = new List<Message>() { };
        
        public Chat(string _chatId, List<Message> _chatInfos)
        {
            chatId = _chatId;
            chatInfos = _chatInfos;
        }
        
        public Chat(string _ChatId, string _UserId)
        {
            chatId = _ChatId;
            userId = _UserId;
        }

        public void UserAppendsChat()
        {
            Console.Write(" Write here -> ");
            string line = Console.ReadLine();
            chatInfos.Add(new Message(userId,line));
        }

        public void DisplayChat()
        {
            Console.WriteLine(" ChadID : " + chatId);
            if (chatInfos != null)
            {
                foreach (Message text in chatInfos)
                {
                    text.DisplayMessage();
                }
            }
            else Console.WriteLine(chatId + "is empty");
            
        }

        public List<Message> GetChatInfos()
        {
            return chatInfos;
        }

        public string GetChatId()
        {
            return chatId;
        }

        public void SetUserId(string line)
        {
            userId = line;
        }
    }
}
