namespace Hangman_Lite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.Title = "Hangman Lite | Menu";
                Console.WriteLine("Menu\n-Singleplayer\n-Multiplayer\n-Close\n\nType Here:");
                string choice = Console.ReadLine();
                if (choice.Trim().ToLower().Contains("multi")) MultiHangmanGame();
                else if (choice.Trim().ToLower().Contains("single")) HangmanGame();
                else if (choice.Trim().ToLower().Contains("close")) break;
                else Console.WriteLine("Please pick a valid choice.");
            }
        }
        static public void MultiHangmanGame()
        {
            Console.Title = "Hangman Lite | Multi Player";
            Random randGen = new Random();
            Console.WriteLine("Welcome to Hangman Lite");
            Console.WriteLine("What will the word be?");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = Console.BackgroundColor;
            string word = Console.ReadLine().ToUpper().Trim();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            string displayWord = "";
            int wrongGuesses = 0;
            string guessedLetters = "";
            foreach (char i in word) displayWord += "_";
            bool gameIsOn = true;
            while (gameIsOn)
            {
                string curGuess = "";
                Thread.Sleep(500);
                Console.Clear();
                if (displayWord == word)
                {
                    Console.WriteLine($"You Won! The word was {word}, you guessed {wrongGuesses}/3 letters wrong.");
                    break;
                }
                Console.WriteLine($"Guessed letters: {guessedLetters}");
                MakeHangman(wrongGuesses);
                if (wrongGuesses == 3)
                {
                    Thread.Sleep(500);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    MakeHangman(4);
                    Console.WriteLine($"You Lost! The word was {word}");
                    break;
                }
                Console.WriteLine(displayWord);
                while (true)
                {
                    Console.WriteLine("Guess a letter...");
                    curGuess = Console.ReadLine().ToUpper();
                    if (curGuess == word)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();
                        Console.WriteLine($"You Won! The word was {word}, you guessed {wrongGuesses}/3 letters wrong.");
                        gameIsOn = false;
                        break;
                    }
                    else if (curGuess.Length != 1 || displayWord.Contains(curGuess) || guessedLetters.Contains(curGuess) || !"ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(curGuess)) Console.WriteLine("Invalid guess.");
                    else break;
                }
                if (gameIsOn && word.Contains(curGuess))
                {
                    int count = 0;
                    foreach (char i in word)
                    {
                        string i2 = Convert.ToString(i);
                        if (i2 == curGuess)
                        {
                            displayWord = displayWord.Remove(count, 1).Insert(count, curGuess);
                        }
                        count++;
                    }
                }
                else
                {
                    if (gameIsOn)
                    {
                        Console.WriteLine("That letter is not in the word.");
                        wrongGuesses++;
                    }
                }
                guessedLetters += curGuess;
            }
        }
        static public void HangmanGame()
        {
            Console.Title = "Hangman Lite | Single Player";
            Random randGen = new Random();
            Console.WriteLine("Welcome to Hangman Lite");
            List<string> hangmanWords = new List<string>() { "COMPUTER","TROLLING","HELLO", "KEYBOARD", "MOUSE", "CHEESE", "PHONE", "WALK", "WINDOW", "CAT", "DOG", "KEYS", "TRUCK", "GRASS", "HANGMAN", "STREET", "TEACHER", "STUDENT", "DEBUG", "PROJECT", "ANALYZE", "COMMIT", "FLOWER", "PAGE", "ESSAY", "COOKING", "TYPING", "CORD", "RAM", "LITE", "NUTRITION", "PROGRAM", "MONKEY", "BLACK", "WHITE", "YELLOW", "KIAN", "HUNTER", "HAT", "DRINK", "WATER", "FIRE", "ASSINGNMENT", "TOOLBOX", "DEEP", "CHANGES", "TRUE", "FALSE" };
            string word = hangmanWords[randGen.Next(0, hangmanWords.Count)];
            string displayWord = "";
            int wrongGuesses = 0;
            string guessedLetters = "";
            foreach (char i in word) displayWord += "_";
            bool gameIsOn = true;
            while (gameIsOn)
            {
                string curGuess = "";
                Thread.Sleep(500);
                Console.Clear();
                if(displayWord == word)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine($"You Won! The word was {word}, you guessed {wrongGuesses}/3 letters wrong.");
                    break;
                }
                Console.WriteLine($"Guessed letters: {guessedLetters}");
                MakeHangman(wrongGuesses);
                if (wrongGuesses == 3)
                {
                    Thread.Sleep(500);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    MakeHangman(4);
                    Console.WriteLine($"You Lost! The word was {word}");
                    break;
                }
                Console.WriteLine(displayWord);
                while (true)
                {
                    Console.WriteLine("Guess a letter...");
                    curGuess = Console.ReadLine().ToUpper().Trim();
                    if (curGuess == word)
                    {
                        Console.WriteLine($"You Won! The word was {word}, you guessed {wrongGuesses}/3 letters wrong.");
                        gameIsOn = false;
                        break;
                    }
                    else if (curGuess.Length != 1 || displayWord.Contains(curGuess) || guessedLetters.Contains(curGuess) || !"ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(curGuess)) Console.WriteLine("Invalid guess.");
                    else break;
                }
                if (gameIsOn && word.Contains(curGuess))
                {
                    int count = 0;
                    foreach (char i in word)
                    {
                        string i2 = Convert.ToString(i);
                        if (i2 == curGuess)
                        {
                            displayWord = displayWord.Remove(count, 1).Insert(count, curGuess);
                        }
                        count++;
                    }
                }
                else
                {
                    if (gameIsOn)
                    {
                        Console.WriteLine("That letter is not in the word.");
                        wrongGuesses++;
                    }
                }
                guessedLetters += curGuess;
            }
        }
        static public void MakeHangman(int stage)
        {
            if (stage == 0)
            {
                Console.WriteLine("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========");
            }
            else if (stage == 1)
            {
                Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========");
            }
            else if (stage == 2)
            {
                Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========");
            }
            else if (stage == 3)
            {
                Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========");
            }
            else if (stage == 4)
            {
                Console.WriteLine("  +---+\r\n      |\r\n      | \r\n \\O/  |\r\n  |   |\r\n / \\  |\r\n=========");
            }
            else {
                Console.WriteLine("err");
            }
        }
    }
}