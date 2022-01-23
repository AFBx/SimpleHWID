using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var hwid = GetHWID();
            Console.Write(hwid);
            System.Threading.Thread.Sleep(3000);
        }
        private static string GetHWID()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography"; string name = "MachineGuid";

            using (RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null) throw new KeyNotFoundException(string.Format(location));
                    object HWID = rk.GetValue(name);
                    if (HWID == null) throw new IndexOutOfRangeException(string.Format(name));
                    return HWID.ToString();
                }
            }
        }
    }
}
