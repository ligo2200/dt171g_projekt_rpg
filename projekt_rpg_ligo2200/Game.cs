using System;
using System.Collections.Generic;



namespace projekt_rpg_ligo2200
{
    class Game
    {
        private Player player = new Player("", 100, 10);
        private Enemy enemy = new Enemy("", 0, 0);

        public void Start()
        {
            Console.WriteLine("Nu börjar vi spelet.");
            Console.WriteLine("");

            // Name-input from user
            Console.Write("Vad heter du? ");
            string playerName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Du måste ange ett namn.");

                Start();
            }
            else
            {
                // Create player
                player = new Player(playerName, 100, 10);
                Console.Clear(); // clearing console from previous textmessages
                Console.WriteLine($"Hej {playerName}!");
                Console.WriteLine("Du står vid en vägskäl.");
                Console.WriteLine("Antingen kan du gå vägen genom den mörka skogen till vänster eller ta vägen till höger som leder till byn.");
                Console.WriteLine("");
                Console.WriteLine("Vad vill du göra?");


                // Starting of main game events
                RoadChoice();
            }
        }

        private void RoadChoice()
        {   // alternative at crossroads
            Console.WriteLine("Välj ett av alternativen:");
            Console.WriteLine("1. Gå genom skogen");
            Console.WriteLine("2. Gå till byn");
            Console.WriteLine("3. Avsluta spelet");

            int choice = GetPlayerChoice(1, 3);

            switch (choice)
            {
                case 1:
                    ExploreForest();
                    break;
                case 2:
                    VisitVillage();
                    break;
                case 3:
                    EndGame();
                    break;
            }
        }

        // if a player chose a wrong choice
        private void WrongChoice()
        {
            Console.Clear(); // clearing console from previous textmessages
            Console.WriteLine("I det här spelet måste du vara modig om du vill vinna! Fegisar får börja om. :P");
            Console.WriteLine("");
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Börja om spelet.");
            Console.WriteLine("2. Avsluta spelet.");

            int choice = GetPlayerChoice(1, 2);

            switch (choice)
            {
                case 1:
                    Start();
                    break;
                case 2:
                    EndGame();
                    return;
            }
        }

        // updating player health
        private void UpdatePlayerHealth()
        {
            Console.WriteLine($"Din hälsa är: {player.Health}");

            // if player health is zero or less
            if (player.Health <= 0)
            {
                Console.WriteLine("Oj då! Du har inget liv kvar, du är död! :(");
                Console.WriteLine("");
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("1. Börja om spelet.");
                Console.WriteLine("2. Avsluta spelet.");

                int choice = GetPlayerChoice(1, 2);

                switch (choice)
                {
                    case 1:
                        Start();
                        break;
                    case 2:
                        EndGame();
                        return;
                }
            }
        }

        // if player chose the "Gå genom skogen" option.
        private void ExploreForest()
        {
            Console.Clear(); // clearing console from previous textmessages
            Console.WriteLine("Du ger dig ut på en vandring genom skogen.");
            Console.WriteLine("");
            Console.WriteLine("Plötsligt dyker ett skogsmonster upp!");
            Console.WriteLine("");
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Slåss mot skogsmonstret");
            Console.WriteLine("2. Springa iväg");
            Console.WriteLine("3. Avsluta spelet");

            int choice = GetPlayerChoice(1, 3);

            switch (choice)
            {
                case 1:
                    FightEnemy();
                    break;
                case 2:
                    WrongChoice();
                    break;
                case 3:
                    EndGame();
                    return;
            }
        }

