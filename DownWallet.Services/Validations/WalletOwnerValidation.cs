using DownWallet.Services.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.Validations
{
    public class WalletOwnerValidation : AbstractValidator<WalletOwnerDto>
    {
        public WalletOwnerValidation()
        {
            RuleFor(walletOwnerDto => walletOwnerDto.UserName).NotNull();
            RuleFor(walletOwnerDto => walletOwnerDto.UserName).MaximumLength(20);

            RuleFor(walletOwnerDto => walletOwnerDto.Password).NotNull();
            RuleFor(walletOwnerDto => walletOwnerDto.Password).MaximumLength(200);

            RuleFor(walletOwnerDto => walletOwnerDto.FirstName).NotNull();
            RuleFor(walletOwnerDto => walletOwnerDto.FirstName).MaximumLength(20);

            RuleFor(walletOwnerDto => walletOwnerDto.LastName).NotNull();
            RuleFor(walletOwnerDto => walletOwnerDto.LastName).MaximumLength(20);

            RuleFor(walletOwnerDto => walletOwnerDto.Email).NotNull();
            RuleFor(walletOwnerDto => walletOwnerDto.NationalId).NotNull();

        }
    }
}
