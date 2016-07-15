using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    public enum WindowMessage : int
    {
        Create                  = 0x00000001,
        Size                    = 0x00000005,
        Activate                = 0x00000006,
        SetFocus                = 0x00000007,
        KillFocus               = 0x00000008,
        Paint                   = 0x0000000F,
        EraseBackground         = 0x00000014,
        GetMinMaxInfo           = 0x00000024,
        NonClientCalculateSize  = 0x00000083,
        NonClientPaint          = 0x00000085,
        NonClientActivate       = 0x00000086,
        HorizontalScroll        = 0x00000114,
        VerticalScroll          = 0x00000115,
        PrintClient             = 0x00000318,
        ThemeChanged            = 0x0000031A
    }
}