        // if player chose the "gå till byn" -option
        private void VisitVillage()
        {
            Console.Clear();
            Console.WriteLine("Du anländer till byn. Det verkar vara en lugn plats.");
            Console.WriteLine("");
            // village scenario with options
            Console.WriteLine("Vad vill du göra i byn?");
            Console.WriteLine("1. Utforska byn");
            Console.WriteLine("2. Besöka affären");
            Console.WriteLine("3. Gå tillbaka till vägskälet");
            Console.WriteLine("4. Avsluta spelet.");


            int choice = GetPlayerChoice(1, 3);

            switch (choice)
            {
                case 1:
                    ExploreVillage();
                    break;
                case 2:
                    VisitShop();
                    break;
                case 3:
                    RoadChoice(); // Go back to the road choice in the beginning
                    break;
                case 4:
                    EndGame();
                    return;
            }
        }

        // if player chose "utforska byn" -option
        private void ExploreVillage()
        {
            Console.Clear();
            Console.WriteLine("Du ger dig ut för att undersöka byn.");
            Console.WriteLine("Plötsligt dyker flera zombiesar upp! De verkar inte särskilt vänliga trots byns lugna atmosfär.");
            Console.WriteLine("");
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Slåss mot zombies");
            Console.WriteLine("2. Springa iväg");
            Console.WriteLine("3. Avsluta spelet");

            int choice = GetPlayerChoice(1, 3);

            switch (choice)
            {
                case 1:
                    FightZombies();
                    break;
                case 2:
                    WrongChoice();
                    break;
                case 3:
                    EndGame();
                    return;
            }
        }

        // if player chose "slåss mot zombies" -option
        private void FightZombies()
        {
            Console.Clear();
            Console.WriteLine("Du bestämmer dig för att slåss mot zombiesarna.");

            // Create list with zombies since there is more than one zombie
            List<Enemy> zombies = new List<Enemy>
            {
                new Enemy("Zombie 1", 30, 20),
                new Enemy("Zombie 2", 30, 20),
                new Enemy("Zombie 3", 30, 20)
            };

            // calling method in Enemy-class
            bool playerWinsBattle = enemy.ZombieAttack(player, zombies);

            UpdatePlayerHealth();


            // if player defeats all zombies
            if (playerWinsBattle)
            {
                Console.WriteLine("");
                Console.WriteLine("Du fortsätter till skogen efter fighten, redo att möta nya äventyr!");

                ExploreForest();
            }
            else
            {   // if player doesn't defeat ALL zombies
                Console.WriteLine("");
                Console.WriteLine("Du springer tillbaka till vägskälet, tur att du lyckades smita iväg när zombiesarna började smaska på något annat.");

                RoadChoice();
            }
        }

        // if player chose "besök affären" -option
        private void VisitShop()
        {
            Console.Clear();
            Console.WriteLine("Hallå..? Finns det någon här?");
            Console.WriteLine("Det är väldigt mörkt och tyst med spindelnät överallt. Du väljer att utforska byn istället.");
            Console.WriteLine("");
            Console.WriteLine("Tryck på Enter för att fortsätta...");
            Console.ReadLine();

            ExploreVillage();
        }

        // if player chose explore forest (gå genom skogen) and then fight enemy (slåss mot skogsmonstret)
        private void FightEnemy()
        {
            Console.Clear();
            Console.WriteLine("");
            // Create enemy 
            enemy = new Enemy("Skogsmonstret", 40, 8);

            // Check if player wins or loses in Enemy-class
            bool playerBattle = enemy.AttackPlayer(player);

            // player health is updated
            UpdatePlayerHealth();


            // if player wins
            if (playerBattle)
            {
                Console.WriteLine("");
                Console.WriteLine("Du vandrar vidare genom skogen, fylld av självförtroende efter mötet med skogsmonstret.");
                Console.WriteLine("");

                LakeChoice();
            }
            else // if player loses but still have health left
            {
                Console.WriteLine("");
                Console.WriteLine("Du linkar vidare genom skogen, benet gör ont, men du hade turen att skogsmonstret blev distraherad av något ljud så du kunde smita iväg.");
                Console.WriteLine("");

                LakeChoice();
            }

        }

