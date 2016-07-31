using System.Linq;
using GuessNumber.FancyLinq;

namespace GuessNumber
{
    public class NumberComparer
    {
        public string Compare(string answer, string guessing)
        {
            var matchesCount = answer.Count((e, i) => guessing[i] == e);
            var containsCount = answer.Count(guessing.Contains);
            return string.Format("{0}A{1}B", matchesCount, containsCount - matchesCount);
        }
    }
}
