namespace Hangman_Lite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HangmanGame();
        }
        static public void HangmanGame()
        {
            Random randGen = new Random();
            Console.WriteLine("Welcome to Hangman Lite");
            List<string> hangmanWords = new List<string>() { "COMPUTER" };
            string word = hangmanWords[randGen.Next(0, hangmanWords.Count)];
            string displayWord = "";
            int wrongGuesses = 0;
            string guessedLetters = "";
            foreach (char i in word) displayWord += "_";
            while (true)
            {
                string curGuess = "";
                Thread.Sleep(2000);
                Console.Clear();
                if(displayWord == word)
                {
                    Console.WriteLine($"You Won! The word was {word}, you guessed {wrongGuesses}/3 letters wrong.");
                    break;
                }
                Console.WriteLine($"Guessed letters: {guessedLetters}");
                MakeHangman(wrongGuesses);
                if (wrongGuesses == 3)
                {
                    Thread.Sleep(500);
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
                    if (curGuess.Length != 1 || displayWord.Contains(curGuess) || guessedLetters.Contains(curGuess) || !"ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(curGuess)) Console.WriteLine("Invalid guess.");
                    else break;
                }
                if (word.Contains(curGuess))
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
                    guessedLetters += curGuess;
                    Console.WriteLine("That letter is not in the word.");
                    wrongGuesses++;
                }
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