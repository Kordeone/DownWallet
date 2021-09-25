using DownWallet.Services.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.Validations
{
    public class AdminValidation : AbstractValidator<AdminDto>
    {
        public AdminValidation()
        {
            RuleFor(adminDto => adminDto.UserName).NotNull();
            RuleFor(adminDto => adminDto.UserName).MaximumLength(20);
            RuleFor(adminDto => adminDto.PasswordHash).NotNull();
            RuleFor(adminDto => adminDto.FirstName).NotNull();
            RuleFor(adminDto => adminDto.FirstName).MaximumLength(20);
            RuleFor(adminDto => adminDto.LastName).NotNull();
            RuleFor(adminDto => adminDto.LastName).MaximumLength(20);
        }
    }
}
