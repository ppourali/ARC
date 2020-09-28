using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace SoftwareLocker
{
    class KeyGen
    {
        public string MakeGUID()
        {
            string procc = "Win32_Processor", mac = "";
            string serial = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select ProcessorId from " + procc);
            try
            {
                foreach (ManagementObject device in searcher.Get())
                {
                    if (device.Properties.Count > 0)
                    {
                        procc = device["ProcessorId"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                procc = "01234567890123456789"; // میتونی همشو صفر کنی
            }
            searcher = new ManagementObjectSearcher("Select MACAddress,PNPDeviceID FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND PNPDeviceID IS NOT NULL");
            ManagementObjectCollection mObject = searcher.Get();
            try
            {
                foreach (ManagementObject obj in mObject)
                {
                    string pnp = obj["PNPDeviceID"].ToString();
                    if (pnp.Contains("PCI\\"))
                    {
                        mac = obj["MACAddress"].ToString();
                        mac = mac.Replace(":", string.Empty);
                    }
                }
            }
            catch (Exception)
            {
                mac = "987654321000";  // میتونی همشو صفر کنی
            }
            procc = Normalize(procc);
            procc = Make20Digit(procc);
            mac = Normalize(mac);
            mac = Make12Digit(mac);
            serial = procc + mac;
            return serial;
        }

        private string Make12Digit(string mac)
        {
            if (mac.Length < 12)
                while (mac.Length < 12)
                    mac += "0";
            if (mac.Length > 12)
                mac.Remove(12);
            return mac;
        }

        private string Make20Digit(string strin)
        {
            if (strin.Length < 20)
                while (strin.Length < 20)
                    strin += "0";
            if (strin.Length > 20)
                strin.Remove(20);
            return strin;
        }

        private string Normalize(string str)
        {
            if (str.Contains(':'))
                str.Replace(":", "");
            if (str.Contains('-'))
                str.Replace("-", "");
            if (str.Contains('\\'))
                str.Replace("\\", "");
            if (str.Contains('/'))
                str.Replace("/", "");
            return str;
        }
    }
}
