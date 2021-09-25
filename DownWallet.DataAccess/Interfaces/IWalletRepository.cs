using DownWallet.Entities;
using DownWallet.Entities.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.DataAccess.Repositories
{
    public interface IWalletRepository
    {
        Task Add(Wallet wallet, CancellationToken cancellationToken, bool saveNow = true);
        Task ChangeStatus(string walletNumber, Status status, CancellationToken cancellationToken, bool saveNow = true);
        Task Delete(int walletId, CancellationToken cancellationToken, bool saveNow = true);
        Task Deposit(string walletNumber, double value, CancellationToken cancellationToken, bool saveNow = true);
        Task<Wallet> Get(int walletId);
        Task<Wallet> Get(string walletNumber);
        Task<List<Wallet>> GetAll();
        double GetBalance(string walletNumber);
        WalletOwner GetWalletOwnerInfo(string walletNumber);
        bool IsEnabled(string walletNumber);
        Task Transfer(string sourceNumber, string destinationNumber, double value, CancellationToken cancellationToken, bool saveNow = true);
        Task Update(Wallet wallet, CancellationToken cancellationToken, bool saveNow = true);
        Task Withdraw(string walletNumber, double value, CancellationToken cancellationToken, bool saveNow = true);
    }
}