using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessMemoryCounters
    {
        public uint cb;
        public uint PageFaultCount;
        public int  PeakWorkingSetSize;
        public int  WorkingSetSize;
        public int  QuotaPeakPagedPoolUsage;
        public int  QuotaPagedPoolUsage;
        public int  QuotaPeakNonPagedPoolUsage;
        public int  QuotaNonPagedPoolUsage;
        public int  PagefileUsage;
        public int  PeakPagefileUsage;
        public int  PrivateUsage;
    }
}
