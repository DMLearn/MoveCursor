﻿using System.Runtime.InteropServices;

class WINAPI
{
    [DllImport( "user32.dll", SetLastError = true )]
    public static extern void mouse_event( uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo );

    public enum MouseFlags
    {
        MOUSEEVENTF_ABSOLUTE = 0x8000,
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_MOVE = 0x0001,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100
    }

    public enum DataFlags
    {
        XBUTTON1 = 0x0001,
        XBUTTON2 = 0x0002
    }
}
