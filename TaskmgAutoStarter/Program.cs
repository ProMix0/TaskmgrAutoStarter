using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace TaskmgAutoStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Process manager= Process.Start("taskmgr.exe");
                Console.WriteLine("Started");
                while (manager.MainWindowHandle.ToInt32() == 0) Thread.Sleep(10);
                ShowWindow(manager.MainWindowHandle, 6);
                manager.WaitForExit();
            }
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
