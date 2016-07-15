using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LoLTabEnabler.Interop.Win32
{
    public static class Tokens
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static bool AdjustTokenPrivileges(IntPtr hToken, bool DisableAllPrivileges, ref TokenPrivileges NewState, uint BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

        [DllImport("advapi32.dll", EntryPoint = "LookupPrivilegeValueW", CharSet = CharSet.Unicode, SetLastError = true)]
        public extern static bool LookupPrivilegeValue(string lpSystemName, string lpName, out Luid lpLuid);

        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static bool OpenProcessToken(IntPtr ProcessHandle, TokenAccessRights DesiredAccess, out IntPtr TokenHandle);

        public static IntPtr OpenProcessToken(IntPtr ProcessHandle, TokenAccessRights DesiredAccess)
        {
            IntPtr TokenHandle;
            Processes.OpenProcessToken(ProcessHandle, DesiredAccess, out TokenHandle);
            return TokenHandle;
        }

        public static void EnablePrivilege(string Name)
        {
            IntPtr ProcessToken = Tokens.OpenProcessToken(System.Diagnostics.Process.GetCurrentProcess().Handle, TokenAccessRights.AdjustPrivileges);
            TokenPrivileges Privileges = new TokenPrivileges();
            Privileges.PrivilegeCount = 1;
            Privileges.Privileges = new LuidAttributePair[1];
            Tokens.LookupPrivilegeValue(null, Name, out Privileges.Privileges[0].Luid);
            Privileges.Privileges[0].Attributes = PrivilegeAttribute.Enabled;
            Tokens.AdjustTokenPrivileges(ProcessToken, false, ref Privileges, (uint)Marshal.SizeOf(Privileges), IntPtr.Zero, IntPtr.Zero);
            Handles.CloseHandle(ProcessToken);
        }
    }
}
