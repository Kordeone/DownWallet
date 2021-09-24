using DownWallet.Services.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.Validations
{
    public class RoleValidation : AbstractValidator<RoleDto>
    {
        public RoleValidation()
        {
            RuleFor(roleDto => roleDto.Name).NotNull();
            RuleFor(roleDto => roleDto.Description).NotNull();
        }
    }
}
