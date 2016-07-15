using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    public enum WindowProperty : int
    {
        ExtendedStyle   = -20,
        HInstance       = -6,
        Identifier      = -12,
        Style           = -16,
        UserData        = -21,
        WndProc         = -4
    }
}
