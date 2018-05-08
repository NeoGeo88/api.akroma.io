using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;
using Akroma.Domain.Transactions.Models;
using Akroma.Domain.Transactions.Services;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL.Repositories
{
    public class SQLTransactionsRepository : ITransactionsRepository
    {
        private readonly AkromaContext _context;

        public SQLTransactionsRepository(AkromaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int limit)
        {
            var transactionDocuments = await _context
                .Transactions
                .AsNoTracking()
                .OrderByDescending(x => x.Timestamp)
                .Take(limit)
                .ToListAsync();

            return transactionDocuments.Select(t => t.ToTransaction());
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactionHistoryAsync()
        {
            return await _context
                .TransactionHistory
                .OrderByDescending(x => x.Date)
                .Take(200)
                .Select(x => x.ToTransactionHistory())
                .ToListAsync();
        }

        public async Task<Transaction> GetTransactionAsync(string hash)
        {
            var transactionDocument = await _context
                .Transactions
                .AsNoTracking()
                .AsQueryable()
                .SingleAsync(t => t.Hash == hash);

            return transactionDocument.ToTransaction();
        }

        public async Task<AddressTransactions> GetAddressTransactions(string address, string filter, int currentPage)
        {
            const int perPage = 20;

            var query = _context
                .Transactions
                .AsQueryable();

            switch (filter)
            {
                case "from":
                    query = query.Where(x => x.From == address);
                    break;
                case "to":
                    query = query.Where(x => x.To == address);
                    break;
                default:
                    query = query.Where(x => x.To == address || x.From == address);
                    break;
            }

            var totalTransactions = await query.CountAsync();
            var totalPages = (totalTransactions - 1) / perPage + 1;

            var transactions = await query
                .OrderByDescending(x => x.Timestamp)
                .Skip(20 * currentPage)
                .Take(perPage)
                .AsNoTracking()
                .Select(x => x.ToTransaction())
                .ToListAsync();

            return new AddressTransactions(transactions, totalPages, currentPage, totalTransactions);
        }
    }
}
