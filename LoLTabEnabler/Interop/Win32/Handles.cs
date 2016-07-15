using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LoLTabEnabler.Interop.Win32
{
    public static class Handles
    {
        [DllImport("kernel32.dll")]
        public extern static bool CloseHandle(IntPtr hObject);
    }
}
