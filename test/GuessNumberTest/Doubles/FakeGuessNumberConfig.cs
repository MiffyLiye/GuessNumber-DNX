using GuessNumber;

namespace GuessNumberTest
{
    public class FakeGuessNumberConfig : IGuessNumberConfig
    {
        public int GuessChancesCount { get; set; }
    }
}
