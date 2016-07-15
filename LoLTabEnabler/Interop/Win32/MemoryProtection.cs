using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum MemoryProtection : int
    {
        None                = 0x0000,

        NoAccess            = 0x0001,
        ReadOnly            = 0x0002,
        ReadWrite           = 0x0004,
        WriteCopy           = 0x0008,

        Execute             = 0x0010,
        ExecuteRead         = 0x0020,
        ExecuteReadWrite    = 0x0040,
        ExecuteWriteCopy    = 0x0080,

        Guard               = 0x0100,
        NoCache             = 0x0200,
        WriteCombine        = 0x0400
    }

    public static class MemoryProtectionExtension
    {
        public static string ToString(this MemoryProtection Protection)
        {
            switch (Protection)
            {
                case MemoryProtection.Execute:
                    return "X";
                case MemoryProtection.ExecuteRead:
                    return "RX";
                case MemoryProtection.ExecuteReadWrite:
                    return "RWX";
                case MemoryProtection.ExecuteWriteCopy:
                    return "RWcX";
                case MemoryProtection.NoAccess:
                    return "-";
                case MemoryProtection.ReadOnly:
                    return "R";
                case MemoryProtection.ReadWrite:
                    return "RW";
                case MemoryProtection.WriteCopy:
                    return "Wc";
            }
            return "";
        }
    }
}
