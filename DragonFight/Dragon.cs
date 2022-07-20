using System;

namespace DragonFight
{
    class Dragon : IUtils
    {
        // Vlastnosti draka
        public int Strength { get; set; }
        public int Mobility { get; set; }
        public int Inteligence { get; set; }
        public int Fear { get; set; }         // Fear modify dragon attack
        public int Health { get; set; }

        // Vytvoření draka
        public Dragon(ref Random rnd)
        {
            Strength = rnd.Next(1, 10) + 50;       // Drakova síla je navýšena o 50
            Mobility = rnd.Next(1, 10);
            Inteligence = rnd.Next(1, 10);
            Fear = rnd.Next(1, 10);
            Health = rnd.Next(1, 10) + 50;     // Drakovy životy jsou navýšeny o 50
        }

        // Metoda pro drakův útok
        public int Attack() => Strength + Fear;

        // Vrací true nebo false na základě toho, zda je drak naživu
        public bool IsAlive() => (Health > 0);

        // Dragon utrží zranění
        public void BeInjuries(int injured) => Health -= injured;

        // Vypsání statů draka 
        public override string ToString()
        {
            string ret = "";

            ret += new string('=', 12) + " DRAGON " + new string('=', 12) + "\n";
            ret += "Strength:\t\t" + Strength + "\n";
            ret += "Mobility:\t" + Mobility + "\n";
            ret += "Inteligence:\t" + Inteligence + "\n";
            ret += "Fear:     \t" + Fear + "\n";
            ret += "Health:\t\t" + Health + "\n";
            ret += new string('=', 30);
            return ret;
        }
    }
}
