using System.Diagnostics;

namespace WindowsUtility
{
    public static class ProcessUtils
    {
        public static int KillByName(string processName)
        {
            var count = 0;
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                    ++count;
                }
                catch
                {
                }
            }
            return count;
        }
    }
}