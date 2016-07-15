using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum PrivilegeAttribute : int
    {
        Disabled = 0x00000000,
        Enabled = 0x00000002
    }
}
