using System.Collections.Generic;
using Akroma.Domain.Addressess.Model;
using Brickweave.Cqrs;

namespace Akroma.Domain.Addressess.Queries
{
    public class GetAddresses : IQuery<IEnumerable<Address>>
    {
    }
}
