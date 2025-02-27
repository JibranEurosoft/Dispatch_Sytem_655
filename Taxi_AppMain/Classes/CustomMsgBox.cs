using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxi_AppMain.Classes
{
    public class CustomMsgBox
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const uint WM_CLOSE = 0x0010;

        public static void ShowAutoClosingMessageBox(string message, string title, int timeout)
        {
            Thread closeThread = new Thread(() =>
            {
                Thread.Sleep(timeout); // Wait for the specified time
                IntPtr hWnd = FindWindow(null, title); // Find the MessageBox by title
                if (hWnd != IntPtr.Zero)
                {
                    PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero); // Close the MessageBox
                }
            });
            closeThread.Start();

            MessageBox.Show(message, title); // Show the MessageBox
        }

        

    }
}
