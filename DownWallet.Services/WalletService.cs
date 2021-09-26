using AutoMapper;
using DownWallet.DataAccess.Repositories;
using DownWallet.Entities;
using DownWallet.Entities.Enums;
using DownWallet.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public WalletService(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        //public async Task Add(WalletDto walletDto, CancellationToken cancellationToken)
        //{
        //    var walletEntity = _mapper.Map<Wallet>(walletDto);
        //    await _walletRepository.Add(walletEntity, cancellationToken);
        //}
        public async Task<WalletDto> GetById(int walletId)
        {
            return _mapper.Map<WalletDto>(await _walletRepository.Get(walletId));
        }
        public async Task<WalletDto> GetByWalletNumber(string walletNumber)
        {
            return _mapper.Map<WalletDto>(await _walletRepository.Get(walletNumber));
        }

        public async Task<List<WalletDto>> GetAll()
        {
            return _mapper.Map<List<WalletDto>>(await _walletRepository.GetAll());
        }

        public async Task ChangeStatus(string walletnumber, Status status, CancellationToken cancellationToken)
        {
            await _walletRepository.ChangeStatus(walletnumber, status, cancellationToken);
        }

        public async Task Update(WalletDto walletDto, CancellationToken cancellationToken)
        {
            var walletEntity = _mapper.Map<Wallet>(walletDto);
            await _walletRepository.Update(walletEntity, cancellationToken);
        }
        public async Task Delete(WalletDto walletDto, CancellationToken cancellationToken)
        {
            await Delete(walletDto.Id, cancellationToken);
        }
        public async Task Delete(int walletId, CancellationToken cancellationToken)
        {
            await _walletRepository.Delete(walletId, cancellationToken);
        }

        public double GetBalance(string walletNumber)
        {
            return _walletRepository.GetBalance(walletNumber);
        }
        public async Task Transfer(string sourceNumber, string destinationNumber, double value, CancellationToken cancellationToken)
        {
            await _walletRepository.Transfer(sourceNumber, destinationNumber, value, cancellationToken);
        }
        public async Task Withdraw(string walletNumber, double value, CancellationToken cancellationToken)
        {
            await _walletRepository.Withdraw(walletNumber, value, cancellationToken);
        }
        public async Task Deposit(string walletNumber, double value, CancellationToken cancellationToken)
        {
            await _walletRepository.Deposit(walletNumber, value, cancellationToken);
        }

    }
}
