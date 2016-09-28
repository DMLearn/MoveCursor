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
        //TODO: Abfrage ob in der letzten Minute sich die Position des Cursors verändert hat.
        //      JA: Benutzer arbeitet gerade
        //      NEIN: Die X-Position des Cursors um -1 imkrementieren 

        /// <summary>
        /// aktuelle Cursor Position ermitteln. Quellecode von http://www.blackwasp.co.uk/GetCursorPos.aspx
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        #region
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        static int _x, _y;

        public struct POINT
        {
            public int X;
            public int Y;
        }

        static void ShowMousePosition()
        {
            POINT point;
            if (GetCursorPos(out point) && point.X != _x && point.Y != _y)
            {
                Console.Clear();
                Console.WriteLine("({0},{1})", point.X, point.Y);
                _x = point.X;
                _y = point.Y;
            }
        }
        #endregion


        /// <summary>
        /// Konsolen Fenster einstellen. Quellcode von https://limbioliong.wordpress.com/2011/10/14/minimizing-the-console-window-in-c/
        /// </summary>
        /// <returns></returns>
        #region
        /*[DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        const int SW_MINIMIZE = 6;*/
        #endregion


        static void Main(string[] args)
        {
            //Konsolen Titel festlegen
            //Console.Title = "Team Weltherschaft - Energiesparmodus veralbern";

            //Fenstergröße der Konsole voreinstellen
            //Console.SetWindowSize(50, 5);

            //Konsolen Farbe einstellen
            //Console.ForegroundColor = ConsoleColor.Green;

            //Konsole beim Start minimieren
            //var handle = GetConsoleWindow();
            //ShowWindow(handle, SW_SHOW);

            //TODO : create object of class ConsoleView

            while (true)
            {
                //aktuelle Cursor Position ermitteln
                ShowMousePosition();
            }





            //Schrift Font der Konsole einstellen


            //Konsole automatisch minimieren beim Start

        }
    }
}
