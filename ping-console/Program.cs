using System.Net.NetworkInformation;

Console.WriteLine(PingAddress("www.google.com", 1000));
static string PingAddress(string address, int timeout)
{

    try
    {
        Ping ping = new Ping();
        PingReply reply= ping.Send(address, timeout);
        return "Status: " + reply.Status.ToString() + "; Time: " + reply.RoundtripTime + "ms ;";
    }
    catch (Exception e)
    {
        return e.Message + " " + e.InnerException.Message;
    }
    
    
}