using System.Net;
using System.Net.Sockets;

namespace GenericUtility
{
    public static class NetworkUtils
    {
        public static string GetIp()
        {
            var localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ipAddress in localIPs)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress.ToString();
                }
            }
            return "127.0.0.1";
        }
    }
}