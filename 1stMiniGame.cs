using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsik_Ng_Malayan_The_Game
{
    class Game 
    {
        private char[,] grid;
        private int KaspianPositionX;
        private int KaspianPositionY;
        private int ManongGPositionX;
        private int ManongGPositionY;
        private bool gameOver;
        private Random random;
        private QuestionManager questionManager;

        public Game()
        {
            KaspianPositionX = 4;
            KaspianPositionY = 2;
            ManongGPositionX = 0;
            ManongGPositionY = 2;
            gameOver = false;
            random = new Random();
            questionManager = new QuestionManager();
        }

        public void Run() 
        {
            InitializeGame();
            while (!gameOver)
            {
                DrawGrid();
                questionManager.AskQuestion(this);

                try
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Choose your desired move (W - Up, S - Down, A - Left, D - Right)");
                        ConsoleKey key = Console.ReadKey(true).Key;

                        if (key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)
                        {
                            ProcessInput(key);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Choice. Choose only W, A, S, or D.");
                        }
                    }
                }
                catch (InvalidOperationException e) { Console.WriteLine("Invalid operation: " + e.Message); }
                MoveManongG();
                CheckCollision();
            }
        }

        private void InitializeGame()
        {
            grid = new char[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid[i, j] = '-';
                }
            }
            KaspianPositionX = 4;
            KaspianPositionY = 2;
            ManongGPositionX = 0;
            ManongGPositionY = 2;
            grid[KaspianPositionX, KaspianPositionY] = 'K';
            grid[ManongGPositionX, ManongGPositionY] = 'M';
            gameOver = false;
            random = new Random();
            questionManager.InitializeQuestions();

            questionManager.ClearAskedQuestions(); 
        }

        public void DrawGrid() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<======} PATINTERO {======>\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (grid[i, j] == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(grid[i, j] + " ");
                        Console.ResetColor();
                    }
                    else Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void ProcessInput(ConsoleKey key) 
        {
            bool validMove = false;

            while (!validMove)
            {
                switch (key)
                {
                    case ConsoleKey.W:
                        if (KaspianPositionX > 0)
                        {
                            grid[KaspianPositionX, KaspianPositionY] = '-';
                            KaspianPositionX--;
                            grid[KaspianPositionX, KaspianPositionY] = 'K';
                            validMove = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Invalid move... You cannot move outside the grid/line.");
                            key = Console.ReadKey(true).Key;
                        }
                        break;
                    case ConsoleKey.S:
                        if (KaspianPositionX < 4)
                        {
                            grid[KaspianPositionX, KaspianPositionY] = '-';
                            KaspianPositionX++;
                            grid[KaspianPositionX, KaspianPositionY] = 'K';
                            validMove = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Invalid move... You cannot move outside the grid/line.");
                            key = Console.ReadKey(true).Key;
                        }
                        break;
                    case ConsoleKey.A:
                        if (KaspianPositionY > 0)
                        {
                            grid[KaspianPositionX, KaspianPositionY] = '-';
                            KaspianPositionY--;
                            grid[KaspianPositionX, KaspianPositionY] = 'K';
                            validMove = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Invalid move... You cannot move outside the grid/line.");
                            key = Console.ReadKey(true).Key;
                        }
                        break;
                    case ConsoleKey.D:
                        if (KaspianPositionY < 4)
                        {
                            grid[KaspianPositionX, KaspianPositionY] = '-';
                            KaspianPositionY++;
                            grid[KaspianPositionX, KaspianPositionY] = 'K';
                            validMove = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Invalid move... You cannot move outside the grid/line.");
                            key = Console.ReadKey(true).Key;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        key = Console.ReadKey(true).Key;
                        break;
                }
            }
        }

        private void MoveManongG()
        {
            try
            {
                int KaspianX = KaspianPositionX;
                int KaspianY = KaspianPositionY;
                int ManongGX = ManongGPositionX;
                int ManongGY = ManongGPositionY;

                ArrayList directions = new ArrayList() { 0, 1, 2, 3 };

                if (ManongGX < KaspianX) directions.Remove(0); 
                else if (ManongGX > KaspianX) directions.Remove(1); 

                if (ManongGY < KaspianY) directions.Remove(2); 
                else if (ManongGY > KaspianY) directions.Remove(3); 

                int direction = (int)directions[random.Next(directions.Count)];

                switch (direction)
                {
                    case 0: // UP
                        if (ManongGX > 0 && ManongGX > KaspianX)
                        {
                            grid[ManongGX, ManongGY] = '-';
                            ManongGX--;
                        }
                        break;
                    case 1: // DOWN
                        if (ManongGX < 4 && ManongGX < KaspianX)
                        {
                            grid[ManongGX, ManongGY] = '-';
                            ManongGX++;
                        }
                        break;
                    case 2: // LEFT
                        if (ManongGY > 0 && ManongGY > KaspianY)
                        {
                            grid[ManongGX, ManongGY] = '-';
                            ManongGY--;
                        }
                        break;
                    case 3: // RIGHT
                        if (ManongGY < 4 && ManongGY < KaspianY)
                        {
                            grid[ManongGX, ManongGY] = '-';
                            ManongGY++;
                        }
                        break;
                }

                ManongGPositionX = ManongGX;
                ManongGPositionY = ManongGY;
                grid[ManongGPositionX, ManongGPositionY] = 'M';
            }
            catch (Exception e) { Console.WriteLine("An error occured while moving ManongG: " + e.Message); }
        }

        private void CheckCollision()
        {
            if (KaspianPositionX == ManongGPositionX && KaspianPositionY == ManongGPositionY)
            {
                gameOver = true;
                DrawGrid();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nYou have been caught by Manong Guard!\n");
                GameOverMenu();
            }
            else if (KaspianPositionX == 0)
            {
                gameOver = true;
                DrawGrid();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nGreat Job! You have successfully passed through.\n");
            }
        }

        private void GameOverMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any key to play again...\n");
            Console.ReadKey();
            Thread.Sleep(500);
            InitializeGame();
        }
    }
    class QuestionManager 
    {
        private string[,] questions;
        private ArrayList askedQuestions;
        private Random random;

        public QuestionManager()
        {
            askedQuestions = new ArrayList();
            random = new Random();
            InitializeQuestions();
        }

        public void ClearAskedQuestions()
        {
            askedQuestions.Clear();
        }
        public void AskQuestion(Game game)
        {
            bool answeredCorrectly = false;
            int randomIndex;

            do
            {
                randomIndex = random.Next(questions.GetLength(0));

                if (!askedQuestions.Contains(randomIndex))
                {
                    askedQuestions.Add(randomIndex);

                    Console.Clear(); 
                    game.DrawGrid(); 

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(questions[randomIndex, 0]);
                    Console.WriteLine();
                    Console.WriteLine(questions[randomIndex, 1]);
                    Console.WriteLine(questions[randomIndex, 2]);
                    Console.WriteLine(questions[randomIndex, 3]);
                    Console.Write("\nEnter the letter of your answer: ");
                    string answer = Console.ReadLine();

                    if (answer.ToLower() != questions[randomIndex, 4].ToLower())
                    {
                        Console.Clear(); 
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nIncorrect Answer!");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\nAnswer another question.\n");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nAmazing! You are correct!\n");
                        answeredCorrectly = true;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nPress any key to continue...\n");
                    Console.ReadKey();
                }
                
                if (askedQuestions.Count == questions.GetLength(0)) askedQuestions.Clear();
            } while (!answeredCorrectly);
        }

        public void InitializeQuestions()
        {
            try
            {
                string filePath = "QBank.txt";
                string[] qLines = File.ReadAllLines(filePath);

                questions = new string[qLines.Length, 5];

                for (int i = 0; i < qLines.Length; i++)
                {
                    string[] qParts = qLines[i].Split(';');

                    for (int j = 0; j < 5; j++)
                    {
                        questions[i, j] = qParts[j];
                    }
                }
            }
            catch (FileNotFoundException e) { Console.WriteLine("File not found: " + e.Message); }
            catch (Exception e) { Console.WriteLine("An error occurred while reading the file: " + e.Message); }
        }
    }
}
