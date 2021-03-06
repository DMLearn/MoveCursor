﻿using System;
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

        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class ConsoleView
    {
        //Variablen und Eigenschaften
        #region
        public bool CursorMoved { get; set; }
        POINT pointNew = new POINT(0, 0);
        POINT pointOld = new POINT(0, 0);
        #endregion

        //DLL Import
        #region  
        [DllImport( "user32.dll" )]
        static extern bool ShowWindow( IntPtr hWnd, int nCmdShow );
   
        [DllImport( "kernel32.dll" )]
        static extern IntPtr GetConsoleWindow();
        
        [DllImport( "user32.dll" )]
        static extern bool GetCursorPos( out POINT lpPoint );

        [DllImport( "user32.dll" )]
        static extern bool SetCursorPos( int x, int y );
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

            //Window mode: Hide = 0, Show = 5, Minimize = 6 ===> Default moder is set to Show
            int DisplayMode = ReadConfig(); 

            CursorMoved = false;

            var handle = GetConsoleWindow();
            ShowWindow( handle, DisplayMode );            

        }

        //TODO: Wenn Zeit ist, die Abfrage der config in den Controller verlegen
        //TODO:  Zahlen größer 600 nicht zu lassen
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

        public void PrintHelloScreen()
        {
            Console.Clear();
            Console.WriteLine("PSE - Tanz für mich kleine Maus !");
            Console.WriteLine("*********************************");
        }

        public void DisplayResults(int time)
        {
            PrintHelloScreen();
            Console.WriteLine( "Noch {0}s bis zum nächsten Tanz der Maus.", time );

          }

        public void CheckCursorMovement()
        {
            if (GetCursorPos(out pointNew) && pointNew.X != pointOld.X && pointNew.Y != pointOld.Y)
            {
                pointOld.X = pointNew.X;
                pointOld.Y = pointNew.Y;
                CursorMoved = true;
            }
        }

        public void IncrementCursor(int deltaX)
        {
            SetCursorPos( pointNew.X + deltaX, pointNew.Y );

        }

    }
}
