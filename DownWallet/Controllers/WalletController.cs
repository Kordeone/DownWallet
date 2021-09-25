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
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        #region Post Requests

        [HttpPost("[action]")]
        public async Task Add(WalletDto walletDto, CancellationToken cancellationToken)
        {
            WalletValidation validator = new WalletValidation();
            ValidationResult result = validator.Validate(walletDto);
            if (result.IsValid)
            {
                await _walletService.Add(walletDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        [HttpPost("[action]")]
        public async Task ChangeStatus(StatusDto statusDto, CancellationToken cancellationToken)
        {
            StatusValidation validator = new StatusValidation();
            ValidationResult result = validator.Validate(statusDto);
            if (result.IsValid)
            {
                await _walletService.ChangeStatus(statusDto.Walletnumber, statusDto.Status, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        [HttpPost("[action]")]
        public async Task Deposit(string walletNumber, double value, CancellationToken cancellationToken)
        {
            await _walletService.Deposit(walletNumber, value, cancellationToken);
        }

        [HttpPost]
        public async Task Withdraw(string walletNumber, double value, CancellationToken cancellationToken)
        {
            await _walletService.Withdraw(walletNumber, value, cancellationToken);
        }

        [HttpPost("[action]")]
        public async Task Transfer(string srcWalletNumber, string dstWalletNumber, double value, CancellationToken cancellationToken)
        {
                await _walletService.Transfer(srcWalletNumber, dstWalletNumber, value, cancellationToken);
        }

        #endregion

        #region Put Requests

        [HttpPut("[action]")]
        public async Task Update(WalletDto walletDto, CancellationToken cancellationToken)
        {
            WalletValidation validator = new WalletValidation();
            ValidationResult result = validator.Validate(walletDto);
            if (result.IsValid)
            {
                await _walletService.Update(walletDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        #endregion

        #region Delete Requests

        [HttpDelete("[action]")]
        public async Task Delete(WalletDto walletDto, CancellationToken cancellationToken)
        {
            WalletValidation validator = new WalletValidation();
            ValidationResult result = validator.Validate(walletDto);
            if (result.IsValid)
            {
                await _walletService.Delete(walletDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }
        [HttpDelete("[action]")]
        public async Task DeleteById(int adminId, CancellationToken cancellationToken)
        {
            await _walletService.Delete(adminId, cancellationToken);
        }

        #endregion

        #region Get Requests

        [HttpGet("[action]")]
        public async Task<WalletDto> GetById(int walletId)
        {
            return await _walletService.GetById(walletId);
        }

        [HttpGet("[action]")]
        public async Task<WalletDto> GetByWalletNumber(string walletNumber)
        {
            return await _walletService.GetByWalletNumber(walletNumber);
        }

        [HttpGet("[action]")]
        public async Task<List<WalletDto>> GetAll()
        {
            return await _walletService.GetAll();
        }

        [HttpGet("[action]")]
        public double GetBalance(string walletNumber)
        {
            return _walletService.GetBalance(walletNumber);
        }

        #endregion
    }
}
