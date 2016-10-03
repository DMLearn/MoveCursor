using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Timers;



namespace MoveCursor
{
    class AnwendungsController
    {
        private ConsoleView view;
        public AnwendungsController(ConsoleView view)
        {
            this.view = view;
        }

        private int configTime = Convert.ToInt16( ConfigurationManager.AppSettings["timerInterrupt"] );
        private int countTime = 0;

        public void Ausfuehren()
        {
            countTime = configTime;

            Timer timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent; //If timer is excecuted, OnTimedEvent is processed
            timer.Start();
            view.PrintHelloScreen();

            while (true)
            {
                view.CheckCursorMovement();
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            if (countTime > 0 && view.CursorMoved == false)
            {
                countTime--;
                view.DisplayResults(countTime);
            }
            else if (countTime > 0 && view.CursorMoved == true)
            {
                countTime = configTime;
                view.CursorMoved = false;
                view.DisplayResults(countTime);
            }
            else
            {
                countTime = configTime;
                view.DisplayResults(countTime);
            }
                
        }





    }
}
