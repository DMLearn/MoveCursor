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

        public string displayMode { get; private set; }

        public AnwendungsController(ConsoleView view)
        {
            this.view = view;
        }

        public void Ausfuehren()
        {


            while (true)
            {
                ReadConfig();
                view.ShowMousePosition();
            }
        }

        private void ReadConfig()
        {
            string test = ConfigurationManager.AppSettings["displayMode"];

        }


    }
}
