using System.Net.Sockets;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
    public static class LocationHelper
    {
        public static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return null;
            } 
            catch
            {
                return null;
            }
        }
    }
}
