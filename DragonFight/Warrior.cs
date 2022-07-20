using System;
using System.Collections.Generic;

namespace DragonFight
{
    class Warrior : IUtils
    {
        // Warrior atributs
        public int Strength { get; set;}
        public int Mobility { get; set; }
        public int Inteligence { get; set; }
        public int Charisma { get; set; }
        public int Health { get; set; }
        public List<Item> EquipedItems { get; set; }             // List of deployed items
        public int HandsAreFull { get; set; }                   // Indicates in how many hands the player is currently holding the weapon

        // Constructor for new warrior
        public Warrior(ref Random rnd)
        {
            Strength = rnd.Next(1, 10);
            Mobility = rnd.Next(1, 10);
            Inteligence = rnd.Next(1, 10);
            Charisma = rnd.Next(1, 10);
            Health = rnd.Next(1, 10);
            EquipedItems = new List<Item>();             // When creating a warrior, you need to allocate memory for the list
            HandsAreFull = 0;
        }

        // Deploys an item to a warrior, returns true if the item was successfully deployed
        public bool EquipItem(ref Item predmet)
        {
            if (predmet.Strength > Strength)
            {
                // Throws an exception if the warrior's strength is not sufficient to deploy the item
                throw new Exception("You can't eqip this item because you are weak!");
            }

            if (EquipedItems.Contains(predmet))
            {
                // Throws an exception if a player attempts to deploy an item that is already deployed
                throw new Exception("You already eqip this item");
            }

            if (predmet.IsWeapon)
            {
                if (predmet.TwoHanded)
                {
                    if (HandsAreFull + 2 > 2)
                    {
                        // Throws an exception if the warrior's hand is already fully occupied
                        throw new Exception("Your heand are full. You can't have another item in your hands!");
                    }

                    HandsAreFull += 2;
                }
                else
                {
                    if (HandsAreFull + 1 > 2) 
                    {
                        // Throws an exception if the warrior's hand is already fully occupied
                        throw new Exception("Your hands are full.");
                    }

                    HandsAreFull += 1;
                }
            }
            
            EquipedItems.Add(predmet);      // Adds the selected item to the list of items
            return true;
        }

        // Recalculates the player's stats after deploying the item
        public void RecalculateItemsAfterEqip()
        {
            var weight = 0;

            // Goes through the list of all deployed items and adjusts the player's power and lives
            foreach (var item in EquipedItems)
            {
                Strength += item.Offense;
                Health += item.Defence;
                weight += item.Weight;
            }

            // If weigh is greater than 100 then minus one point from mobility
            if (weight > 100)
            {
                Mobility -= 1;
            }
        }

        // If warrior is clever backpack show up
        public bool BackpackAppears() => (Inteligence >= 4);

        // Attack represents player strenght
        public int Attack() => Strength;

        // Player Be Injure
        public void BeInjuries(int injured) => Health -= injured;

        public bool DodgeBeforeAttack(ref Random rnd)
        {
            var dodge = rnd.Next(0, 2);  // 0 = fail, 1 = success for dodge

            return (dodge == 1);
        }

        public bool IsAlive() => (Health > 0);

        public override string ToString()
        {
            string ret = "";

            ret += new string('=', 10) + " Warrior " + new string('=', 10) + "\n";
            ret += "Strength:\t\t" + Strength + "\n";
            ret += "Mobility:\t" + Mobility + "\n";
            ret += "Inteligence:\t" + Inteligence + "\n";
            ret += "Charisma:\t" + Charisma + "\n";
            ret += "Health:\t\t" + Health + "\n";
            ret += new string('=', 30);

            return ret;
        }
    }
}
