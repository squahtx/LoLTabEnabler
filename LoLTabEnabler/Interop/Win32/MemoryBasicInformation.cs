using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LoLTabEnabler.Interop.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryBasicInformation
    {
        public UIntPtr              BaseAddress;
        public UIntPtr              AllocationBase;
        public MemoryProtection     AllocationProtection;
        public uint                 RegionSize;
        public PageState            State;
        public MemoryProtection     Protect;
        public PageType             Type;

        public override string ToString()
        {
            return "0x" + this.BaseAddress.ToUInt32().ToString("X8") + "-0x" + ((uint)this.BaseAddress + this.RegionSize).ToString("X8") + " (" + this.Protect.ToString () + ")";
        }
    }
}
