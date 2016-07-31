using GuessNumber;

namespace GuessNumberTest
{
    public class FakeAnswerGenerator : IAnswerGenerator
    {
        public string Answer { get; set; }

        public string GenerateAnswer()
        {
            return Answer;
        }
    }
}