namespace Bagsik_Ng_Malayan_The_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMenu();
        }

        public static void GameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to play....");
            Console.ReadKey();
            Thread.Sleep(400);
            Console.Clear();

            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("<======} BAGSIK NG MALAYAN! {======>\n\n1. } NEW GAME\n2. } LOAD CHAPTER\n3. } CREDITS\n4. } EXIT GAME\n\nEnter the number of your choice: ");
                    int userChoice = int.Parse(Console.ReadLine());

                    if (userChoice.Equals(1)) NewGame();
                    else if (userChoice.Equals(2)) LoadChap();
                    else if (userChoice.Equals(3)) Credits();
                    else if (userChoice.Equals(4))
                    {
                        Console.WriteLine("\nThank you for playing our Game, Farewell!\n"); Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input.\n\nPlease choose your preffered game mode from the list of choices.\n"); Thread.Sleep(2000); Console.Clear(); continue;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list."); Thread.Sleep(2000); Console.Clear();
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input was too long and does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                    continue;
                }

            } while (true);
        }

        public static void NewGame()
        {
            FileLoader file = new();
            DialogueDisplayer dialogues = new();

            Chap1();
            Chap2();
            Chap3();
            Chap4();
            file.ReadFile(0);
            dialogues.DisplayOneByOne(file.dialogues1);
            if (AskPath() == 2)
            {
                Chap5();
                Chap6();
                Credits();
            }
            else
            {
                dialogues.DisplayOneByOne(file.dialogues2);
                Credits();
            }
        }

        public static void LoadChap()
        {
            bool valid = true;

            Thread.Sleep(400);
            Console.Clear();

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("<==========} LIST OF CHAPTERS {==========>\n\n1. } Chapter 1: Choc - Nut\n2. } Chapter 2: No ID? No Entry!\n3. } Chapter 3: Matalim na Dila\n4. } Chapter 4: ASK-KEY\n5. } Chapter 5: Kisap - Mata\n6. } Chapter 6: Duelo de Magia\n7. } RETURN TO MAIN MENU\n\nEnter the number of your choice: ");
                    int chapChoice = int.Parse(Console.ReadLine());

                    switch (chapChoice)
                    {
                        case 1: Chap1(); break;
                        case 2: Chap2(); break;
                        case 3: Chap3(); break;
                        case 4: Chap4(); break;
                        case 5: Chap5(); break;
                        case 6: Chap6(); break;
                        case 7: Console.Clear(); valid = false; break;
                        default:
                            Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                            valid = true; break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                    valid = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input was too long and does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                    valid = true;
                }

            } while (valid);
        }

        public static void Chap1()
        {
            FileLoader file = new();
            BattleSimulation sim = new();
            DialogueDisplayer dialogues = new();
            Weapons weapon = new();

            file.ReadFile(1);
            dialogues.DisplayOneByOne(file.dialogues1);
            sim.BattleRound(file.characters, weapon.TurumpoUpgrade);
            dialogues.DisplayOneByOne(file.dialogues2);
        }

        public static void Chap2()
        {
            FileLoader file = new();
            Game chaseGame = new();
            DialogueDisplayer dialogues = new();

            file.ReadFile(2);
            dialogues.DisplayOneByOne(file.dialogues1);
            chaseGame.Run();
            dialogues.DisplayOneByOne(file.dialogues2);
        }

        public static void Chap3()
        {
            FileLoader file = new();
            BattleSimulation sim = new();
            DialogueDisplayer dialogues = new();
            Weapons weapon = new();

            file.ReadFile(3);
            dialogues.DisplayOneByOne(file.dialogues1);
            BattleInstructions();
            sim.BattleRound(file.characters, weapon.TurumpoUpgrade);
            dialogues.DisplayOneByOne(file.dialogues2);
        }

        public static void Chap4()
        {
            FileLoader file = new();
            LockGame codeGame = new();
            DialogueDisplayer dialogues = new();

            file.ReadFile(4);
            dialogues.DisplayOneByOne(file.dialogues1);
            codeGame.GuessTheCode();
            dialogues.DisplayOneByOne(file.dialogues2);
        }

        public static void Chap5()
        {
            FileLoader file = new();
            BattleSimulation sim = new();
            DialogueDisplayer dialogues = new();
            Weapons weapon = new();

            file.ReadFile(5);
            dialogues.DisplayOneByOne(file.dialogues1);
            BattleInstructions();
            sim.BattleRound(file.characters, weapon.TSquareUpgrade);
            dialogues.DisplayOneByOne(file.dialogues2);
        }

        public static void Chap6()
        {
            FileLoader file = new();
            BattleSimulation sim = new();
            DialogueDisplayer dialogues = new();
            Weapons weapon = new();

            file.ReadFile(6);
            dialogues.DisplayOneByOne(file.dialogues1);
            BattleInstructions();
            sim.BattleRound(file.characters, weapon.CyclopsEyeUpgrade);
            dialogues.DisplayOneByOne(file.dialogues2);
        }

        public static void Credits()
        {
            FileLoader file = new();
            DialogueDisplayer dialogues = new();

            Console.Clear();
            file.ReadFile(7);
            dialogues.DisplayAllAtOnce(file.dialogues1);
        }

        public static void BattleInstructions()
        {
            FileLoader file = new();
            DialogueDisplayer dialogues = new();

            bool active = true;

            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Would you like to view the battle instructions? { YES | NO }: ");
                    string userInput = Console.ReadLine().ToUpper();

                    switch (userInput)
                    {
                        case "YES":
                            file.ReadFile(8);
                            dialogues.DisplayOneByOne(file.dialogues1);
                            break;
                        case "NO":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\nProceeding to the battle...");
                            Thread.Sleep(1000);
                            active = false;
                            break;
                        default:
                            Console.WriteLine("\nInvalid input. Please enter either 'YES' or 'NO'.\n");
                            Thread.Sleep(2000);
                            Console.Clear();
                            continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input. Please enter either 'YES' or 'NO'.\n"); Thread.Sleep(2000); Console.Clear();
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nInvalid Input. Please enter either 'YES' or 'NO'.\n"); Thread.Sleep(2000); Console.Clear();
                    continue;
                }
            } while (active);
        }

        public static int AskPath()
        {
            int endIndicator;
            int confirmation;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("<======} CHOOSE YOUR PATH {======>\n\n");
                    Console.Write("Which path will you take?\n\n1 } PEACEFUL ENDING\n2 } FULFILL THE PROPHECY\n\nEnter the number of your choice: ");

                    if (int.TryParse(Console.ReadLine(), out endIndicator) && endIndicator.CompareTo(0).Equals(1) && endIndicator.CompareTo(3).Equals(-1))
                    {
                        Console.Write("\n{ 1 - CONFIRM | 2 - RETURN }\n\nDo you really wish to continue? : ");

                        if (int.TryParse(Console.ReadLine(), out confirmation) && confirmation.CompareTo(0).Equals(1) && confirmation.CompareTo(3).Equals(-1))
                        {
                            if (endIndicator.Equals(1) && confirmation.Equals(1))
                            {
                                endIndicator = 1;
                                break;
                            }
                            else if (endIndicator.Equals(2) && confirmation.Equals(1))
                            {
                                endIndicator = 2;
                                break;
                            }
                            else
                            {
                                Thread.Sleep(2000); Console.Clear();
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n"); Thread.Sleep(2000); Console.Clear();
                    continue;
                }

            } while (true);

            return endIndicator;
        }
    }

    internal abstract class Tactics
    {
        public abstract void SelectAtk();
        public abstract void ClearAtkLogs();
    }

    internal class EnemyTurn : Tactics
    {
        private HashSet<int> EnemyAtkCD { get; set; }
        private int enemyAtkNum;
        public int EnemyAtkNum
        {
            get { return enemyAtkNum; }
            set { enemyAtkNum = value; }
        }

        public EnemyTurn()
        {
            EnemyAtkCD = new HashSet<int>();
        }
        public static int RollDice()
        {
            Random rgn = new Random();
            return rgn.Next(4);
        }

        public override void ClearAtkLogs()
        {
            if (EnemyAtkCD.Count.Equals(4))
                EnemyAtkCD.Clear();
        }

        public override void SelectAtk()
        {
            do
            {
                ClearAtkLogs();

                int atkNum = RollDice();

                if (!EnemyAtkCD.Contains(atkNum))
                {
                    EnemyAtkNum = atkNum;
                    break;
                }
                else
                {
                    continue;
                }

            } while (true);
        }

        public void ReRollAtk(bool reRoll)
        {
            if (reRoll.Equals(true))
            {
                SelectAtk();
                EnemyAtkCD.Add(EnemyAtkNum);
            }
            else if (reRoll.Equals(false))
            {
                EnemyAtkCD.Add(EnemyAtkNum);
            }
        }
    }

    internal class UserTurn : Tactics
    {
        private HashSet<int> UserAtkCD { get; set; }
        private const int MINATK = 1;
        private const int MAXATK = 4;
        private int userAtkNum;
        public int UserAtkNum
        {
            get { return userAtkNum; }
            set { userAtkNum = value; }
        }

        public UserTurn()
        {
            UserAtkCD = new HashSet<int>();
        }

        public override void ClearAtkLogs()
        {
            if (UserAtkCD.Count.Equals(4)) UserAtkCD.Clear();
        }

        public void DisplayUsedAtks()
        {
            if (UserAtkCD.Count.Equals(4))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Attack restrictions has been reset.");
            }
            else
            {
                Console.Write("Used Attacks: ");
                foreach (int atkNum in UserAtkCD)
                {
                    Console.Write($"Attack {atkNum}, ");
                }
            }
        }

        public override void SelectAtk()
        {
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nChoose your Attack Strategy\n\n1. } Light\n2. } Normal\n3. } Medium\n4. } Ultimate\n\nEnter the number of your desired Attack: ");
                    int atkChoice = int.Parse(Console.ReadLine());

                    if (atkChoice >= MINATK && atkChoice <= MAXATK)
                    {
                        ClearAtkLogs();

                        if (!UserAtkCD.Contains(atkChoice))
                        {
                            UserAtkCD.Add(atkChoice);
                            UserAtkNum = (atkChoice - 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("\nYour selected Attack Strategy is not yet available.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input was too long and does not meet any choices from the list.\n");
                    continue;
                }
            } while (true);
        }
    }

    internal class BattleSimulation
    {
        private int rollAttempts;
        private int RollAttempts
        {
            get { return rollAttempts; }
            set { rollAttempts = value; }
        }
        public bool ReRollOpt()
        {
            bool reRoll = false;

            do
            {
                try
                {
                    if (!RollAttempts.Equals(0))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nDo you wish to Re-write your Destiny { YES | NO }: ");
                        string rollChoice = Console.ReadLine().ToUpper();

                        if (rollChoice.Equals("YES"))
                        {
                            reRoll = true;
                            --RollAttempts;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\nYour destiny has been re-written by the Gods.");
                            break;
                        }
                        else if (rollChoice.Equals("NO"))
                        {
                            reRoll = false;
                            Console.WriteLine("\nI respect your choice, God Speed to you and to your chosen path.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n");
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input.\n\nYour input does not meet any choices from the list.\n");
                    continue;
                }

            } while (true);

            return reRoll;
        }

        public void SetChances()
        {
            RollAttempts = 3;
        }

        public void DisplayChances()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!RollAttempts.Equals(0))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Number of chances to re-write your destiny: {RollAttempts}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("You have used all of your chances, you are on your own.");
            }
        }

        public static void DisplayBattleStats(Villain enemyChar, Hero mainChar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            enemyChar.DisplayStats();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            mainChar.DisplayStats();
        }

        public static void InitiateUserAtk(UserTurn user, Hero mainChar, Villain enemyChar)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            user.DisplayUsedAtks();
            user.SelectAtk();
            mainChar.DisplayAtk(user.UserAtkNum);
            enemyChar.TakeAtkDmg(mainChar.GenerateAtkDmg(user.UserAtkNum));
        }

        public void InitiateEnemyAtk(EnemyTurn enemy, Villain enemyChar, Hero mainChar)
        {
            enemy.SelectAtk();
            DisplayChances();
            enemy.ReRollAtk(ReRollOpt());
            enemyChar.DisplayAtk(enemy.EnemyAtkNum);
            mainChar.TakeAtkDmg(enemyChar.GenerateAtkDmg(enemy.EnemyAtkNum));
        }

        public static void CheckWinner(Villain enemyChar, Hero mainChar, ref bool respawn, ref bool active)
        {
            if (enemyChar.NotAlive() && !mainChar.NotAlive())
            {
                Console.WriteLine("\n<===================}-O BATTLE RESULTS O-{===================>\n");
                DisplayBattleStats(enemyChar, mainChar);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nVictory Achieved!\n\nYou proved that the prophecy is right about you.\n");
                respawn = false;
                active = false;

            }
            else if (mainChar.NotAlive() && !enemyChar.NotAlive())
            {
                Console.WriteLine("\n<===================}-O BATTLE RESULTS O-{===================>\n");
                DisplayBattleStats(enemyChar, mainChar);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nYou have been defeated.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nGet ready. The Gods have chosen to give you another chance to fulfill your prophecy.\n");
                respawn = true;
                active = false;

            }
            else if (enemyChar.NotAlive() && mainChar.NotAlive())
            {
                Console.WriteLine("\n<===================}-O BATTLE RESULTS O-{===================>\n");
                DisplayBattleStats(enemyChar, mainChar);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIt was a tie, yet you were defeated.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nGet ready. The Gods have chosen to give you another chance to fulfill your prophecy.\n");
                respawn = true;
                active = false;
            }
        }

        public void BattleRound(List<string> characters, int dmgUp)
        {
            Hero mainChar;
            Villain enemyChar;
            UserTurn user;
            EnemyTurn enemy;

            bool respawn = true;

            Thread.Sleep(400);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You must fulfill your prophecy. Let the battle begin!");
            while (respawn)
            {
                try
                {
                    mainChar = new(characters[1], int.Parse(characters[2]), characters[3], characters[4], characters[5], characters[6],
                    int.Parse(characters[7]), int.Parse(characters[8]), int.Parse(characters[9]), int.Parse(characters[10]));

                    enemyChar = new(characters[12], int.Parse(characters[13]), characters[14], characters[15], characters[16], characters[17],
                    int.Parse(characters[18]), int.Parse(characters[19]), int.Parse(characters[20]), int.Parse(characters[21]));

                    mainChar.GetWeaponPowerUp(dmgUp);

                    user = new();
                    enemy = new();

                    bool active = true;

                    SetChances();

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n<===================}-O BATTLE ROUND O-{===================>\n");
                        DisplayBattleStats(enemyChar, mainChar);
                        InitiateUserAtk(user, mainChar, enemyChar);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        CheckWinner(enemyChar, mainChar, ref respawn, ref active);

                        if (active)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            InitiateEnemyAtk(enemy, enemyChar, mainChar);
                            CheckWinner(enemyChar, mainChar, ref respawn, ref active);
                        }

                    } while (active);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    internal class Weapons
    {
        private readonly int turumpoDmg = 5;
        private readonly int tSquareDMG = 15;
        private readonly int cyclopsEyeDMG = 25;
        public int TurumpoUpgrade
        {
            get { return turumpoDmg; }
        }
        public int TSquareUpgrade
        {
            get { return tSquareDMG; }
        }
        public int CyclopsEyeUpgrade
        {
            get { return cyclopsEyeDMG; }
        }
    }
}
