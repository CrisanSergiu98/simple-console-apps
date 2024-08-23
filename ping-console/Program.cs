using System.Net;
using System.Net.NetworkInformation;

string ipInput = "192.168.56";

for(int i = 1; i < 255; i++)
{
    string ip = ipInput + "." + i;
    Console.WriteLine(PingAddress(ip, 1000));
}

static string PingAddress(string address, int timeout)
{
    try
    {
        Ping ping = new Ping();

        IPAddress ip;
        IPHostEntry entry;

        IPAddress.TryParse(address, out ip);

        if (ip == null)
        {
            return "Incorrect IP Address";
        }

        PingReply reply = ping.Send(ip, timeout);

        string hostOutputText = "";

        if (reply.Status != IPStatus.Success)
        {
            hostOutputText = "No Host Found";
        }
        else
        {
            entry = Dns.GetHostEntry(ip);
            hostOutputText = entry.HostName;
        }

        return "Host: " + hostOutputText + "; Status: " + reply.Status.ToString() + "; Time: " + reply.RoundtripTime + "ms ;";
    }
    catch (Exception e)
    {
        return e.Message + " " + e.InnerException.Message;
    }  
}