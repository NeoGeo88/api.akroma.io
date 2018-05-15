using Akroma.Domain.Addressess.Model;
using Brickweave.Cqrs;

namespace Akroma.Domain.Addressess.Queries
{
    public class GetAddress : IQuery<Address>
    {
        public GetAddress(string address)
        {
            Address = address;
        }
        public string Address { get; }
    }
}
