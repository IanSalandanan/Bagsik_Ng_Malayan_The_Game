using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsik_Ng_Malayan_The_Game
{
    class MiniGame2
    {
        public void ClearAndPause(int miliSeconds)
        {
            Console.Clear();
            Thread.Sleep(miliSeconds);
        }

        public void DisplayLock(ConsoleColor lockColor, string inputCode, string newCode)
        {

            Console.ForegroundColor = lockColor;
            Console.WriteLine("\n,________________,");
            Console.WriteLine("|                |");
            Console.WriteLine($"|    |{inputCode}|    |");
            Console.WriteLine("|________________|");
            Console.WriteLine("|                |");
            Console.WriteLine($"|       {newCode}      |");
            Console.WriteLine("|  LOCK COMPANY  |");
            Console.WriteLine("|________________|");
        }
    }
    class LockGame : MiniGame2
    {
        public void GuessTheCode()
        {
            int codeCounter = 0;
            string sagot;

            ClearAndPause(1500);

            while (true)
            {
                Random randCode = new Random();
                string charList = "ABCDEFGHIJKLMNOPQRSTUVWXYXZ";
                char[] valueCode = new char[3];
                string passcode;

                for (int a = 0; a < 3; a++)
                {
                    valueCode[a] = charList[randCode.Next(charList.Length)];
                }

                string asciiCode = new string(valueCode);


                for (int attempt = 3; attempt > 0; attempt--)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("<======} LOCKER GAME {======>\n\n");
                    Console.Write("Remaining Attempts: {0} ", attempt);

                    if (codeCounter > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n\nHINT: ASCII Value");

                        if (attempt == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nWARNING! The passcode has changed.");
                        }
                    }

                    DisplayLock(ConsoleColor.Gray, "______", asciiCode);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\nEnter the 6-Digit passcode: ");
                    passcode = Console.ReadLine();

                    if (valueCode.Length == 3)
                    {
                        char firstChar = valueCode[0];
                        char secondChar = valueCode[1];
                        char thirdChar = valueCode[2];

                        int asciiFirst = (int)firstChar;
                        int asciiSecond = (int)secondChar;
                        int asciiThird = (int)thirdChar;

                        string ASCIIEquivalent = asciiFirst.ToString() + asciiSecond.ToString() + asciiThird.ToString();


                        if (ASCIIEquivalent == passcode)
                        {
                            ClearAndPause(1500);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("<======} LOCKER GAME {======>\n");

                            DisplayLock(ConsoleColor.Gray, passcode, asciiCode);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\nThe passcode is correct!");

                            return;
                        }
                        else if (passcode.Length != 6)
                        {
                            ClearAndPause(1500);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("<======} LOCKER GAME {======>\n");

                            DisplayLock(ConsoleColor.Gray, "______", asciiCode);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\nThe passcode should be 6 digits. Please enter the right passcode.");
                        }
                        else
                        {
                            ClearAndPause(1500);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("<======} LOCKER GAME {======>\n");

                            DisplayLock(ConsoleColor.Gray, passcode, asciiCode);

                            Console.ForegroundColor = ConsoleColor.DarkRed;

                            Console.WriteLine("\n\nThe passcode is incorrect!");
                        }

                    }
                    Thread.Sleep(1200);
                    Console.Clear();
                }
                codeCounter += 1;
            }
        }
    }
}
