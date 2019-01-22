using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrarWars
{
    //2 типа сообщений передаваемых в событие
    enum RequestType
    {
        AdRequest,
        PersonalMessageRequest
    };
    //класс который передает сведения о событии
    class UserRequestEventArgs : EventArgs
    {
        private RequestType request;
        public UserRequestEventArgs(RequestType request) : base()
        {
            this.request = request;
        }
        public RequestType Request
        {
            get { return request; }
        }
    }

    //-----------------------------------------------------//
    //генератор событий
    //
    class UserInputMonitor
    {
        public delegate void UserRequest(object sender,UserRequestEventArgs e);
        public event UserRequest OnUserRequest;
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Select prefered option");
                Console.WriteLine("Request advertisement - hit A then return");
                Console.WriteLine("Request personal message from Mortimer - hit P then return");
                Console.WriteLine("Exit - hit X then return");
                string respons = Console.ReadLine();
                char responsChar = respons.ToCharArray().First<char>();
                switch (responsChar)
                {
                    case 'A':
                        OnUserRequest(this, new UserRequestEventArgs(RequestType.AdRequest));
                        break;
                    case 'P':
                        OnUserRequest(this, new UserRequestEventArgs(RequestType.AdRequest));
                        break;
                    case 'X':
                        return;
                }
            }
        }
    }

    //-----------------------------------------------------//
    //Класс клиента 
    //
    class MessageDisplay
    {
        public MessageDisplay(UserInputMonitor monitor)
        {
            monitor.OnUserRequest += new UserInputMonitor.UserRequest(UserRequestHandler);
        }
        //Обработчик события OnUserRequest
        protected void UserRequestHandler(object sender,UserRequestEventArgs e)
        {
            switch (e.Request)
            {
                case RequestType.AdRequest:
                    Console.WriteLine("Mortimer Phone is better then anyone else"+
                    "because \nall our software is written in C#\n");
                    break;
                case RequestType.PersonalMessageRequest:
                    Console.WriteLine("Today Mortimer issued the following statment:\nNevermore\n");
                    break;
            }   
        }
    }
    class ManagersStaffMonitor
    {
        public ManagersStaffMonitor(UserInputMonitor monitor)
        {
            monitor.OnUserRequest += new UserInputMonitor.UserRequest(UserRequestHandler);
        }
        //обработчик события 
        protected void UserRequestHandler(object sender,UserRequestEventArgs e)
        {
            if (e.Request == RequestType.PersonalMessageRequest)
                Console.WriteLine("Kaark!,say Mortimer...");
        }
    }
}
