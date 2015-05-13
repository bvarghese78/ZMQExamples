using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZmqPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What would you like to run? pub/xpub: ");
            string response = Console.ReadLine();

            Publisher pub = new Publisher();

            if (response.ToLower() == "pub")
                pub.regularPublish();
            else if (response.ToLower() == "xpub")
                pub.XPublish();
        }
    }
}
