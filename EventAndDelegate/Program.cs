/*using System;
using System.Collections.Generic;
using System.Linq;

namespace EventAndDelegate
{
    //2 типа сообщений передаваемых в событие
    enum RequestType
    {
        AdRequest,
        PersonalMessageRequest
    };
    class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////////////////////////
            //this code don't so correctly work ,like write in the book                     //
            //UserInputMonitor _userInputMonitor = new UserInputMonitor();                  //
            //MessageDisplay _inputProcessor = new MessageDisplay(_userInputMonitor);       //
            //ManagersStaffMonitor _martimer = new ManagersStaffMonitor(_userInputMonitor); //
            //_userInputMonitor.Run();                                                      //
            //////////////////////////////////////////////////////////////////////////////////

            GeneratorEventov _generate = new GeneratorEventov();
            _generate.SendMessage += KlientHandler;

            int i = 0;
            while (i!=3)
            {
                _generate.GenerateMessage();
                i++;
            }         
        }

        static void KlientHandler(object sender,RequestEventnArgs e)
        {
            Console.WriteLine("This send mess - " + e.Message);
        }
    }

    #region
    //-----------------------------------------------------//
    //------класс который передает сведения о событии------//
    //-----------------------------------------------------//
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
    //-----------------генератор событий-------------------//
    //-----------------------------------------------------//
    class UserInputMonitor
    {
        public delegate void UserRequest(object sender, UserRequestEventArgs e);
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
    //--------------------Класс клиента--------------------// 
    //-----------------------------------------------------//
    class MessageDisplay
    {
        public MessageDisplay(UserInputMonitor monitor)
        {
            monitor.OnUserRequest += new UserInputMonitor.UserRequest(UserRequestHandler);
        }
        //Обработчик события OnUserRequest
        protected void UserRequestHandler(object sender, UserRequestEventArgs e)
        {
            switch (e.Request)
            {
                case RequestType.AdRequest:
                    Console.WriteLine("Mortimer Phone is better then anyone else" +
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
        protected void UserRequestHandler(object sender, UserRequestEventArgs e)
        {
            if (e.Request == RequestType.PersonalMessageRequest)
                Console.WriteLine("Kaark!,say Mortimer...");
        }
    }
    #endregion

    #region
    /// <summary>
    /// My example with eventom. Parametr 'messege' was sended through class 'EventArgs'
    /// As for transfer of the parametrs in the eventhandler,this option maybe not so bad practic in codding)))
    /// but i am not sure.
    /// I have to find more information on this topic!!!!!!!
    /// </summary>  
    ///////////////////////////////////////////
    //////////класс издатель событий///////////
    ///////////////////////////////////////////
    public class GeneratorEventov
    {
        public delegate void PresentOurMesseges(object sender,RequestEventnArgs e);
        public event PresentOurMesseges SendMessage;

        public void GenerateMessage()
        {
            string _message1;
            Console.Write("Enter message:");
            _message1 = Console.ReadLine();
            SendMessage(this, new RequestEventnArgs(_message1));
        }
    }

    ///////////////////////////////////////////
    ////// передаем информацию о событии///////
    ///////////////////////////////////////////
    public class RequestEventnArgs : EventArgs
    {
        private string _message;
        public RequestEventnArgs(string _message)
        {
            this._message = _message;
        }

        public string Message { get { return _message; } }
    }

    ///////////////////////////////////////////
    /////////Клиент подписанный на соытия//////
    ///////////////////////////////////////////
    #endregion
}
*/