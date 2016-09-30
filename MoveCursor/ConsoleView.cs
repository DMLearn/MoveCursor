using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Configuration;

/*
 * Author: David Minker
 * --------------------
 * Sample source code for console windows adjustment found on
 * https://limbioliong.wordpress.com/2011/10/14/minimizing-the-console-window-in-c/
 * --------------------
 * Sample source code for reading the cursor position found on
 * http://www.blackwasp.co.uk/GetCursorPos.aspx
 * --------------------
 */
namespace MoveCursor
{

    public struct POINT
    {
        public int X;
        public int Y;
    }

    class ConsoleView
    {
        //Variablen und Eigenschaften
        #region
        public POINT point { get; private set; }
        public bool CursorMoved { get; private set; }

        private int _x, _y;
        #endregion

        //DLL Import
        #region  
        [DllImport( "user32.dll" )]
        static extern bool ShowWindow( IntPtr hWnd, int nCmdShow );
   
        [DllImport( "kernel32.dll" )]
        static extern IntPtr GetConsoleWindow();
        
        [DllImport( "user32.dll" )]
        static extern bool GetCursorPos( out POINT lpPoint );
        #endregion

        //Konstruktor
        public ConsoleView()
        {
            //Konsolen Titel festlegen
            Console.Title = "Team Weltherschaft - Energiesparmodus veralbern";

            //Fenstergröße der Konsole voreinstellen
            Console.SetWindowSize( 50, 5 );

            //Konsolen Farbe einstellen
            Console.ForegroundColor = ConsoleColor.Green;
    
            int DisplayMode = ReadConfig(); //Default mode is show
            /*  Hide = 0;
            *  Show = 5;
            *  Minimize = 6;
            */

            CursorMoved = false;
            _x = 0;
            _y = 0;

            var handle = GetConsoleWindow();
            ShowWindow( handle, DisplayMode );            

        }

        //TODO: Wenn Zeit ist, die Abfrage der config in den Controller verlegen
        private int ReadConfig()
        {
            string displayMode = ConfigurationManager.AppSettings["displayMode"].ToLower();
            switch (displayMode)
            {
                case "hide":
                    return 0;
                case "show":
                    return 5;
                case "minimize":
                    return 6;
                default:
                    return 5;
            }

        }



        public void ShowMousePosition(int _x, int _y, POINT point)
        {
            Console.Clear();
            Console.WriteLine( "Aktuelle Mausposition: X: {0}, Y: {1})", point.X, point.Y );
            Console.WriteLine(CursorMoved);

          }

        public void CheckCursorMovement()
        {
            POINT point;
            if (GetCursorPos(out point) && point.X != _x && point.Y != _y)
            {
                _x = point.X;
                _y = point.Y;
                CursorMoved = true;
            }
            else
                CursorMoved = false;

            ShowMousePosition(_x, _y, point);
        }




    }
}
