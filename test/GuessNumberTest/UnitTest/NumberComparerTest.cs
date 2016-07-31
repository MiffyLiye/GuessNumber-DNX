using GuessNumber;
using Xunit;

namespace GuessNumberTest
{
    public class NumberComparerTest
    {
        [Theory]
        [InlineData("1234", "5678", "0A0B")]
        [InlineData("1234", "1678", "1A0B")]
        [InlineData("1234", "1278", "2A0B")]
        [InlineData("1234", "5634", "2A0B")]
        [InlineData("1234", "5234", "3A0B")]
        [InlineData("1234", "1234", "4A0B")]
        [InlineData("1234", "5612", "0A2B")]
        [InlineData("1234", "3478", "0A2B")]
        [InlineData("1234", "3412", "0A4B")]
        public void should_return_compare_result_given_answer_and_guessing(string answer, string guessing, string expected)
        {
            var comparer = new NumberComparer();

            var result = comparer.Compare(answer, guessing);

            Assert.Equal(expected, result);
        }
    }

}