using System;
using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;
using Akroma.Domain.Addressess.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.Addressess.Queries
{
    public class  GetAddressHandler: IQueryHandler<GetAddress, Address>
    {
        private readonly IAddressRepository _repository;

        public GetAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<Address> HandleAsync(GetAddress query)
        {
            var web3 = new Web3.Web3("https://remote.akroma.io");
            var balance = 0m;
            try
            {
                var block = await web3.Eth.GetBalance(query.Address);
                balance = block.Result;
            }
            catch
            {
                // ignored
            }


            var transactionCount = await _repository.GetAddressTransactionCountAsync(query.Address);
            var minedCount = await _repository.GetAddressMinedAsync(query.Address);
            var addressTo = await _repository.GetAddressToAsync(query.Address);
            var addressFrom = await _repository.GetAddressFromAsync(query.Address);

            return new Address(query.Address, balance, minedCount, transactionCount, addressFrom.Count, addressFrom.Value, addressTo.Count, addressTo.Value);
        }
    }
}
