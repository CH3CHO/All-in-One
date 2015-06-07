using System;
using Microsoft.Win32;

namespace WindowsUtility
{
    public static class StartUpUtils
    {
        private const string m_RunKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public static void ToggleLaunchAtStartUp(string applicationName, string commandLine, bool launchAtStartUp)
        {
            using (var runRegistryKey = Registry.CurrentUser.OpenSubKey(m_RunKeyPath, true))
            {
                if (runRegistryKey == null)
                {
                    return;
                }
                if (launchAtStartUp)
                {
                    runRegistryKey.SetValue(applicationName, commandLine);
                }
                else
                {
                    runRegistryKey.DeleteValue(applicationName, false);
                }
            }
        }

        public static bool IsLaunchAtStartUp(string applicationName, string commandLine)
        {
            try
            {
                using (var runRegistryKey = Registry.CurrentUser.OpenSubKey(m_RunKeyPath, true))
                {
                    if (runRegistryKey == null)
                    {
                        return false;
                    }
                    var existedCommandLine =  (string)runRegistryKey.GetValue(applicationName, null);
                    return string.Compare(commandLine, existedCommandLine, StringComparison.OrdinalIgnoreCase) == 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}