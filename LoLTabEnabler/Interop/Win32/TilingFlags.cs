using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum TilingFlags : uint
    {
        Vertical = 0,
        Horizontal = 1,
        SkipDisabled = 2
    }
}
