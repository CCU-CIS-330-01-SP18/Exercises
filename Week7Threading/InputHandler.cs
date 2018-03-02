using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Week7Threading
{
    /// <summary>
    /// An interface capable of handling user input to start various tasks.
    /// </summary>
    public class InputHandler
    {
        /// <summary>
        /// A loop that runs until the application is quit.
        /// </summary>
        public void InputLoop()
        {
            while (true)
            {
                Console.WriteLine("Make Choice... ");
                string playerChoice = Console.ReadLine().ToLower();
                if (playerChoice == "mine silver")
                {
                    MineralMiner.Mine("silver");
                }
                if (playerChoice == "mine gold")
                {
                    MineralMiner.Mine("gold");
                }
                if (playerChoice == "mine unobtainium")
                {
                    MineralMiner.Mine("unobtainium");
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
