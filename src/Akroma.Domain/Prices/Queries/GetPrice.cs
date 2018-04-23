using System.Collections.Generic;
using Akroma.Domain.Prices.Models;
using Brickweave.Cqrs;

namespace Akroma.Domain.Prices.Queries
{

    public class GetPrice : IQuery<Price>
    {
        public string Symbol { get; }

        public GetPrice(string symbol)
        {
            Symbol = symbol;
        }
        
    }
}
