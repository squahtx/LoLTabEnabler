using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum ProcessAccessRights : int
    {
        None                    = 0x00000000,
        Delete                  = 0x00010000,
        ReadControl             = 0x00020000,
        Synchronize             = 0x00100000,
        WriteDAC                = 0x00040000,
        WriteOwner              = 0x00080000,

        CreateProcess           = 0x00000080,
        CreateThread            = 0x00000002,
        DupeHandle              = 0x00000040,
        QueryInformation        = 0x00000400,
        QueryLimitedInformation = 0x00001000,
        SetInformation          = 0x00000200,
        SetQuota                = 0x00000100,
        SuspendResume           = 0x00000800,
        Terminate               = 0x00000001,
        VmOperation             = 0x00000008,
        VmRead                  = 0x00000010,
        VmWrite                 = 0x00000020
    }
}
