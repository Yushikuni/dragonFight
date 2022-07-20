namespace DragonFight
{
    class Item
    {
        // property of the item
        public string ItemName { get; set; }
        public int Strength { get; set; }
        public int Offense { get; set; }
        public int Defence { get; set; }
        public int Weight { get; set; }
        public bool IsWeapon { get; set; }       // true = is a weapon, false = not a weapon
        public bool TwoHanded { get; set; }     // true = is two handed, false = is not two handed

        // Construction new item
        public Item(string itemName, int Stength, int offense, int defence, int weight, bool isWeapon, bool isTwoHanded)
        {
            ItemName = itemName;
            Strength = Stength;
            Offense = offense;
            Defence = defence;
            Weight = weight;
            IsWeapon = isWeapon;
            TwoHanded = isTwoHanded;
        }

        // Metoda pro výpis předmětů
        public override string ToString()
        {
            string ret = "";

            ret += $"{ItemName.ToUpper(),-20}" +
                   $"{Strength,-10}" +
                   $"{Offense,-10}" +
                   $"{Defence,-10}" +
                   $"{Weight,-10}";
            
            return ret;
        }
    }
}
