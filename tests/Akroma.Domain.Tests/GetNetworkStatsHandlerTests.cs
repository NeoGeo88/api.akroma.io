using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;
using Akroma.Domain.NetworkStats.Queries;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Akroma.Domain.Tests
{
    public class GetNetworkStatsHandlerTests
    {
        public GetNetworkStatsHandlerTests(ITestOutputHelper console)
        {
            _console = console;
        }

        private readonly ITestOutputHelper _console;

        [Fact]
        public void FactMethodName()
        {
            var sut = new GetNetworkStats();
        }

        [Fact]
        public async Task ParsingTests()
        {
            var json = await File.ReadAllTextAsync("network.json");
            //_console.WriteLine(json);
            var stats = JsonConvert.DeserializeObject<AkromaStats>(json);
            //_console.WriteLine(stats.ToString());

            stats.GetHeight().Should().Be(333586);
            stats.GetDifficulty().Should().Be("1.79 TH");
            stats.GetHashRate().Should().Be("135 GH/s");
        }
    }
}
