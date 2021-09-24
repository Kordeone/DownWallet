using DownWallet.Services;
using DownWallet.Services.DTOs;
using DownWallet.Services.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletOwnerController : ControllerBase
    {
        private readonly IWalletOwnerService _walletOwnerService;
        private readonly IWalletService _walletService;
        public WalletOwnerController(IWalletOwnerService walletOwnerService, IWalletService walletService)
        {
            _walletOwnerService = walletOwnerService;
            _walletService = walletService;
        }

        [HttpPost]
        public async Task Add(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            WalletOwnerValidation validator = new WalletOwnerValidation();
            ValidationResult result = validator.Validate(walletOwnerDto);
            if (result.IsValid)
            {
                walletOwnerDto.WalletNumber = DateTime.UtcNow.ToString("yyyyMMddHHmmssff");
                var wallet = new WalletDto(walletOwnerDto.Id, walletOwnerDto.WalletNumber);
                await _walletService.Add(wallet, cancellationToken);
                await _walletOwnerService.Add(walletOwnerDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }


        #region Put Requests
        [HttpPut]
        public async Task Update(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            WalletOwnerValidation validator = new WalletOwnerValidation();
            ValidationResult result = validator.Validate(walletOwnerDto);
            if (result.IsValid)
            {
                await _walletOwnerService.Update(walletOwnerDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }
        public async Task UpdatePassword(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            WalletOwnerValidation validator = new WalletOwnerValidation();
            ValidationResult result = validator.Validate(walletOwnerDto);
            if (result.IsValid)
            {
                await _walletOwnerService.UpdatePassword(walletOwnerDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }
        #endregion

        #region Delete Requests

        [HttpDelete]
        public async Task Delete(WalletOwnerDto walletOwnerDto, CancellationToken cancellationToken)
        {
            WalletOwnerValidation validator = new WalletOwnerValidation();
            ValidationResult result = validator.Validate(walletOwnerDto);
            if (result.IsValid)
            {
                await _walletOwnerService.Delete(walletOwnerDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        [HttpDelete]
        public async Task DeleteById(int walletOwnerId, CancellationToken cancellationToken)
        {
            await _walletOwnerService.Delete(walletOwnerId, cancellationToken);

        }

        #endregion

        #region Get Requests

        [HttpGet]
        public async Task<WalletOwnerDto> Get(int walletOwnerId)
        {
            return await _walletOwnerService.Get(walletOwnerId);
        }

        [HttpGet]
        public async Task<List<WalletOwnerDto>> GetAll()
        {
            return await _walletOwnerService.GetAll();
        }


        #endregion
    }
}
