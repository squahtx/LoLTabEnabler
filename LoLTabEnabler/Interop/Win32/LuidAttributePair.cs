using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LoLTabEnabler.Interop.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LuidAttributePair
    {
        public Luid Luid;
        public PrivilegeAttribute Attributes;
    }
}
