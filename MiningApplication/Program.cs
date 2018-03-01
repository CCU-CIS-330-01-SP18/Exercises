using System;
using Week7Threading;

namespace MiningApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mine!");
            Console.WriteLine("Type mine <mineral> to mine silver, gold, or unobtainium! Or say \"go home\" to give up your mining career. :(");
            var inputHandler = new InputHandler();
            inputHandler.InputLoop();
        }
    }
}
