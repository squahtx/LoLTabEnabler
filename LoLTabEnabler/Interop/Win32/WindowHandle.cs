using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    public static class WindowHandle
    {
        public static IntPtr Bottom { get { return (IntPtr)1; } }
        public static IntPtr NoTopMost { get { return (IntPtr)(-2); } }
        public static IntPtr Top { get { return (IntPtr)0; } }
        public static IntPtr TopMost { get { return (IntPtr)(-1); } }
    }
}
