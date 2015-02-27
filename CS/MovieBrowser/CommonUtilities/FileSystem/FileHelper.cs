using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using CommonUtilities.Extensions;

namespace CommonUtilities.FileSystem
{
    public class UsbDeviceInfo
    {
        public UsbDeviceInfo(string deviceId, string pnpDeviceId, string description)
        {
            this.DeviceId = deviceId;
            this.PnpDeviceId = pnpDeviceId;
            this.Description = description;
        }
        public string DeviceId { get; private set; }
        public string PnpDeviceId { get; private set; }
        public string Description { get; private set; }
    }


    public class CopyFileInfo
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public bool IsFolder { get; set; }
    }


    public delegate void CopyFileChanged(string filename);

    public static class FileHelper
    {

        public static string Extension(this string @this)
        {
            try { return @this.Substring(@this.LastIndexOf(".") + 1); }
            catch { return ""; }
        }

        public static bool ExistsIn(this string @this, List<string> extensions)
        {
            return extensions.Contains(@this);
        }

        public static string CleanFileName(this string @this)
        {
            return Regex.Replace(@this.Clean(), @"[\\/:*?""<>|]+", "");
        }

        public static List<UsbDeviceInfo> GetUsbDevices()
        {
            var searcher = new ManagementObjectSearcher(@"SELECT Caption, DeviceID FROM Win32_DiskDrive WHERE InterfaceType='USB'");

            return (from ManagementBaseObject device in searcher.Get()
                    select new UsbDeviceInfo((string)device.GetPropertyValue("DeviceID"), (string)device.GetPropertyValue("Caption"), (string)device.GetPropertyValue("Caption"))).ToList();
        }

        public static List<string> UsbDrives()
        {

            var i = 0;
            List<string> lista;

            Console.WriteLine("fetching logical disks...");

            try
            {

                ManagementObjectCollection drives = new ManagementObjectSearcher("SELECT Caption, DeviceID FROM Win32_DiskDrive WHERE InterfaceType='USB'").Get();

                lista = new List<string>();
                // browse all USB WMI physical disks
                foreach (ManagementObject drive in drives)
                {
                    // browse all USB WMI physical disks
                    foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"] + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                    {
                        // browse all USB WMI physical disks
                        foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                        {
                            if (disk["CAPTION"].ToString() != null)
                            {
                                lista.Add(disk["CAPTION"].ToString());
                                //i++;
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.ToString());
                return null;
            }
        }

        public static List<CopyFileInfo> ListAllFolders(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }


            List<CopyFileInfo> list = new List<CopyFileInfo>();
            // Copy each file into it’s new directory.
            foreach (var fi in source.GetFiles())
            {
                list.Add(new CopyFileInfo { IsFolder = false, SourcePath = fi.FullName, TargetPath = Path.Combine(target.ToString(), fi.Name) });
            }

            // Copy each subdirectory using recursion.
            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                list.AddRange(ListAllFolders(diSourceSubDir, nextTargetSubDir));
            }

            return list;
        }


        public static void CopyAllRecursive(DirectoryInfo source, DirectoryInfo target)
        {
            var list = ListAllFolders(source, target);
            var dialog = new FileCopyDialog();
            dialog.Show();
            dialog.CopyFiles(list);
        }
    }
}
