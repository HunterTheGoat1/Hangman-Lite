namespace Hangman_Lite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MakeHangman(0);
            MakeHangman(1);
            MakeHangman(0);
            MakeHangman(0);
            MakeHangman(0);
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