using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;

namespace Akroma.Domain.Addressess.Services
{
    public interface IAddressRepository
    {
        Task<int> GetAddressTransactionCountAsync(string address);

        Task<int> GetAddressMinedAsync(string address);

        Task<AddressTo> GetAddressToAsync(string address);

        Task<AddressFrom> GetAddressFromAsync(string address);
        Task<IEnumerable<Address>> GetAddressesAsync();
    }


}
