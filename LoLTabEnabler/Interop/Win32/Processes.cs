using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LoLTabEnabler.Interop.Win32
{
    public static class Processes
    {
        [DllImport("psapi.dll", CharSet = CharSet.Unicode)]
        public static extern uint GetModuleBaseName(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, uint nSize);

        [DllImport("psapi.dll", CharSet = CharSet.Unicode)]
        public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, uint nSize);

        [DllImport("psapi.dll", CharSet = CharSet.Unicode)]
        public static extern uint GetProcessImageFileName(IntPtr hProcess, [Out] StringBuilder lpImageFileName, uint nSize);

        [DllImport("kernel32.dll")]
        public static extern bool GetProcessTimes(IntPtr hProcess, out long lpCreationTime, out long lpExitTime, out long lpKernelTime, out long lpUserTime);

        [DllImport("ntdll.dll", EntryPoint = "NtQueryInformationProcess")]
        public static extern int NtQueryInformationProcessBasicInformation(IntPtr processHandle, ProcessInformationClass processInformationClass, ref ProcessBasicInformation processInformation, int processInformationLength, out int returnLength);
        [DllImport("ntdll.dll", EntryPoint = "NtQueryInformationProcess", CharSet = CharSet.Unicode)]
        public static extern int NtQueryInformationProcessImageFileName(IntPtr processHandle, ProcessInformationClass processInformationClass, [Out] StringBuilder processInformation, int processInformationLength, out int returnLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static IntPtr OpenProcess(ProcessAccessRights dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public extern static bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesRead);

        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static bool OpenProcessToken(IntPtr ProcessHandle, TokenAccessRights DesiredAccess, out IntPtr TokenHandle);

        [DllImport("kernel32.dll", EntryPoint = "QueryFullProcessImageNameW", CharSet = CharSet.Unicode)]
        public extern static bool QueryFullProcessImageName(IntPtr hProcess, ProcessNameFormat dwFlags, [Out] StringBuilder lpExeName, ref uint lpdwSize);

        public static string GetModuleBaseName(IntPtr ProcessHandle)
        {
            if (ProcessHandle == IntPtr.Zero)
            {
                return null;
            }
            StringBuilder StringBuilder = new StringBuilder(1024);
            if (Processes.GetModuleBaseName(ProcessHandle, IntPtr.Zero, StringBuilder, 1024) == 0)
            {
                return null;
            }
            return StringBuilder.ToString();
        }

        public static string GetModuleFileNameEx(IntPtr ProcessHandle)
        {
            if (ProcessHandle == IntPtr.Zero)
            {
                return null;
            }
            StringBuilder StringBuilder = new StringBuilder(1024);
            if (Processes.GetModuleFileNameEx(ProcessHandle, IntPtr.Zero, StringBuilder, 1024) == 0)
            {
                return null;
            }
            return StringBuilder.ToString();
        }

        public static ProcessBasicInformation GetProcessBasicInformation(IntPtr processHandle)
        {
            ProcessBasicInformation Information = new ProcessBasicInformation();
            int ReturnLength;
            Processes.NtQueryInformationProcessBasicInformation(processHandle, ProcessInformationClass.BasicInformation, ref Information, Marshal.SizeOf(Information), out ReturnLength);
            return Information;
        }

        public static DateTime GetProcessCreationTime(IntPtr hProcess)
        {
            long CreationTime;
            long ExitTime;
            long KernelTime;
            long UserTime;
            Processes.GetProcessTimes(hProcess, out CreationTime, out ExitTime, out KernelTime, out UserTime);
            return DateTime.FromFileTime(CreationTime);
        }

        public static string GetProcessImageFileName(IntPtr ProcessHandle)
        {
            if (ProcessHandle == IntPtr.Zero)
            {
                return null;
            }
            StringBuilder StringBuilder = new StringBuilder(1024);
            if (Processes.GetProcessImageFileName(ProcessHandle, StringBuilder, 1024) == 0)
            {
                return null;
            }
            return StringBuilder.ToString();
        }

        public static int GetProcessParentId(IntPtr ProcessHandle)
        {
            return Processes.GetProcessBasicInformation(ProcessHandle).InheritedFromUniqueProcessId;
        }

        public static string GetProcessPath(IntPtr ProcessHandle)
        {
            if (ProcessHandle == IntPtr.Zero)
            {
                return null;
            }
            StringBuilder StringBuilder = new StringBuilder(1024);
            Processes.GetModuleBaseName(ProcessHandle, IntPtr.Zero, StringBuilder, 1024);
            Processes.GetProcessImageFileName(ProcessHandle, StringBuilder, 1024);
            /*
            UnicodeString Information = new UnicodeString();
            int ReturnLength;
            Processes.NtQueryInformationProcessImageFileName(ProcessHandle, ProcessInformationClass.ImageFileName, StringBuilder, 1024, out ReturnLength);
            return Information.Buffer;
             */
            return StringBuilder.ToString();
        }

        public static IntPtr OpenProcessToken(IntPtr ProcessHandle, TokenAccessRights DesiredAccess)
        {
            IntPtr TokenHandle;
            Processes.OpenProcessToken(ProcessHandle, DesiredAccess, out TokenHandle);
            return TokenHandle;
        }
    }
}
