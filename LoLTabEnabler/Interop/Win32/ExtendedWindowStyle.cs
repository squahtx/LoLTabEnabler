using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum ExtendedWindowStyle
    {
        MdiChild    = 0x00000040,
        ClientEdge  = 0x00000200
    }
}
