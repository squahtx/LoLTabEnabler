using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    public enum PageType : int
    {
        Image   = 0x01000000,
        Mapped  = 0x00040000,
        Private = 0x00020000
    }
}
