using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LoLTabEnabler.Interop.Win32
{
    public static class Windows
    {
        [DllImport("user32.dll")]
        public extern static uint CascadeWindows(IntPtr hwndParent, CascadeFlags wHow, IntPtr lpRect, uint cKids, IntPtr lpKids);

        [DllImport("user32.dll", EntryPoint = "FindWindowW", CharSet = CharSet.Unicode)]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public extern static IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongW")]
        public extern static uint GetWindowLong(IntPtr hWnd, WindowProperty nIndex);

        [DllImport("user32.dll")]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongW")]
        public extern static uint SetWindowLong(IntPtr hWnd, WindowProperty nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        public extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport("user32.dll")]
        public extern static bool ShowScrollBar(IntPtr hWnd, ScrollBarVisibility wBar, bool bShow);

        [DllImport("user32.dll")]
        public extern static uint TileWindows(IntPtr hWnd, TilingFlags wHow, IntPtr lpRect, uint cKids, IntPtr lpKids);

        public static void AddExtendedWindowStyle(Control Control, ExtendedWindowStyle ExtendedStyle)
        {
            Windows.AddExtendedWindowStyle(Control.Handle, ExtendedStyle);
        }

        public static void AddExtendedWindowStyle(IntPtr hWnd, ExtendedWindowStyle ExtendedStyle)
        {
            ExtendedWindowStyle NewStyle = Windows.GetExtendedWindowStyle(hWnd);
            NewStyle = NewStyle | ExtendedStyle;
            Windows.SetExtendedWindowStyle(hWnd, NewStyle);
        }

        public static void AddWindowStyle(Control Control, WindowStyle Style)
        {
            Windows.AddWindowStyle(Control.Handle, Style);
        }

        public static void AddWindowStyle(IntPtr hWnd, WindowStyle Style)
        {
            WindowStyle NewStyle = Windows.GetWindowStyle(hWnd);
            NewStyle = NewStyle | Style;
            Windows.SetWindowStyle(hWnd, NewStyle);
        }

        public static void CascadeWindows(IntPtr hwndParent, CascadeFlags wHow)
        {
            Windows.CascadeWindows(hwndParent, wHow, IntPtr.Zero, 0, IntPtr.Zero);
        }

        public static ExtendedWindowStyle GetExtendedWindowStyle(IntPtr hWnd)
        {
            return (ExtendedWindowStyle)Windows.GetWindowLong(hWnd, WindowProperty.ExtendedStyle);
        }

        public static WindowStyle GetWindowStyle(IntPtr hWnd)
        {
            return (WindowStyle)Windows.GetWindowLong(hWnd, WindowProperty.Style);
        }

        public static void RemoveWindowStyle(IntPtr hWnd, WindowStyle Style)
        {
            WindowStyle NewStyle = Windows.GetWindowStyle(hWnd);
            NewStyle = NewStyle & ~Style;
            Windows.SetWindowStyle(hWnd, NewStyle);
        }

        public static ExtendedWindowStyle SetExtendedWindowStyle(IntPtr hWnd, ExtendedWindowStyle ExtendedStyle)
        {
            return (ExtendedWindowStyle)Windows.SetWindowLong(hWnd, WindowProperty.ExtendedStyle, (uint)ExtendedStyle);
        }

        public static void SetParent(Control Child, Control Parent)
        {
            if (Windows.GetParent(Child.Handle) == Parent.Handle)
            {
                return;
            }
            Windows.SetParent(Child.Handle, Parent.Handle);
        }

        public static WindowStyle SetWindowStyle(IntPtr hWnd, WindowStyle Style)
        {
            return (WindowStyle)Windows.SetWindowLong(hWnd, WindowProperty.Style, (uint)Style);
        }

        public static void TileWindows(IntPtr hWnd, TilingFlags wHow)
        {
            Windows.TileWindows(hWnd, wHow, IntPtr.Zero, 0, IntPtr.Zero);
        }
    }
}
