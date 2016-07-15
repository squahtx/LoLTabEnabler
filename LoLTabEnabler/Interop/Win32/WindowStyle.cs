using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLTabEnabler.Interop.Win32
{
    [Flags]
    public enum WindowStyle : uint
    {
        Overlapped          = 0x00000000,
        MdiAllChildStyles   = 0x00000001,
        Tiled               = 0x00000000,
        TabStop             = 0x00010000,
        MaximizeBox         = 0x00010000,
        Group               = 0x00020000,
        MinimizeBox         = 0x00020000,
        SizeBox             = 0x00040000,
        ThickFrame          = 0x00040000,
        SysMenu             = 0x00080000,
        HScroll             = 0x00100000,
        VScroll             = 0x00200000,
        DlgFrame            = 0x00400000,
        Border              = 0x00800000,
        Caption             = 0x00C00000,
        Maximize            = 0x01000000,
        ClipChildren        = 0x02000000,
        ClipSiblings        = 0x04000000,
        Disabled            = 0x08000000,
        Visible             = 0x10000000,
        Iconic              = 0x20000000,
        Minimize            = 0x20000000,
        Child               = 0x40000000,
        ChildWindow         = 0x40000000,
        Popup               = 0x80000000
    }
}
