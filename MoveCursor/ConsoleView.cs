using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/*
 * Author: David Minker
 * --------------------
 * Sample source code for console windows adjustment
 * found on https://limbioliong.wordpress.com/2011/10/14/minimizing-the-console-window-in-c/
 * --------------------
 */
namespace MoveCursor
{

 
    public enum Display
    {
        Hide = 0,
        Show = 5,
        Minimize = 6
    }

    class ConsoleView
    {

       [DllImport( "user32.dll" )]
       static extern IntPtr GetConsoleWindow();
       [DllImport( "kernel32.dll" )]
       static extern bool ShowWindow( IntPtr hWnd, int nCmdShow );

        //Konstruktor
        public ConsoleView()
        {
            //Konsolen Titel festlegen
            Console.Title = "Team Weltherschaft - Energiesparmodus veralbern";

            //Fenstergröße der Konsole voreinstellen
            Console.SetWindowSize( 50, 5 );

            //Konsolen Farbe einstellen
            Console.ForegroundColor = ConsoleColor.Green;

            var handle = GetConsoleWindow();
            ShowWindow( handle, (int)Display.Show );

        }
        


    }
}
