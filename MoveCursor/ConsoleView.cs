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

    public struct POINT
    {
        public int X;
        public int Y;
    }

    class ConsoleView
    {

        [DllImport( "user32.dll" )]
        static extern bool ShowWindow( IntPtr hWnd, int nCmdShow );
   
        [DllImport( "kernel32.dll" )]
        static extern IntPtr GetConsoleWindow();
        
        [DllImport( "user32.dll" )]
        static extern bool GetCursorPos( out POINT lpPoint );

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

        private int _x, _y;

        public void ShowMousePosition()
        {
            POINT point;
            if (GetCursorPos( out point ) && point.X != _x && point.Y != _y)
            {
                Console.Clear();
                Console.WriteLine( "({0},{1})", point.X, point.Y );
                _x = point.X;
                _y = point.Y;
            }
        }



    }
}
