using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;
using Akroma.Domain.NetworkStats.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.NetworkStats.Queries
{
    public class GetNetworkStatsHandler : IQueryHandler<GetNetworkStats, Stats>
    {
        private readonly INetworkRepository _networkRepository;
        //private static readonly HttpClient HttpClient = new HttpClient();

        public GetNetworkStatsHandler(INetworkRepository networkRepository)
        {
            _networkRepository = networkRepository;
        }


        public async Task<Stats> HandleAsync(GetNetworkStats query)
        {
            return await _networkRepository.GetNetworkAsync();


            //var json = await HttpClient.GetStringAsync(new Uri("https://stats.akroma.io/akroma"));

            //var akroma = JsonConvert.DeserializeObject<AkromaStats>(json);
            //return new Stats()
            //{
            //    Difficulty = akroma.GetDifficulty(),
            //    HashRate = akroma.GetHashRate(),
            //    Height = akroma.GetHeight()
            //};
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
            return v.ToString("F");
        }

        public string GetHashRate()
        {
            var v = avgHashrate * 0.000000001;
            return v.ToString("F");
        }
    }
    public class Miner
    {
        public string miner { get; set; }
        public bool name { get; set; }
        public int blocks { get; set; }
    }



}
