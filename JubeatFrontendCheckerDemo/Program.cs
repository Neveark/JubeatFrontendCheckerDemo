using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Timers;

namespace JubeatFrontendCheckerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
			//check jubeat is frontend or not
			System.Timers.Timer timer = new System.Timers.Timer();
			timer.Enabled = true;
			timer.Interval = 3000; //3 seconds  
			timer.Start();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(JubeatFrontendChecker);
			Console.ReadKey();
		}

		private static void JubeatFrontendChecker(object source, ElapsedEventArgs e)
		{
			BringWindowByNameToFront("L44 - jubeat");
			Console.WriteLine("done!");
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hwnd);

		public static IntPtr WinGetHandle(string wName)
		{
			foreach (Process pList in Process.GetProcesses())
				if (pList.MainWindowTitle.Contains(wName))
					return pList.MainWindowHandle;

			return IntPtr.Zero;
		}

		public static void BringWindowByNameToFront(string windowName)
		{
			IntPtr hwnd = WinGetHandle(windowName);
			SetForegroundWindow(hwnd);
		}
	}
}
