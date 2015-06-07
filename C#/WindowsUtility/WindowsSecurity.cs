using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsUtility
{
    public static class WindowsSecurity
    {
        #region [Properties]
        /// <summary>
        /// Gets a value indicating whether the application is running under the Administrator privilege.
        /// </summary>
        public static bool IsAdmin
        {
            get
            {
                var currentIdentity = WindowsIdentity.GetCurrent();
                var currentPrincipal = new WindowsPrincipal(currentIdentity);
                return currentPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
        #endregion

        #region [Methods]
        /// <summary>
        /// Restart the current application as Administrator.
        /// </summary>
        public static void RestartAsAdmin()
        {
            var filename = Application.ExecutablePath;
            var argsBuilder = new StringBuilder();
            var args = Environment.GetCommandLineArgs();
            for (var index = 1; index < args.Length; ++index )
            {
                var arg = args[index];
                argsBuilder.AppendFormat("\"{0}\" ", arg);
            }
            var startUpInfo = new ProcessStartInfo(filename, argsBuilder.ToString().Trim()) {Verb = "runas"};
            Process.Start(startUpInfo);
        }

        public static void GrantUserFullControl(RegistryKey baseKey, string keyPath)
        {
            using (var regKey = baseKey.CreateSubKey(keyPath))
            {
                if (regKey == null)
                {
                    return;
                }

                var security = regKey.GetAccessControl();

                // Add a rule that grants the current user FullControl rights.
                // The rule is inherited by all subkeys.
                var rule = new RegistryAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null),
                                                  RegistryRights.FullControl,
                                                  InheritanceFlags.ContainerInherit,
                                                  PropagationFlags.None,
                                                  AccessControlType.Allow);
                security.AddAccessRule(rule);
                regKey.SetAccessControl(security);
            }
        }

        public static void GrantUserFullControl(string fileSystemPath)
        {
            if (Directory.Exists(fileSystemPath))
            {
                var directoryInfo = new DirectoryInfo(fileSystemPath);
                var directorySecurity = directoryInfo.GetAccessControl();
                var userId = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
                var userAccessRule = new FileSystemAccessRule(userId,
                                                              FileSystemRights.FullControl,
                                                              InheritanceFlags.ContainerInherit,
                                                              PropagationFlags.None,
                                                              AccessControlType.Allow);
                directorySecurity.AddAccessRule(userAccessRule);
                directoryInfo.SetAccessControl(directorySecurity);
                return;
            }

            if (File.Exists(fileSystemPath))
            {
                var fileInfo = new FileInfo(fileSystemPath);

                var fileSecurity = fileInfo.GetAccessControl();
                var userId = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
                var userAccessRule = new FileSystemAccessRule(userId,
                                                              FileSystemRights.FullControl,
                                                              AccessControlType.Allow);
                fileSecurity.AddAccessRule(userAccessRule);
                fileInfo.SetAccessControl(fileSecurity);
            }
        }
        #endregion
    }
}