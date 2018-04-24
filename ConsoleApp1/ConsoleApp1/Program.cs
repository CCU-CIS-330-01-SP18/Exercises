using System;

namespace ConsoleApp1
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Entity goblin = new Entity(1, "Goblin");
            Entity dragon = new Entity(2, "Dragon");
            Entity thug = new Entity(3, "Thug");
            Encounter encounter1 = new Encounter(1);
            Encounter encounter2 = new Encounter(2);
            Console.WriteLine("Welcome to le game");
        }
    }
}
