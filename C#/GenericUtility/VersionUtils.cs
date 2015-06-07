using System.Diagnostics;
using System.Reflection;

namespace GenericUtility
{
    public static class VersionUtils
    {
        public static string GetCurrentAssemblyVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductVersion;
        }
    }
}