using DownWallet.Services.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Services
{
    public interface IWalletOwnerService
    {
        Task Add(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken);
        Task Delete(int walletOwnerId, CancellationToken cancellationToken);
        Task Delete(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken);
        Task<WalletOwnerDto> Get(int walletOwnerId);
        Task<List<WalletOwnerDto>> GetAll();
        Task Update(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken);
        Task UpdatePassword(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken);
    }
}