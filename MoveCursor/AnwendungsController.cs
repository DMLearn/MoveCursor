using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            while (true)
            {
                view.ShowMousePosition();
            }
        }


    }
}
