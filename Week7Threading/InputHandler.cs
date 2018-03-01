using System;
using System.Collections.Generic;
using System.Text;

namespace Week7Threading
{
    public class InputHandler
    {
        public void InputLoop()
        {
            while (true)
            {
                string playerChoice = Console.ReadLine().ToLower();
                if (playerChoice == "find silver")
                {
                    Console.WriteLine("It's silver! Type \"mine silver\" to mine or continue searching for minerals");
                }
                if (playerChoice == "find gold")
                {
                    Console.WriteLine("Gold! Type \"mine gold\" to mine or continue searching for minerals");
                }
                if (playerChoice == "find unobtanium")
                {
                    Console.WriteLine("UNOBTANIUM?! Type \"mine unobtanium\" to mine or continue searching for minerals");
                }
                if (playerChoice == "mine silver")
                {

                }
                if (playerChoice == "mine gold")
                {

                }
                if (playerChoice == "mine unobtanium")
                {

                }
            }
        }
    }
}
