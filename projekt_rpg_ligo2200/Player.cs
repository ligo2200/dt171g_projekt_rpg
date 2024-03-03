using System;
using System.Collections.Generic;


namespace projekt_rpg_ligo2200
{
    class Player : Character
    {
        public bool IsAlive => Health > 0;
        public Player(string name, int health, int damage) : base(name, health, damage) { }
        public bool HasTreasure { get; set; }

        public void GainTreasure()
        {
            Console.WriteLine("Något blänker på botten av sjön. En skatt!");
            Console.WriteLine("Du dyker ner och hämtar upp skatten. Den får precis plats i din väska.");

            HasTreasure = true;

            Console.WriteLine("");
            Console.WriteLine("Det var en skön simtur och inget farligt hände trots att sjön såg lite lurig ut.");
            Console.WriteLine("Nu är det dags för nya äventyr!");
            Console.WriteLine("");

        }
    }
}

