using System;
using System.Threading.Tasks;
using GuessNumber;
using MiffyLiye.XConsole;
using Xunit;

namespace GuessNumberTest
{
    public class GuessNumberGameTest
    {
        private string NewLine => Environment.NewLine;
        private XTextReader TextReaderStub { get; } = new XTextReader();
        private XTextWriter TextWriterSpy { get; } = new XTextWriter();
        private FakeAnswerGenerator AnswerGeneratorStub { get; } = new FakeAnswerGenerator {Answer = "1234"};
        private FakeGuessNumberConfig ConfigStub { get; } = new FakeGuessNumberConfig {GuessChancesCount = 6};

        private GuessNumberGame Game { get; }
        public GuessNumberGameTest()
        {
            Game = new GuessNumberGame(TextReaderStub, TextWriterSpy, AnswerGeneratorStub, ConfigStub);
        }

        [Fact]
        public void should_congratulations_when_ever_4A0B()
        {
    #region Congratulations
        #region Start Game
            AnswerGeneratorStub.Answer = "5678";
            var task = Task.Run(() => Game.Drive());
        #endregion

        #region Welcome
            var lastOutputLinesCount = 0;
            Wait.Until(() => TextWriterSpy.OutputLines.Count > lastOutputLinesCount);
            Wait.Until(() => TextReaderStub.PendingRead);

            var expectedOutput =
                "Welcome!" + NewLine +
                NewLine +
                "Please input your number (6): ";
            Assert.Equal(expectedOutput, TextWriterSpy.Output);
        #endregion

        #region 1st Guess, 4A0B
            lastOutputLinesCount = TextWriterSpy.OutputLines.Count;
            TextReaderStub.SendLine("5678");
            Wait.Until(() => TextWriterSpy.OutputLines.Count > lastOutputLinesCount);
            Wait.Until(() => task.IsCompleted);

            expectedOutput += "Congratulations!" + NewLine;
            Assert.Equal(expectedOutput, TextWriterSpy.Output);
        #endregion
    #endregion
        }

        [Fact]
        public void should_game_over_when_never_4A0B()
        {
    #region Game Over
        #region Start Game
            AnswerGeneratorStub.Answer = "1234";
            ConfigStub.GuessChancesCount = 2;

            var task = Task.Run(() => Game.Drive());
        #endregion

        #region Welcome
            var lastOutputLinesCount = 0;
            Wait.Until(() => TextWriterSpy.OutputLines.Count > lastOutputLinesCount);
            Wait.Until(() => TextReaderStub.PendingRead);

            var expectedOutput =
                "Welcome!" + NewLine +
                NewLine +
                "Please input your number (2): ";
            Assert.Equal(expectedOutput, TextWriterSpy.Output);
        #endregion

        #region 1st  Guess
            lastOutputLinesCount = TextWriterSpy.OutputLines.Count;
            TextReaderStub.SendLine("1233");
            Wait.Until(() => TextWriterSpy.OutputLines.Count > lastOutputLinesCount);
            Wait.Until(() => TextReaderStub.PendingRead);

            expectedOutput +=
                "Cannot input duplicate numbers!" + NewLine +
                NewLine +
                "Please input your number (1): ";
            Assert.Equal(expectedOutput, TextWriterSpy.Output);
        #endregion

        #region 2nd Guess
            lastOutputLinesCount = TextWriterSpy.OutputLines.Count;
            TextReaderStub.SendLine("1235");
            Wait.Until(() => TextWriterSpy.OutputLines.Count > lastOutputLinesCount);
            Wait.Until(() => task.IsCompleted);

            expectedOutput +=
                "3A0B" + NewLine +
                "Game Over" + NewLine;
            Assert.Equal(expectedOutput, TextWriterSpy.Output);
        #endregion
    #endregion
        }
    }
}
