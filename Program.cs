using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Rumi.GMDBF
{
    public static partial class Program
    {
        [LibraryImport("user32.dll")] private static partial long GetWindowLongPtrA(nint hwnd, int nIndex);
        [LibraryImport("user32.dll")] private static partial long SetWindowLongPtrA(nint hWnd, int nIndex, long dwNewLong);
        [LibraryImport("user32.dll")] [return: MarshalAs(UnmanagedType.Bool)] private static partial bool SetWindowPos(nint hwnd, nint hwndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        static void Main()
        {
            Process[] processList = Process.GetProcesses();
            for (int i = 0; i < processList.Length; i++)
            {
                Process process = processList[i];
                if (process.ProcessName == "GeometryDash")
                    BorderlessWindow(process.MainWindowHandle);
            }
        }

        public static void BorderlessWindow(nint handle)
        {
            const int GWL_STYLE = -16;
            long curStyle = GetWindowLongPtrA(handle, GWL_STYLE);

            const long WS_OVERLAPPED = 0x00000000L;
            const long WS_CAPTION = 0x00C00000L;
            const long WS_MINIMIZEBOX = 0x00020000L;
            const long WS_MAXIMIZEBOX = 0x00010000L;
            const long WS_SYSMENU = 0x00080000L;
            const long WS_MAXIMIZE = 0x01000000L;
            const long WS_THICKFRAME = 0x00040000L;
            const long WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;

            curStyle &= ~WS_OVERLAPPEDWINDOW;
            curStyle |= WS_MAXIMIZE;

            SetWindowLongPtrA(handle, GWL_STYLE, curStyle);

            const int SWP_FRAMECHANGED = 0x0020;
            const int SWP_SHOWWINDOW = 0x0040;
            SetWindowPos(handle, 0, 0, 0, 1280, 720, SWP_FRAMECHANGED | SWP_SHOWWINDOW);
        }
    }
}