using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum TokenAccessRights : int
    {
        AdjustDefault       = 0x00000080,
        AdjustGroups        = 0x00000040,
        AdjustPrivileges    = 0x00000020,
        AdjustSessionId     = 0x00000100,
        AssignPrimary       = 0x00000001,
        Duplicate           = 0x00000002,
        Impersonate         = 0x00000004,
        Query               = 0x00000008,
        QuerySource         = 0x00000010,
        Read                = 0x00020008
    }
}
