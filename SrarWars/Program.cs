
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace SrarWars
{
     //Size the batlefield 
     //x=90 y=30
     
    class Program
    {
        static void Main(string[] args)
        {
            //System.Temers.Timer
            //Create timer that call OnTimeEvent method every second and draw ship in console 


            ////////////////////////////////////////////////////////////////////////////////////////////
            // Use System.Threading.Timer for example                                                 //
            //every 2,5 secomds program start method 'AddNewShip'                                     //
            //TimerCallback _createShip = new TimerCallback(_manage.AddNewShip);                      //
            //System.Threading.Timer _times = new System.Threading.Timer(_createShip,null,1100, 2500);//
            ////////////////////////////////////////////////////////////////////////////////////////////

            MyStarShip _myFirsSpaceShip = new MyStarShip(45,27);
            ManagerCreatingEnemyShips _manage = new ManagerCreatingEnemyShips(new System.Timers.Timer());

            _manage.AddNewShip();
            _manage.TimerStart();

            while (true)
            {
                ConsoleKeyInfo _informationOfPressKey = Console.ReadKey();
                if (_informationOfPressKey.KeyChar == 'a')
                    _myFirsSpaceShip.MoveShipByScreen();
                if (_informationOfPressKey.KeyChar == 'd')
                    _myFirsSpaceShip.MoveShipByScreenInLeft();
                if (_informationOfPressKey.KeyChar == 'z')
                    break;
            }
        }
    }

    internal abstract class StarShip
    {
        private int start_pozition_X;
        private int start_pozition_Y;
        public StarShip(int x,int y)
        {
            start_pozition_X = x;
            start_pozition_Y = y;
        }

        public int GetStartPozitionX
                {
                  get { return start_pozition_X;}
                  set { start_pozition_X = value; }
                }
        public int GetStartPozitionY
                {
                  get { return start_pozition_Y; }
                  set { start_pozition_Y = value; }
                }
        abstract public void DrawShipOnScreenInPozition(int _pozition_x,int _pozition_y);
        abstract public void Shoot();
        abstract public void MoveShipByScreen();
    }

    //---------------------------------------//
    //Просмотреть методы чет херь какая-то)))//
    //---------------------------------------//
    internal class MyStarShip : StarShip
    {
        public MyStarShip(int x, int y) : base(x, y)
        {
        }
        public override void DrawShipOnScreenInPozition(int _pozition_X,int _pozition_Y)
        {
            Console.SetCursorPosition(_pozition_X, _pozition_Y);
            Console.Write("||-||");
        }
        public override void MoveShipByScreen()
        {           
            this.DrawShipOnScreenInPozition(this.GetStartPozitionX-=1,25);         
        }
        public void MoveShipByScreenInLeft()
        {
            this.DrawShipOnScreenInPozition(this.GetStartPozitionX+=1,25);
        }
        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
    internal class EnemiesStarShip : StarShip
    {
        public EnemiesStarShip(int x, int y) : base(x, y)
        {
        }

        public override void DrawShipOnScreenInPozition(int _pozition_x, int _pozition_y)
        {
            Console.SetCursorPosition(_pozition_x, _pozition_y);
            Console.Write("|<>|");
        }
        public override void MoveShipByScreen()
        {
            this.DrawShipOnScreenInPozition(this.GetStartPozitionX, this.GetStartPozitionY++);
        }
        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }

    //----------------------------------------//
    //--------управлеющий класс кораблей------//
    //----------------------------------------//
    internal class ManagerCreatingEnemyShips
    {
            //colection enemy ships on the console screen
            private List<StarShip> _countEnemyShip;
            private Random _cordinatsShips;
            private System.Timers.Timer _time;
            public ManagerCreatingEnemyShips(System.Timers.Timer _time)
            {
                this._time = _time;
                this._time.Interval = 400;
                this._time.Elapsed += OnTimerHandler;

                this._countEnemyShip = new List<StarShip>();
                this._cordinatsShips = new Random();
            }

        public void AddNewShip()
        {
            for (int i = 0;i<5;i++)
            {
                int _pozitionX = _cordinatsShips.Next(2,73);
                EnemiesStarShip _enemy = new EnemiesStarShip(_pozitionX, 1);
                _countEnemyShip.Add(_enemy);
            }
        }
        private void MoveAllEnemyShip()
        {
            foreach (EnemiesStarShip _enemStarShip in _countEnemyShip)
            {
                _enemStarShip.MoveShipByScreen();

                if (_enemStarShip.GetStartPozitionY > 25)
                {
                    _time.Stop();
                    _countEnemyShip.Clear();
                    AddNewShip();
                    _time.Start();
                }
            }
        }
        public void TimerStart()
        {
            _time.Start();
        }
        public void StopTimer()
        {
            _time.Stop();
        }

        //Обработчик события истечения таймера
        private void OnTimerHandler(object sender,ElapsedEventArgs e)
        {
            if (_countEnemyShip.Count != 0)
            {
                //Console.Clear();
                MoveAllEnemyShip();
            }
        }
    }
    //--------------------------------------//
    //                                      //
    //--------------------------------------//
}
/*ConsoleKeyInfo _informationOfPressKey = Console.ReadKey();
                if (_informationOfPressKey.KeyChar == 'a')
                    _MyFirsSpaceShip.MoveShipByScreen(true);
                    if (_informationOfPressKey.KeyChar == 'd')
                        _MyFirsSpaceShip.MoveShipByScreen(false);
                        if(_informationOfPressKey.KeyChar=='z')
                        break;
                        
*/

