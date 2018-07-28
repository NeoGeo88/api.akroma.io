using System;
using Akroma.Domain.NetworkStats.Models;

namespace Akroma.Persistence.SQL.Model
{
    public class NetworkEntity : BaseEntity
    {
        public int Height { get; set; }
        public string Difficulty { get; set; }
        public string HashRate { get; set; }
        public DateTime CreatedAt { get; set; }

        public Stats ToViewModel()
        {
            var supply = GetSupply();

            return new Stats
            {
                Height = Height,
                Difficulty = Difficulty,
                HashRate = HashRate,
                CirculatingSupply = supply, //close approx, does not take into account uncles.
                CreatedAt = CreatedAt,
            };
        }

        private double GetSupply()
        {
            double supply = 12000000;
            var height = Height;
            var bEpoc = height - 1200000;
            var cEpoc = height - 2200000;
            var dEpoc = height - 3200000;

            if (bEpoc > 0)
            {
                var bAmount = bEpoc * 6;
                supply = supply + bAmount;
            }

            if (cEpoc > 0)
            {
                var cAmount = cEpoc * 5.5;
                supply = supply + cAmount;
            }

            if (dEpoc > 0)
            {
                var dAmount = dEpoc * 5;
                supply = supply + dAmount;
            }

            return supply;
        }
    }
}
