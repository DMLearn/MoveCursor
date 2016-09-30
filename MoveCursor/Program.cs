using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace MoveCursor
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            ConsoleView view = new ConsoleView();
            AnwendungsController controller = new AnwendungsController(view);

            controller.Ausfuehren();

        }
    }
}
