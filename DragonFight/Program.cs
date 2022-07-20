using System;

namespace DragonFight
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();                             // Vytvoření nové instance generátoru pseudonáhodných čísel
            Warrior warrior = new Warrior(ref rnd);             // Vytvoreni noveho valecnika
            Dragon dragon = new Dragon(ref rnd);                         // Vytvoření nového draka
            Item[] items = new Item[5];                   // Vytvoreni pole peti objektu typu predmet

            LoadItems(ref items);                           // Načte předměty do pole předmětů
            ListionOfTheStoryBeginning();                                 // Vypíše příběh do konzole
            ListingIntems(ref items);                           //Vypíše přeměty v tuhle


            EqipItems(ref warrior, ref items);
            warrior.RecalculateItemsAfterEqip();

            AnotherPartOfStory();

            Fight(ref warrior, ref dragon);

            if(warrior.IsAlive())
            {
                FirstEpilog();
            }
            else
            {
                SecondEpilog();
            }
            Console.ReadLine();
        }

        // Vypíše menu ovládání hry
        public static void MenuListing()
        {
            Console.WriteLine("\n" + new string('-', 12) + " MENU " + new string('-', 12));     // Formátovaný výpis hlavičky
            Console.WriteLine("0 - Quit the Game");
            Console.WriteLine("1 - Player Stats");
            Console.WriteLine("2 - Dragon Stats");
            Console.WriteLine("3 - Display List of Items");
            Console.WriteLine("4 - Equip items");
            Console.WriteLine("5 - Fight the Dragon");
            Console.WriteLine(new string('-', 30));                                             // Formátovaný výpis patičky
        }

        // Simuluje boj mezi drakem a hráčem
        public static void Fight(ref Warrior warrior, ref Dragon drak)
        {
            Random rnd = new Random(); 
            int whoAttack = 1;                        // 1 = player, 2 = dragon

            while (true)
            {
                if (warrior.BackpackAppears()) 
                {
                    Console.WriteLine("\nYou remembered  that your backpack contains an item and you’ve taken it out in order to observe it properly…:Cookies Power Up No Killers are crispy and suitable for travelling." +
                        "\n You used these cookies and Dragon gave you released the prince without a fight.");
                    break;  
                }

                if (!warrior.IsAlive())
                {
                    Console.WriteLine("You have died in a cruel and painful way!");
                    break;  
                }

                if (!drak.IsAlive())
                {
                    Console.WriteLine("You have defeated the Dragon and saved the price!");
                    break;  
                }

                if (whoAttack == 1)
                {
                    drak.BeInjuries(warrior.Attack());  
                    Console.WriteLine("Dragon was hit!");
                    Console.WriteLine($"Dragon’s remaining health: {drak.Health}");
                    whoAttack = 2;  // Další v pořadí útočení bude dragon
                }
                else // Útočí dragon
                {
                    if (warrior.DodgeBeforeAttack(ref rnd))   
                    {
                        Console.WriteLine("Player successfully avoids being hit!");
                        Console.WriteLine($"Player’s remaining health {warrior.Health}");
                    }
                    else
                    {
                        warrior.BeInjuries(drak.Attack());   
                        Console.WriteLine("Player was hit!");
                        Console.WriteLine($"Player’s remaining health {warrior.Health}");
                    }

                    whoAttack = 1;  // Ńext attack is from player
                }
            }
        }

        public static void ListionOfTheStoryBeginning()
        {
            Console.WriteLine("The Calitor is a kingdom ruled by women. You are an adventurer who desires to settle in the capital city called Zaa. \n" +
                              "First you have to complete a quest from the queen herself: “You must save the prince from the dragon grasp“.\n" +
                              "Now you might wonder (be wondering): “How do I know that?“ “I saw it, some flying lizard at night. It had a green or some darkish color, I don’t remember. I think, these lizards like high places, don’t they?\n" +
                              "So why are you still here? Go now!“ \n");
            Console.WriteLine("You have decided to go home and approached your wooden chest.\nYou have found several items in the chest…\n");
            Console.WriteLine("\nYou want to bring take all of them but you know you cannot carry everything…");

        }
        public static void AnotherPartOfStory()
        {
            Console.WriteLine("\n\nYou travelled across the mountains directly to the highest tower that you have ever seen.\n" +
                "\nOnce you came closer, you heard a roar:“\"RAÚÚÚÚÚÚL\"“, It was at this moment you have realised you are screwed." +
                "\nAll you can do is to come closer to the sleeping dragon and...");
        }

        public static void FirstEpilog()
        {
            Console.WriteLine("\nYou saved the prince, Congratulations!!" +
                "\nThis prince is so annoying, that you wanna kill him with your own hands. Unfortunately before you are able to do that, you’ve reached the walls of Zaa." +
                "\nEveryone welcomes you, HERO!" +
                "\nThe queen has invited you to her palace and bestows upon you the title of: The Knight of Calitor. " +
                "\nThis title comes with quiet patrols where nothing happens and a luxury house with a steward." +
                "\nYou feel honored and you accept." +
                "\nEnd of Game. Thanks for playing, have a nice day!");
            Console.WriteLine("Press ENTER for a quick game.");
        }

        public static void SecondEpilog()
        {
            Console.WriteLine("\n\nWhat a shame, there’s no reincarnation or something like that is not here. You have not been born again…\nPress ENTER for a quick game.");
        }

        // Eqip warrior items
        public static void EqipItems(ref Warrior valecnik, ref Item[] items)
        {
            int idx;

            while (true)
            {
                Console.WriteLine("\nEnter index of item you want to equip \n(-1 — for exit) (5 — for list of items in the chest): ");
                idx = Convert.ToInt32(Console.ReadLine());

                if (idx == -1)
                {
                    break;
                }

                if (idx == 5)
                {
                    ListingIntems(ref items);
                    continue;
                }

                try
                {
                    if (valecnik.EquipItem(ref items[idx]))
                    {
                        Console.WriteLine($"Item {items[idx].ItemName} was successfully equipped!");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The value you have entered does not match any item!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Loads the array of objects it receives as an argument
        public static void LoadItems(ref Item[] items)
        {
            items[0] = new Item("Dagger", 2, 0, 0, 2, true, false);
            items[1] = new Item("One-handed sword", 5, 0, 0, 30, true, false);
            items[2] = new Item("Two-handed sword", 7, 1, 0, 85, true, true);
            items[3] = new Item("Plate armor", 0, 0, 100, 95, false, false);
            items[4] = new Item("Shield", 0, 0, 1, 50, true, false); // I've rewritten one value so that the shield is treated as a weapon, due to the collision with the two-handed
        }

        // Vypíše pole předmětů, které obdrži jako argument
        public static void ListingIntems(ref Item[] items)
        {
            // Formatted table header listing with files
            Console.WriteLine($"{"Index",-10}" +
                              $"{"Item name",-20}" +
                              $"{"Strength",-10}" +
                              $"{"Offense",-10}" +
                              $"{"Defence",-10}" +
                              $"{"Weight",-10}");

            for (var i = 0; i < items.Length; i++)
            {
                Console.Write($"{i,-10}");
                Console.WriteLine(items[i]);
            }
        }
    }
}