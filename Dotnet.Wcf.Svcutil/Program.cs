using System;
using SoapResponderService = Dotnet.Wcf.Svcutil.ServiceReference.SoapResponder;

namespace Dotnet.Wcf.Svcutil
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SoapResponderService.SoapResponderPortTypeClient();
            var response = client.Method1("VALOR-1", "VALOR-2");
            Console.WriteLine(response);
        }
    }
}
