using System;
using EasyNetQ;
using Library;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                string id = DateTime.Now.ToString().GetHashCode().ToString("x");
                bus.Subscribe<Message>(id, HandleTextMessage);

                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Message
                    {
                        Name = userName,
                        Text = input
                    });
                }
            }
        }

        static void HandleTextMessage(Message textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: {1}", textMessage.Name, textMessage.Text);
            Console.ResetColor();
        }
    }
}
