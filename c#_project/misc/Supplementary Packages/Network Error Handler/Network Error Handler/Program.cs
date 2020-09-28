using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System.Management;
using System.ComponentModel;

namespace Network_Error_Handler
{
    class Program
    {
        # region sqlbrowser
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Boolean ChangeServiceConfig(
            IntPtr hService,
            UInt32 nServiceType,
            UInt32 nStartType,
            UInt32 nErrorControl,
            String lpBinaryPathName,
            String lpLoadOrderGroup,
            IntPtr lpdwTagId,
            [In] char[] lpDependencies,
            String lpServiceStartName,
            String lpPassword,
            String lpDisplayName);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr OpenService(
            IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr OpenSCManager(
            string machineName, string databaseName, uint dwAccess);

        private const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
        private const uint SERVICE_QUERY_CONFIG = 0x00000001;
        private const uint SERVICE_CHANGE_CONFIG = 0x00000002;
        private const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;
        # endregion
    
        static void Main(string[] args)
        {
            En_Fire_7();
            Console.WriteLine("\n---------------------------------------------------------------------\n");
            En_Fire_XP();
            Console.WriteLine("\n---------------------------------------------------------------------\n");
            EnableSqlServerTcp(".", "SQLEXPRESS");
            Console.WriteLine("\n---------------------------------------------------------------------\n");
            SQLBrowserEnabler();
            Console.WriteLine("\n---------------------------------------------------------------------\n");
            EnableSA_USER();
            Console.WriteLine("\n*********************************************************************\n");
            Console.WriteLine("\nPRESS ANY KEY TO CLOSE THE WINDOW\n");
            Console.ReadKey();


        }

        private static void EnableSA_USER()
        {
            try
            {
                mydataaccess da = new mydataaccess();
                da.ChangeMixedMode();
                Console.WriteLine("The SQLSERVER has been set to MIXEDMODE SUCCESSFULLY...");
            }
            catch
            {
                Console.WriteLine("An error occurred while enabling MixedMode ... Please contact to the administrator...");
            }
        }


        public static void En_Fire_7()
        {
            try
            {
                System.Diagnostics.Process process1;
                process1 = new System.Diagnostics.Process();

                //Do not receive an event when the process exits.

                process1.EnableRaisingEvents = false;


                //The "/C" Tells Windows to Run The Command then Terminate 

                string strCmdLine;
                strCmdLine = "/C Netsh advfirewall set allprofiles state off";
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = strCmdLine;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                p.Start();
                process1.Close();
                Console.WriteLine("\nWindows Firewall has been DISABLED SUCCESSFULLY (Win7 Mode)...");
            }
            catch
            {
                Console.WriteLine("An error occurred while disabling Windows Firewall ... Please contact to the administrator...");
            }
        }

        public static void En_Fire_XP()
        {
            try
            {
                System.Diagnostics.Process process1;
                process1 = new System.Diagnostics.Process();

                //Do not receive an event when the process exits.

                process1.EnableRaisingEvents = false;


                //The "/C" Tells Windows to Run The Command then Terminate 

                string strCmdLine;
                strCmdLine = "/C netsh firewall set opmode disable";
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = strCmdLine;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                p.Start();
                process1.Close();
                Console.WriteLine("Windows Firewall has been DISABLED SUCCESSFULLY (WinXP Mode)...");
            }
            catch
            {
                Console.WriteLine("An error occurred while disabling Windows Firewall ... Please contact to the administrator...");
            }
        }

        public static void EnableSqlServerTcp(string serverName, string instanceName)
        {
            try
            {
                ManagementScope scope =
                        new ManagementScope(@"\\" + serverName +
                                            @"\root\Microsoft\SqlServer\ComputerManagement");
                ManagementClass sqlService =
                        new ManagementClass(scope,
                                            new ManagementPath("SqlService"), null);
                ManagementClass serverProtocol =
                        new ManagementClass(scope,
                                            new ManagementPath("ServerNetworkProtocol"), null);

                sqlService.Get();
                serverProtocol.Get();

                foreach (ManagementObject prot in serverProtocol.GetInstances())
                {
                    prot.Get();
                    if ((string)prot.GetPropertyValue("ProtocolName") == "Tcp" &&
                        (string)prot.GetPropertyValue("InstanceName") == instanceName)
                    {
                        prot.InvokeMethod("SetEnable", null);
                    }
                }

                uint sqlServerService = 1;
                uint sqlServiceStopped = 1;
                foreach (ManagementObject instance in sqlService.GetInstances())
                {
                    if ((uint)instance.GetPropertyValue("SqlServiceType") == sqlServerService &&
                        (string)instance.GetPropertyValue("ServiceName") == instanceName)
                    {
                        instance.Get();
                        if ((uint)instance.GetPropertyValue("State") != sqlServiceStopped)
                        {
                            instance.InvokeMethod("StopService", null);
                        }
                        instance.InvokeMethod("StartService", null);
                    }
                }
                Console.WriteLine("SQLEXPRESS TCP/IP Protocol has been ENABLED SUCCESSFULLY...");
            }
            catch
            {
                Console.WriteLine("An error occurred while enabling TCP/IP ... Please contact to the administrator...");
            }
       
        }

        public static void SQLBrowserEnabler()
        {

            ServiceController svc = new ServiceController("SQLBrowser");
            try
            {
                ChangeStartMode(svc, ServiceStartMode.Automatic);
                Console.WriteLine("SQLBROWSER Service has been SET TO AUTOMATIC SUCCESSFULLY...");

                if (svc.Status != ServiceControllerStatus.Running)
                {
                    svc.Start();
                    Console.WriteLine("SQLBROWSER Service is now RUNNING SUCCESSFULLY...");
                }
                else if (svc.Status == ServiceControllerStatus.Running)
                {
                    Console.WriteLine("SQLBROWSER Service is now RUNNING SUCCESSFULLY...");
                }
                else
                {
                    Console.WriteLine("SQLBROWSER Service STATUS = "+svc.Status.ToString()+" ... You might need to contact to the administrator");
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("An error occurred while Starting SQLBROWSER Service... Please contact to the administrator...");
            }

        }

        public static void ChangeStartMode(ServiceController svc, ServiceStartMode mode)
        {
            var scManagerHandle = OpenSCManager(null, null, SC_MANAGER_ALL_ACCESS);
            if (scManagerHandle == IntPtr.Zero)
            {
                Console.WriteLine("Open Service Manager Error");
            }

            var serviceHandle = OpenService(
                scManagerHandle,
                svc.ServiceName,
                SERVICE_QUERY_CONFIG | SERVICE_CHANGE_CONFIG);

            if (serviceHandle == IntPtr.Zero)
            {
                Console.WriteLine("Open Service Error");
            }

            var result = ChangeServiceConfig(
                serviceHandle,
                SERVICE_NO_CHANGE,
                (uint)mode,
                SERVICE_NO_CHANGE,
                null,
                null,
                IntPtr.Zero,
                null,
                null,
                null,
                null);

            if (result == false)
            {
                int nError = Marshal.GetLastWin32Error();
                var win32Exception = new Win32Exception(nError);
                Console.WriteLine("Could not change service start type: "
                    + win32Exception.Message);
            }
        }
    }
}
