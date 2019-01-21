using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public struct Rect {
    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
}

public static class Win32API {
    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    public static extern IntPtr 
    FindWindow(System.String className, System.String windowName);

    [DllImport("user32.dll")]
    public static extern bool 
    GetWindowRect(IntPtr hwnd, ref Rect rectangle);
}
