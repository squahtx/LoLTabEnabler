using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LoLTabEnabler.Interop.Win32
{
    public static class Memory
    {
        [DllImport("kernel32.dll", EntryPoint = "EmptyWorkingSet", SetLastError = true)]
        private extern static bool Kernel32EmptyWorkingSet(IntPtr hProcess);
        [DllImport("psapi.dll", EntryPoint = "EmptyWorkingSet", SetLastError = true)]
        private extern static bool PsapiEmptyWorkingSet(IntPtr hProcess);

        [DllImport("kernel32.dll", EntryPoint = "GetProcessMemoryInfo", SetLastError = true)]
        private extern static bool Kernel32GetProcessMemoryInfo(IntPtr hProcess, ref ProcessMemoryCounters ppsmemCounters, uint cb);
        [DllImport("psapi.dll", EntryPoint = "GetProcessMemoryInfo", SetLastError = true)]
        private extern static bool PsapiGetProcessMemoryInfo(IntPtr hProcess, ref ProcessMemoryCounters ppsmemCounters, uint cb);

        [DllImport("kernel32.dll", EntryPoint = "GetSystemFileCacheSize", SetLastError = true)]
        private extern static bool _GetSystemFileCacheSize(out uint lpMinimumFileCacheSize, out uint lpMaximumFileCacheSize, out FileCacheFlags lpFlags);
        [DllImport("kernel32.dll", EntryPoint = "SetSystemFileCacheSize", SetLastError = true)]
        private extern static bool _SetSystemFileCacheSize(uint lpMinimumFileCacheSize, uint lpMaximumFileCacheSize, FileCacheFlags lpFlags);

        [DllImport("kernel32.dll")]
        public extern static bool VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress, ref MemoryBasicInformation lpBuffer, uint dwLength);

        public static bool EmptyWorkingSet(IntPtr hProcess)
        {
            if (Environment.OSVersion.Version.Major >= 7)
            {
                return Kernel32EmptyWorkingSet(hProcess);
            }
            return PsapiEmptyWorkingSet(hProcess);
        }

        public static bool GetProcessMemoryInfo(IntPtr hProcess, ref ProcessMemoryCounters ppsmemCounters, uint cb)
        {
            if (Environment.OSVersion.Version.Major >= 7)
            {
                return Kernel32GetProcessMemoryInfo(hProcess, ref ppsmemCounters, cb);
            }
            return PsapiGetProcessMemoryInfo(hProcess, ref ppsmemCounters, cb);
        }

        public static ProcessMemoryCounters GetProcessMemoryInfo(IntPtr hProcess)
        {
            ProcessMemoryCounters Counters = new ProcessMemoryCounters();
            Counters.cb = (uint)Marshal.SizeOf(Counters);
            Memory.GetProcessMemoryInfo(hProcess, ref Counters, Counters.cb);

            return Counters;
        }

        public static bool GetSystemFileCacheSize(out uint lpMinimumFileCacheSize, out uint lpMaximumFileCacheSize, out FileCacheFlags lpFlags)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                return Memory._GetSystemFileCacheSize(out lpMinimumFileCacheSize, out lpMaximumFileCacheSize, out lpFlags);
            }
            lpMinimumFileCacheSize = 0;
            lpMaximumFileCacheSize = 0;
            lpFlags = FileCacheFlags.None;
            return false;
        }

        public static uint MaximumFileCacheSize
        {
            get
            {
                uint MinimumFileCacheSize;
                uint MaximumFileCacheSize;
                FileCacheFlags Flags;

                Memory.GetSystemFileCacheSize(out MinimumFileCacheSize, out MaximumFileCacheSize, out Flags);
                return MaximumFileCacheSize;
            }
            set
            {
                if (Memory.MaximumFileCacheSize == value)
                {
                    return;
                }

                Tokens.EnablePrivilege("SeIncreaseQuotaPrivilege");
                Memory.SetSystemFileCacheSize(Memory.MinimumFileCacheSize, value, FileCacheFlags.None);
            }
        }

        public static bool MaximumFileCacheSizeEnabled
        {
            get
            {
                uint MinimumFileCacheSize;
                uint MaximumFileCacheSize;
                FileCacheFlags Flags;

                Memory.GetSystemFileCacheSize(out MinimumFileCacheSize, out MaximumFileCacheSize, out Flags);
                return (Flags & FileCacheFlags.EnableMaximum) != 0;
            }
            set
            {
                uint MinimumFileCacheSize;
                uint MaximumFileCacheSize;
                FileCacheFlags Flags;
                Memory.GetSystemFileCacheSize(out MinimumFileCacheSize, out MaximumFileCacheSize, out Flags);

                if (((Flags & FileCacheFlags.EnableMaximum) != 0) == value)
                {
                    return;
                }

                Tokens.EnablePrivilege("SeIncreaseQuotaPrivilege");
                Memory.SetSystemFileCacheSize(MinimumFileCacheSize, MaximumFileCacheSize, value ? FileCacheFlags.EnableMaximum : FileCacheFlags.DisableMaximum);
            }
        }

        public static uint MinimumFileCacheSize
        {
            get
            {
                uint MinimumFileCacheSize;
                uint MaximumFileCacheSize;
                FileCacheFlags Flags;

                Memory.GetSystemFileCacheSize(out MinimumFileCacheSize, out MaximumFileCacheSize, out Flags);
                return MinimumFileCacheSize;
            }
            set
            {
                if (Memory.MinimumFileCacheSize == value)
                {
                    return;
                }

                Tokens.EnablePrivilege("SeIncreaseQuotaPrivilege");
                Memory.SetSystemFileCacheSize(value, Memory.MinimumFileCacheSize, FileCacheFlags.None);
            }
        }

        public static bool MinimumFileCacheSizeEnabled
        {
            get
            {
                uint MinimumFileCacheSize;
                uint MaximumFileCacheSize;
                FileCacheFlags Flags;

                Memory.GetSystemFileCacheSize(out MinimumFileCacheSize, out MaximumFileCacheSize, out Flags);
                return (Flags & FileCacheFlags.EnableMinimum) != 0;
            }
            set
            {
                uint MinimumFileCacheSize;
                uint MaximumFileCacheSize;
                FileCacheFlags Flags;
                Memory.GetSystemFileCacheSize(out MinimumFileCacheSize, out MaximumFileCacheSize, out Flags);

                if (((Flags & FileCacheFlags.EnableMinimum) != 0) == value)
                {
                    return;
                }

                Tokens.EnablePrivilege("SeIncreaseQuotaPrivilege");
                Memory.SetSystemFileCacheSize(MinimumFileCacheSize, MaximumFileCacheSize, value ? FileCacheFlags.EnableMinimum : FileCacheFlags.DisableMinimum);
            }
        }

        public static bool SetSystemFileCacheSize(uint lpMinimumFileCacheSize, uint lpMaximumFileCacheSize, FileCacheFlags lpFlags)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                return Memory._SetSystemFileCacheSize(lpMinimumFileCacheSize, lpMaximumFileCacheSize, lpFlags);
            }
            return false;
        }

        public static MemoryBasicInformation VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress)
        {
            MemoryBasicInformation Information = new MemoryBasicInformation();
            Memory.VirtualQueryEx(hProcess, lpAddress, ref Information, (uint)Marshal.SizeOf(Information));

            return Information;
        }
    }
}