        // after fighting monster player comes to this choice
        private void LakeChoice()
        {
            Console.WriteLine("Du kommer till en mörk sjö. Du kan välja att gå runt sjön eller spara tid genom att simma över, med risk för att stöta på något i vattnet.");
            Console.WriteLine("");
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("");
            Console.WriteLine("1. Gå runt sjön");
            Console.WriteLine("2. Simma över sjön");
            Console.WriteLine("3. Avsluta spelet");

            int choice = GetPlayerChoice(1, 3);

            switch (choice)
            {
                case 1:
                    GoAroundLake();
                    break;
                case 2:
                    player.HasTreasure = false; // player doesn't have the treasure before going to swim across lake
                    SwimAcrossLake();
                    break;
                case 3:
                    EndGame();
                    return;
            }

            Console.Clear();
        }

        // if player choses to "simma över sjön"
        private void SwimAcrossLake()
        {
            Console.Clear();
            Console.WriteLine("Du väljer att simma över.");
            Console.WriteLine("");

            if (!player.HasTreasure)
            {
                // player finds treasure (method in player-class)
                player.GainTreasure();
            }

            ContinueIntoForest();

        }

        // if player choses to "gå runt sjön"
        private void GoAroundLake()
        {
            Console.Clear();
            Console.WriteLine("Du väljer att gå runt sjön.");
            Console.WriteLine("");
            Console.WriteLine("Det är väldigt vackert här, men vad är det för konstigt brummande ljud..?");
            Console.WriteLine("");

            Console.WriteLine("Plötsligt kommer en svärm av arga bin och börjar attackera dig, du måste skynda dig att göra ett val!");
            Console.WriteLine("");
            Console.WriteLine("1. Spring vidare framåt, in i skogen!");
            Console.WriteLine("2. Spring tillbaka och simma över sjön istället!");
            Console.WriteLine("3. Spring tillbaka till vägskälet och gå till byn istället!");
            Console.WriteLine("4. Avsluta spelet");

            Console.WriteLine("");
            Console.WriteLine("De där bina var inte roliga, nu är du full av röda och kliande bistick. :( ");
            Console.WriteLine("");
            // Player loses 20 in health
            player.Health -= 20;
            UpdatePlayerHealth();

            Console.WriteLine("");

            int choice = GetPlayerChoice(1, 4);
            switch (choice)
            {
                case 1:

                    ContinueIntoForest();
                    break;
                case 2:

                    player.HasTreasure = false; // player doesn't have the treasure before going to swim across lake
                    SwimAcrossLake();
                    break;
                case 3:
                    VisitVillage();
                    break;
                case 4:

                    EndGame();
                    return;
            }

        }

        // player is sent to choice about forest
        private void ContinueIntoForest()
        {
            // next choice
            Console.WriteLine("");
            Console.WriteLine("Du ser plötsligt en väg som leder djupare in i skogen. Det är mörkt och tyst. Vad vill du göra?");
            Console.WriteLine("");
            Console.WriteLine("1. Följ vägen djupare in i skogen");
            Console.WriteLine("2. Gå tillbaka, det är alldeles för läskigt");
            Console.WriteLine("3. Avsluta spelet");

            int choice = GetPlayerChoice(1, 3);

            switch (choice)
            {
                case 1:
                    ThePrincess();
                    break;
                case 2:
                    WrongChoice();
                    break;
                case 3:
                    EndGame();
                    return;
            }
        }

