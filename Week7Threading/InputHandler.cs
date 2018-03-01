using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Week7Threading
{
    public class InputHandler
    {
        public void InputLoop()
        {
            while (true)
            {
                Console.WriteLine("Make Choice...");
                string playerChoice = Console.ReadLine().ToLower();
                if (playerChoice == "mine silver")
                {
                    MineralMiner.Mine("silver");
                }
                if (playerChoice == "mine gold")
                {
                    Console.WriteLine("Mining Gold! Feel free to start mining something else!");
                }
                if (playerChoice == "mine unobtanium")
                {
                    Console.WriteLine("Mining Unobtanium! Feel free to start mining something else!");
                }
                if (playerChoice == "go home")
                {
                    Console.WriteLine("Maybe you'll have better luck tomorrow :/");
                    break;
                }
            }
        }
    }
}
