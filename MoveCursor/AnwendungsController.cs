using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace MoveCursor
{
    class AnwendungsController
    {
        private ConsoleView view;

        public AnwendungsController(ConsoleView view)
        {
            this.view = view;
        }

        public void Ausfuehren()
        {

            int timerInterrrupt = Convert.ToInt16( ConfigurationManager.AppSettings["timerInterrupt"] );
            int countTime = 0;

            while (true)
            {
                //TODO: create timer for countTime variable in steps of 1 sekunde
                view.CheckCursorMovement();
                view.DisplayResults(countTime);

            }
        }




    }
}
