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

            while (true)
            {

                //TODO: create timer for countTime variable in steps of 1 sekunde
                view.CheckCursorMovement();
                view.DisplayResults(countTime);

            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            countTime --;
        }





    }
}
