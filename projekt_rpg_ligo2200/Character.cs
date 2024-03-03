using System;
using System.Collections.Generic;


namespace projekt_rpg_ligo2200
{
    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public bool IsAlive => Health > 0;
    }
}
