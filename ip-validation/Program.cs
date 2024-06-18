using System.Net;

string input = "10.8.244.01";

Console.WriteLine(ValidateIP(input));

static bool ValidateIP(string input)
{
    IPAddress address;    

    return IPAddress.TryParse(input, out address) && address.ToString() == input;
}
