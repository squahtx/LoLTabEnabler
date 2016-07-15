using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum FileCacheFlags
    {
        None            = 0x00,
        EnableMaximum   = 0x01,
        DisableMaximum  = 0x02,
        EnableMinimum   = 0x04,
        DisableMinimum  = 0x08
    }
}
