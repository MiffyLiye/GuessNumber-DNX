using System.IO;
using System.Linq;

namespace GuessNumber
{
    public class GuessNumberGame
    {
        private readonly TextReader _textReader;
        private readonly TextWriter _textWriter;
        private readonly IGuessNumberConfig _appSettings;
        private readonly IAnswerGenerator _answerGenerator;
        private readonly NumberComparer _numberComparer;

        public GuessNumberGame(TextReader textReader, TextWriter textWriter, IGuessNumberConfig config, IAnswerGenerator answerGenerator = null)
        {
            _textReader = textReader;
            _textWriter = textWriter;
            _answerGenerator = answerGenerator ?? new AnswerGenerator();
            _numberComparer = new NumberComparer();
            _appSettings = config;
        }

        public void Drive()
        {
            var answer = _answerGenerator.GenerateAnswer();
            var initialChancesCount = _appSettings.GuessChancesCount;

            _textWriter.WriteLine("Welcome!");
            for (var chances = initialChancesCount; chances > 0; chances--)
            {
                _textWriter.WriteLine();
                _textWriter.Write($"Please input your number ({chances}): ");
                var guessing = _textReader.ReadLine();
                if (HasDuplicateDigits(guessing))
                {
                    _textWriter.WriteLine("Cannot input duplicate numbers!");
                    continue;
                }
                var result = _numberComparer.Compare(answer, guessing);
                if (result == "4A0B")
                {
                    _textWriter.WriteLine("Congratulations!");
                    return;
                }
                _textWriter.WriteLine(result);
            }
            _textWriter.WriteLine("Game Over");
        }

        private static bool HasDuplicateDigits(string guessing)
        {
            return guessing.Distinct().Count() != guessing.Length;
        }
    }
}