using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum PageState : int
    {
        Commit  = 0x00001000,
        Free    = 0x00010000,
        Reserve = 0x00002000
    }
}
