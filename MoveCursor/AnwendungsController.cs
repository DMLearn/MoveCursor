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

        Int16 configTime = 30; //Default value
        Int16 configTimeMax = 600;
        Int16 countTime = 0;
        int cursorIncrement = 1;

        public void Ausfuehren()
        {

            ReadConfig();
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

        private void ReadConfig()
        {
            string configTimeAsString = ConfigurationManager.AppSettings["timerInterrupt"];
            Int16 result = 0;

            if (Int16.TryParse(configTimeAsString, out result) == true)
            {
                result = Convert.ToInt16( configTimeAsString );

                if (result > configTimeMax)
                {
                    configTime = configTimeMax;
                }
                else
                {
                    configTime = result;
                }
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

                cursorIncrement = cursorIncrement * (-1); //Toggle cursorIncrement such that original position is reached again after 2 loops
                view.IncrementCursor(cursorIncrement);
            }
                
        }





    }
}
