using System;

namespace projekt_rpg_ligo2200
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Välkommen till AdventureQuest!");

            Game game = new Game();
            game.Start();

            Console.ReadLine();
        }
    }
}
