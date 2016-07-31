using System.Linq;
using GuessNumber;
using Xunit;

namespace GuessNumberTest
{
    public class AnswerGeneratorTest
    {
        [Fact]
        public void should_generate_digits()
        {
            var answerGenerator = new AnswerGenerator();

            var answer = answerGenerator.GenerateAnswer();

            Assert.True(answer.All(char.IsDigit));
        }

        [Fact]
        public void should_answer_of_length_4()
        {
            var answerGenerator = new AnswerGenerator();

            var answer = answerGenerator.GenerateAnswer();

            Assert.Equal(4, answer.Length);
        }

        [Fact]
        public void should_generator_distince_digits()
        {
            var answerGenerator = new AnswerGenerator();

            var answer = answerGenerator.GenerateAnswer();

            Assert.Equal(answer.Count(), answer.Distinct().Count());
        }
    }
}