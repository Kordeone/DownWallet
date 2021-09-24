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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController( IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpPost]
        public async Task Add(RoleDto roleDto, CancellationToken cancellationToken)
        {
            RoleValidation validator = new RoleValidation();
            ValidationResult result = validator.Validate(roleDto);
            if (result.IsValid)
            {
                await _roleService.Add(roleDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        [HttpPut]
        public async Task Update(RoleDto roleDto, CancellationToken cancellationToken)
        {
            RoleValidation validator = new RoleValidation();
            ValidationResult result = validator.Validate(roleDto);
            if (result.IsValid)
            {
                await _roleService.Update(roleDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        [HttpDelete]
        public async Task Delete(RoleDto roleDto, CancellationToken cancellationToken)
        {
            RoleValidation validator = new RoleValidation();
            ValidationResult result = validator.Validate(roleDto);
            if (result.IsValid)
            {
                await _roleService.Delete(roleDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        [HttpDelete]
        public async Task DeleteById(int roleId, CancellationToken cancellationToken)
        {
            await _roleService.Delete(roleId, cancellationToken);
        }


        #region Get Requests

        [HttpGet]
        public async Task<RoleDto> Get(int roleId)
        {
            return await _roleService.Get(roleId);
        }

        [HttpGet]
        public async Task<List<RoleDto>> GetAll()
        {
            return await _roleService.GetAll();
        }


        #endregion
    }
}
