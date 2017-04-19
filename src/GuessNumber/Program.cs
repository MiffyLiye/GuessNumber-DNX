using System;

namespace GuessNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new GuessNumberGame(Console.In, Console.Out, new GuessNumberConfig());
            game.Drive();
        }
    }
}