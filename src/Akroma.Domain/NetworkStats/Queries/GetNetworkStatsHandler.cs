using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;
using Brickweave.Cqrs;
using Newtonsoft.Json;

namespace Akroma.Domain.NetworkStats.Queries
{
    public class GetNetworkStatsHandler : IQueryHandler<GetNetworkStats, Stats>
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        public async Task<Stats> HandleAsync(GetNetworkStats query)
        {
            var json = await HttpClient.GetStringAsync(new Uri("https://stats.akroma.io/akroma"));
            
            var akroma = JsonConvert.DeserializeObject<AkromaStats>(json);
            return new Stats()
            {
                Difficulty = akroma.GetDifficulty(),
                HashRate = akroma.GetHashRate(),
                Height = akroma.GetHeight()
            };
        }
    }
    public class AkromaStats
    {
        public IList<int> height { get; set; } = new List<int>();
        public IList<float> blocktime { get; set; } = new List<float>();
        public float avgBlocktime { get; set; }
        public IList<string> difficulty { get; set; } = new List<string>();
        public Miner[] miners { get; set; }
        public float avgHashrate { get; set; }

        public int GetHeight() => height.Last();
        public string GetDifficulty()
        {
            var last = difficulty.Last();
            var th = ulong.Parse(last);
            var v = th * 0.000000000001;
            var r = Math.Round((decimal)v, 2, MidpointRounding.AwayFromZero);
            return $"{r} TH";
        }

        public string GetHashRate()
        {
            var v = avgHashrate * 0.000000001;
            var r = Math.Round((decimal)v, 0, MidpointRounding.AwayFromZero);
            return r > 1000 ? $"{r} TH/s" : $"{r} GH/s";
        }
    }
    public class Miner
    {
        public string miner { get; set; }
        public bool name { get; set; }
        public int blocks { get; set; }
    }



}
