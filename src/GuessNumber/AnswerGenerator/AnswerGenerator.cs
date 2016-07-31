using System;
using System.Collections.Generic;

namespace GuessNumber
{
    public class AnswerGenerator : IAnswerGenerator
    {
        private readonly Random _random;

        public AnswerGenerator()
        {
            _random = new Random();
        }

        public string GenerateAnswer()
        {
            var digits = new List<int>();
            while (digits.Count < 4)
            {
                var digit = _random.Next(0, 10);
                if (!digits.Contains(digit))
                {
                    digits.Add(digit);
                }
            }
            return string.Join("", digits);
        }
    }
}