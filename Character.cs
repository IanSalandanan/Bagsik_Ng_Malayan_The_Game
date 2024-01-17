using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsik_Ng_Malayan_The_Game
{
    public class Character
    {
        private string name;
        private int health;
        private const int MINHEALTH = 0;
        private const int MAXHEALTH = 200;

        public string Name { get { return name; } set { name = value; } }

        public int Health
        {
            get { return health; }
            set
            {
                if (value < MINHEALTH)
                    health = MINHEALTH;
                else if (value > MAXHEALTH)
                    health = MAXHEALTH;
                else
                    health = value;
            }
        }

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeAtkDmg(int atkDmg)
        {
            if (Health > MINHEALTH)
                Health -= atkDmg;
        }

        public bool NotAlive()
        {
            return Health <= MINHEALTH;
        }
    }
    public class Villain : Character
    {
        private string lightAtk;
        private string normalAtk;
        private string mediumAtk;
        private string ultAtk;
        private int lightAtkDmg;
        private int normalAtkDmg;
        private int mediumAtkDmg;
        private int ultAtkDmg;

        public string LightAtk
        { get { return lightAtk; } set { lightAtk = value; } }
        public string NormalAtk
        { get { return normalAtk; } set { normalAtk = value; } }
        public string MediumAtk
        { get { return mediumAtk; } set { mediumAtk = value; } }
        public string UltAtk
        { get { return ultAtk; } set { ultAtk = value; } }
        public int LightAtkDmg
        { get { return lightAtkDmg; } set { lightAtkDmg = value; } }
        public int NormalAtkDmg
        { get { return normalAtkDmg; } set { normalAtkDmg = value; } }
        public int MediumAtkDmg
        { get { return mediumAtkDmg; } set { mediumAtkDmg = value; } }
        public int UltAtkDmg
        { get { return ultAtkDmg; } set { ultAtkDmg = value; } }

        public Villain(string name, int health, string lightAtk, string normalAtk, string mediumAtk, string ultAtk, int lightAtkDmg, int normalAtkDmg, int mediumAtkDmg, int ultAtkDmg)
            : base(name, health)
        {
            LightAtk = lightAtk;
            NormalAtk = normalAtk;
            MediumAtk = mediumAtk;
            UltAtk = ultAtk;
            LightAtkDmg = lightAtkDmg;
            NormalAtkDmg = normalAtkDmg;
            MediumAtkDmg = mediumAtkDmg;
            UltAtkDmg = ultAtkDmg;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Character: {Name}\nHealth: {Health}\n");
            Console.WriteLine($"Light Attack     (DMG: {LightAtkDmg}): {LightAtk}");
            Console.WriteLine($"Normal Attack    (DMG: {NormalAtkDmg}): {NormalAtk}");
            Console.WriteLine($"Medium Attack    (DMG: {MediumAtkDmg}): {MediumAtk}");
            Console.WriteLine($"Ultimate Attack  (DMG: {UltAtkDmg}): {UltAtk}\n");
        }
        public int GenerateAtkDmg(int dmgNum)
        {
            int[] atkDmg = { LightAtkDmg, NormalAtkDmg, MediumAtkDmg, UltAtkDmg };
            return atkDmg[dmgNum];
        }

        public virtual void DisplayAtk(int atkIndex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] atkName = { LightAtk, NormalAtk, MediumAtk, UltAtk };
            Console.WriteLine($"\n{Name} chose {atkName.GetValue(atkIndex)}!\n");
        }
    }

    public class Hero : Villain
    {
        private int weaponBoost;
        public int WeaponBoost
        { get { return weaponBoost; } set { weaponBoost = value; } }

        public Hero(string name, int health, string lightAtk, string normalAtk, string mediumAtk, string ultAtk, int lightAtkDmg, int normalAtkDmg, int mediumAtkDmg, int ultAtkDmg)
            : base(name, health, lightAtk, normalAtk, mediumAtk, ultAtk, lightAtkDmg, normalAtkDmg, mediumAtkDmg, ultAtkDmg)
        {
            WeaponBoost = weaponBoost;
        }

        public override void DisplayAtk(int atkIndex)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string[] atkName = { LightAtk, NormalAtk, MediumAtk, UltAtk };
            Console.WriteLine($"\n{Name} chose {atkName.GetValue(atkIndex)}!\n");
        }

        public void GetWeaponPowerUp(int increaseDmg)
        {
            weaponBoost = increaseDmg;
            LightAtkDmg += weaponBoost;
            NormalAtkDmg += weaponBoost;
            MediumAtkDmg += weaponBoost;
            UltAtkDmg += weaponBoost;
        }
    }

    internal class FileLoader
    {
        private string filePath;
        public List<string> dialogues1;
        public List<string> dialogues2;
        public List<string> characters;
        public string FilePath
        { get { return filePath; } set { filePath = value; } }

        public FileLoader()
        {
            dialogues1 = new List<string>();
            dialogues2 = new List<string>();
            characters = new List<string>();
        }

        public void PopulateLists(string line, char separator, List<string> set)
        {
            if (line.StartsWith(separator))
                set.AddRange(line.Split(separator));
        }

        public void ReadFile(int chosenChap)
        {
            string line;

            filePath = $"Chapters\\Chapter{chosenChap}.txt";

            try
            {
                using StreamReader reader = new(filePath);
                while ((line = reader.ReadLine()) != null)
                {
                    PopulateLists(line, '/', dialogues1);
                    PopulateLists(line, ';', dialogues2);
                    PopulateLists(line, '|', characters);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nFile not found.\n");
            }
            catch (IOException)
            {
                Console.WriteLine("\nAn error occurred while reading the file.\n");
            }
        }
    }

    public class DialogueDisplayer
    {
        public void DisplayAllAtOnce(List<string> dialogues)
        {
            foreach (string dialogue in dialogues)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(dialogue);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nPress any Key to continue...");
            Console.ReadKey(true);
        }

        public void DisplayOneByOne(List<string> dialogues)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();

            foreach (string dialogue in dialogues)
            {
                if (dialogue == "")
                    continue;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(dialogue);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
