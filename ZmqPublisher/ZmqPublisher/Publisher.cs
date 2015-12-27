using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using System.Threading;

namespace ZmqPublisher
{
    public class Publisher
    {
        public void regularPublish()
        {
            using (var context = NetMQContext.Create())
            using (var publisher = context.CreatePublisherSocket())
            {
                Console.WriteLine("Publisher socket binding...");
                publisher.Options.SendHighWatermark = 1000;
                publisher.Bind("tcp://localhost:11105");

                for (var i = 1; i <= 100; i++)
                {
                    Console.WriteLine("Sending Message: " + i);

                    if (i % 2 == 0)
                        publisher.SendMore("Transport2").Send("From the publisher: " + i);
                    else
                        publisher.SendMore("Transport1").Send("From the publisher: " + i);

                    Thread.Sleep(100);
                }

                Console.ReadLine();
            }
        }

        public void XPublish()
        {
            using (var context = NetMQContext.Create())
            using (var publisher = context.CreateXPublisherSocket())
            {
                Console.WriteLine("XPublisher socket binding...");
                publisher.Options.SendHighWatermark = 1000;
                publisher.Bind("tcp://localhost:11105");
                //publisher.Bind("tcp://192.168.216.87:11105");

                for (var i = 1; i <= 100; i++)
                {
                    Console.WriteLine("XPUB Sending Message: " + i);
                    publisher.SendMore("Transport1").Send("XPublisher: " + i);
                    Thread.Sleep(100);
                }

                Console.ReadLine();
            }
        }

        //public async Task Intermediary
        //{
        //    Task T1 = new Task();

        //    using (var context = NetMQContext.Create())
        //    using (var xpubSocket = context.CreateXPublisherSocket())
        //    using (var xsubSocket = context.CreateXSubscriberSocket())
        //    {
        //        xpubSocket.Bind("tcp://localhost:1234");
        //        xsubSocket.Bind("tcp://localhost:5556");
        //        Console.WriteLine("Intermediary started, and waiting for messages");

        //        var proxy = new Proxy(xsubSocket, xpubSocket);

        //    }
        //}
    }
}
