using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    public enum ProcessInformationClass : int
    {
        BasicInformation    = 0,
        DebugPort           = 7,
        Wow64Information    = 26,
        ImageFileName       = 27
    }
}
