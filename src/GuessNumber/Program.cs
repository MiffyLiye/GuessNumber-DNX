namespace GuessNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new GuessNumberGame();
            game.Drive();
        }
    }
}