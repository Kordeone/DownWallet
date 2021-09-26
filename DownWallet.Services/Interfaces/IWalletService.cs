using DownWallet.Entities.Enums;
using DownWallet.Services.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Services
{
    public interface IWalletService
    {
        //Task Add(WalletDto walletDto, CancellationToken cancellationToken);
        Task ChangeStatus(string walletnumber, Status status, CancellationToken cancellationToken);
        Task Delete(int walletId, CancellationToken cancellationToken);
        Task Delete(WalletDto walletDto, CancellationToken cancellationToken);
        Task Deposit(string walletNumber, double value, CancellationToken cancellationToken);
        Task<List<WalletDto>> GetAll();
        double GetBalance(string walletNumber);
        Task<WalletDto> GetById(int walletId);
        Task<WalletDto> GetByWalletNumber(string walletNumber);
        Task Transfer(string sourceNumber, string destinationNumber, double value, CancellationToken cancellationToken);
        Task Update(WalletDto walletDto, CancellationToken cancellationToken);
        Task Withdraw(string walletNumber, double value, CancellationToken cancellationToken);
    }
}