using System;

namespace Akroma.Domain.NetworkStats.Models
{
    public class Stats
    {
        public int Height { get; set; }
        public string Difficulty { get; set; }
        public string HashRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public double CirculatingSupply { get; set; }
    }
}
