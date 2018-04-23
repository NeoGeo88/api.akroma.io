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
            return new Stats
            {
                Height = Height,
                Difficulty = Difficulty,
                HashRate = HashRate,
                CreatedAt = CreatedAt,
            };
        }
    }
}
