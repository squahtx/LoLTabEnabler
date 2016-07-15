using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum CascadeFlags : uint
    {
        SkipDisabled    = 0x00000002,
        ZOrder          = 0x00000004
    }
}
