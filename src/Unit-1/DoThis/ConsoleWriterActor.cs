using System;
using Akka.Actor;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for serializing message writes to the console.
    /// (write one message at a time, champ :)
    /// </summary>
    class ConsoleWriterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message is Messages.InputError)
            {
                var msg = message as Messages.InputError;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg.Reason);
            }
            else if (message is Messages.InputSuccess)
            {
                var msg = message as Messages.InputSuccess;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg.Reason);
            }
            else
            {
                Console.WriteLine(message);
            }

            Console.ResetColor();

            //var msg = message as string;

            //// make sure we got a message
            //if (string.IsNullOrEmpty(msg))
            //{
            //    Console.ForegroundColor = ConsoleColor.DarkYellow;
            //    Console.WriteLine("Please provide an input.\n");
            //    Console.ResetColor();
            //    return;
            //}

            //// if message has even # characters, display in red; else, green
            //var even = msg.Length % 2 == 0;
            //var color = even ? ConsoleColor.Red : ConsoleColor.Green;
            //var alert = even ? "Your string had an even # of characters.\n" : "Your string had an odd # of characters.\n";
            //Console.ForegroundColor = color;
            //Console.WriteLine(alert);
            //Console.ResetColor();

        }
    }
}
