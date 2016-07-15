using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessBasicInformation
    {
        public int      ExitStatus;
        public IntPtr   PebBaseAddress;
        public int      AffinityMask;
        public int      BasePriority;
        public int      UniqueProcessId;
        public int      InheritedFromUniqueProcessId;
    }
}
