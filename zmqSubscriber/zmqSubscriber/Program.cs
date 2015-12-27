using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;

namespace zmqSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            string topic = "Transport1";
            using (var context = NetMQContext.Create())
            using (NetMQSocket subscriber = context.CreateSubscriberSocket())
            {
                subscriber.Connect("tcp://localhost:11105");
                subscriber.Subscribe(topic);
                Console.WriteLine("Subscriber socket connecting...");

                while (true)
                {
                    string messageTopicReceived = subscriber.ReceiveString();
                    string messageReceived = subscriber.ReceiveString();
                    Console.WriteLine(messageReceived + ", " + messageTopicReceived);

                }
            }
        }
    }
}
