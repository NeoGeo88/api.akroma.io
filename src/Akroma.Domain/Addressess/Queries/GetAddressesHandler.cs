using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;
using Akroma.Domain.Addressess.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.Addressess.Queries
{
    public class GetAddressesHandler : IQueryHandler<GetAddresses, IEnumerable<Address>>
    {
        private readonly IAddressRepository _repository;

        public GetAddressesHandler(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Address>> HandleAsync(GetAddresses query)
        {
            return await _repository.GetAddressesAsync();
        }
    }
}