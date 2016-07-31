using System;
using System.IO;
using System.Linq;

namespace GuessNumber
{
    public class GuessNumberGame
    {
        private readonly TextReader _textReader;
        private readonly TextWriter _textWriter;
        private readonly IAnswerGenerator _answerGenerator;
        private readonly NumberComparer _numberComparer;
        private readonly IGuessNumberConfig _appSettings;

        public GuessNumberGame(TextReader textReader = null, TextWriter textWriter = null, IAnswerGenerator answerGenerator = null, IGuessNumberConfig config = null)
        {
            _textReader = textReader ?? Console.In;
            _textWriter = textWriter ?? Console.Out;
            _answerGenerator = answerGenerator ?? new AnswerGenerator();
            _numberComparer = new NumberComparer();
            _appSettings = config ?? new GuessNumberConfig();
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