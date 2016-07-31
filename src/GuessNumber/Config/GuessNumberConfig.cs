using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.IO;
using System;

namespace GuessNumber
{
    public class GuessNumberConfig : IGuessNumberConfig
    {
        private static readonly Lazy<IConfigurationRoot> AppSettings = new Lazy<IConfigurationRoot>(() =>
        {
            var basePath = Path.GetDirectoryName(typeof(GuessNumberConfig).GetTypeInfo().Assembly.Location);
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        });

        private static readonly Lazy<int> _initialChancesCount = new Lazy<int>(() => int.Parse(AppSettings.Value["InitialChancesCount"]));

        public int GuessChancesCount => _initialChancesCount.Value;
    }
}