        // if player chose "djupare in i skogen" -option
        private void ThePrincess()
        {
            Console.Clear(); // clearing console of previous text
            // next choice
            Console.WriteLine("Plötsligt ser du en vacker prinsessa i den mörka skogen. Hon verkar leta efter något.");
            Console.WriteLine("");
            Console.WriteLine("Prinsessan vänder sig mot dig och säger: ");
            Console.WriteLine("Du där! Har du sett min skatt? Jag tappade den någonstans men jag vet inte exakt var.");
            Console.WriteLine("");
            // player choices
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Se efter om du har skatten i väskan.");
            Console.WriteLine("2. Tala om för henne att du inte har skatten.");
            Console.WriteLine("3. Avsluta spelet");

            int choice = GetPlayerChoice(1, 3);

            switch (choice)
            {
                case 1: // if player has treasure
                    if (player.HasTreasure)
                    {
                        Console.Clear();
                        Console.WriteLine("Du letar i väskan och tar fram skatten du hittade i sjön.");
                        Console.WriteLine("");
                        // player wins game, game finished.
                        Console.WriteLine("1. Ge skatten till prinsessan");
                        Console.WriteLine("2. Behåll skatten själv");
                        Console.WriteLine("3. Avsluta spelet");

                        int finishGame = GetPlayerChoice(1, 3);

                        switch (finishGame)
                        {
                            case 1: // if player chose "ge skatten till prinsessan" - option
                                Console.Clear();
                                Console.WriteLine("Tack så mycket, utropar prinsessan glatt! ");
                                Console.WriteLine("För din ärlighet och ditt mod ska du belönas med att få bo i mitt slott och äta glass varenda dag!");
                                Console.WriteLine("");
                                Console.WriteLine($"Grattis {player.Name} du har vunnit spelet!");
                                Console.WriteLine("Vad vill du göra?");
                                Console.WriteLine("1. Vill du spela igen?");
                                Console.WriteLine("2. Avsluta spelet.");

                                int startGame = GetPlayerChoice(1, 2);

                                switch (startGame)
                                {
                                    case 1:
                                        Start();
                                        break;
                                    case 2:
                                        EndGame();
                                        return;
                                }

                                break;
                            case 2: // if player chose "behålla skatten själv" -option
                                Console.Clear();
                                Console.WriteLine("Du behåller skatten för dig själv och går skrattande därifrån medan prinsessan förvånat stirrar på dig.");
                                Console.WriteLine("");
                                Console.WriteLine("Vad vill du göra nu?");
                                Console.WriteLine("1. Spela igen");
                                Console.WriteLine("2. Avsluta spelet");

                                int restartGame = GetPlayerChoice(1, 2);

                                switch (restartGame)
                                {
                                    case 1:
                                        Start();
                                        break;
                                    case 2:
                                        EndGame();
                                        return;
                                }
                                break;
                            case 3:
                                EndGame();
                                return;
                        }

                    }
                    else
                    {   // if player doesn't have treasure in bag
                        Console.Clear();
                        Console.WriteLine("Du letar i väskan men det finns ingen skatt där.");
                        Console.WriteLine("Du måste ge skatten till mig för att kunna vinna spelet säger prinsessan.");
                        Console.WriteLine("");
                        Console.WriteLine("Vad vill du göra?");
                        Console.WriteLine("1. Börja om spelet");
                        Console.WriteLine("2. Avsluta spelet");

                        int startOver = GetPlayerChoice(1, 2);

                        switch (startOver)
                        {
                            case 1:
                                Start();
                                break;
                            case 2:
                                EndGame();
                                return;
                        }
                    }
                    break;
                case 2: // if player chose "jag har inte skatten" -option
                    Console.Clear();
                    Console.WriteLine("Jag har tyvärr inte din skatt, säger du till prinsessan.");
                    Console.WriteLine("Vilken otur svarar prinsessan. Du måste ge den till mig för att kunna vinna spelet.");
                    Console.WriteLine("");
                    Console.WriteLine("Vad vill du göra?");
                    Console.WriteLine("1. Börja om spelet");
                    Console.WriteLine("2. Avsluta spelet");

                    int startNewGame = GetPlayerChoice(1, 2);

                    switch (startNewGame)
                    {
                        case 1:
                            Start();
                            break;
                        case 2:
                            EndGame();
                            return;
                    }

                    break;
                case 3:
                    EndGame();
                    return;
            }

        }

        // 
        private void EndGame()
        {
            Console.WriteLine("Tack för att du spelade! :) Hej då.");
        }

        // check and get which choice player chose.
        private int GetPlayerChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write($"Vänligen ange ett nummer mellan {min} och {max}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
        }
    }
}
