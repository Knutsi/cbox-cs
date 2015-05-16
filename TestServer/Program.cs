using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.server;
using cbox.system;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Config()
            {
                SystemPath = @"C:\Users\KnutSindre\Documents\cbox-basesystem",
                DocumentRoot = @"C:\Users\KnutSindre\Documents\Visual Studio 2013\Projects\SubscriberModel\CBoxClient"
            };

            Console.Out.WriteLine("Starting test server on port 8008");
            var server = new Server(config);
            server.Start();
        }
    }
}
