using DownWallet.Services.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.Validations
{
    public class StatusValidation : AbstractValidator<StatusDto>
    {
        public StatusValidation()
        {
            RuleFor(statusDto => statusDto.Status).NotNull();
            RuleFor(statusDto => statusDto.Walletnumber).NotNull();
        }
    }
}
