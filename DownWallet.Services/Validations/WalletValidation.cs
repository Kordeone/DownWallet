using DownWallet.Services.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.Validations
{
    public class WalletValidation : AbstractValidator<WalletDto>
    {
        public WalletValidation()
        {
            RuleFor(walletDto => walletDto.WalletNumber).NotNull();
            RuleFor(walletDto => walletDto.Status).NotNull();
            RuleFor(walletDto => walletDto.OwnerId).NotNull();
            RuleFor(walletDto => walletDto.Balance).NotNull();
        }
    }
}
