using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum SetWindowPosFlags : uint
    {
        NoSize          = 0x00000001,
        NoMove          = 0x00000002,
        NoZOrder        = 0x00000004,
        NoRedraw        = 0x00000008,
        NoActivate      = 0x00000010,
        DrawFrame       = 0x00000020,
        FrameChanged    = 0x00000020,
        ShowWindow      = 0x00000040,
        HideWindow      = 0x00000080,
        NoCopyBits      = 0x00000100,
        NoOwnerZOrder   = 0x00000200,
        NoReposition    = 0x00000200,
        NoSendChanging  = 0x00000400,
        DeferErase      = 0x00002000,
        AsyncWindowPos  = 0x00004000
    }
}
