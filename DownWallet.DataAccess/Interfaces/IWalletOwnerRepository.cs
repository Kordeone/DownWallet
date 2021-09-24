using DownWallet.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.DataAccess.Repositories
{
    public interface IWalletOwnerRepository
    {
        Task Add(WalletOwner walletOwner, CancellationToken cancellationToken, bool saveNow = true);
        Task Delete(int walletOwnerId, CancellationToken cancellationToken, bool saveNow = true);
        Task<WalletOwner> Get(int userId);
        Task<List<WalletOwner>> GetAll();
        Task Update(WalletOwner walletOwner, CancellationToken cancellationToken, bool saveNow = true);
    }
}