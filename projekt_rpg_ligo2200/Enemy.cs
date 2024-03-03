using System;
using System.Collections.Generic;


namespace projekt_rpg_ligo2200
{
    class Enemy : Character
    {
        public Enemy(string name, int health, int damage) : base(name, health, damage) { }

        public bool AttackPlayer(Player player)
        {
            Console.WriteLine($"Du slåss mot {Name}!");
            Random random = new Random();
            bool playerBattle = random.Next(2) == 0;

            if (playerBattle)
            {
                Console.WriteLine("");
                Console.WriteLine($"Vilken tur, du lyckades besegra {Name}.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"Åh nej! Du förlorade mot {Name}. Bättre lycka nästa gång!");
                player.Health -= Damage; // Player gets damage
            }

            return playerBattle;
        }

        public bool ZombieAttack(Player player, List<Enemy> zombies)
        {
            Random random = new Random();
            bool playerBattleZombies = true;

            foreach (Enemy zombie in zombies)
            {
                // Simulating random attack
                bool randomOutcomeZombieBattle = random.Next(2) == 0;


                if (!randomOutcomeZombieBattle)
                {
                    Console.WriteLine($"Åh nej! De var för många och du förlorade mot {zombie.Name}.");
                    player.Health -= zombie.Damage; // Spelaren får skada
                    playerBattleZombies = false;
                    break;
                }

            }

            if (playerBattleZombies)
            {
                Console.WriteLine($"Vilken tur, du lyckades besegra alla zombiesar!");
            }

            return playerBattleZombies;

        }
    }
}
