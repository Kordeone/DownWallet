using AutoMapper;
using DownWallet.DataAccess.Repositories;
using DownWallet.Entities;
using DownWallet.Services.DTOs;
using DownWallet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Services
{
    public class WalletOwnerService : IWalletOwnerService
    {
        private readonly IWalletOwnerRepository _walletOwnerRepository;
        private readonly IMapper _mapper;

        public WalletOwnerService(IWalletOwnerRepository walletOwnerRepository, IMapper mapper)
        {
            _walletOwnerRepository = walletOwnerRepository;
            _mapper = mapper;
        }

        public async Task Add(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            walletOwnerDto.Password = PasswordHelper.Hash(walletOwnerDto.Password);
            var walletOwnerEntity = _mapper.Map<WalletOwner>(walletOwnerDto);
            await _walletOwnerRepository.Add(walletOwnerEntity, cancellationToken);
        }

        public async Task<WalletOwnerDto> Get(int walletOwnerId)
        {
            return _mapper.Map<WalletOwnerDto>(await _walletOwnerRepository.Get(walletOwnerId));
        }

        public async Task<List<WalletOwnerDto>> GetAll()
        {
            return _mapper.Map<List<WalletOwnerDto>>(await _walletOwnerRepository.GetAll());
        }
        public async Task Update(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            var walletOwnerEntity = _mapper.Map<WalletOwner>(walletOwnerDto);
            await _walletOwnerRepository.Update(walletOwnerEntity, cancellationToken);
        }
        public async Task UpdatePassword(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            walletOwnerDto.Password = PasswordHelper.Hash(walletOwnerDto.Password);
            await Update(walletOwnerDto, cancellationToken);
        }
        public async Task Delete(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            await Delete(walletOwnerDto.Id, cancellationToken);
        }

        public async Task Delete(int walletOwnerId, CancellationToken cancellationToken)
        {
            await _walletOwnerRepository.Delete(walletOwnerId, cancellationToken);
        }
    }
}
