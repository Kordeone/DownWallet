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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task Add(AdminDto adminDto, CancellationToken cancellationToken)
        {
            AdminValidation validator = new AdminValidation();
            ValidationResult result = validator.Validate(adminDto);
            if (result.IsValid)
            {
                await _adminService.Add(adminDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }

        #region Put Requests
        [HttpPut]
        public async Task Update(AdminDto adminDto, CancellationToken cancellationToken)
        {
            AdminValidation validator = new AdminValidation();
            ValidationResult result = validator.Validate(adminDto);
            if (result.IsValid)
            {
                await _adminService.Update(adminDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }
        [HttpPut]
        public async Task UpdatePassword(AdminDto adminDto, CancellationToken cancellationToken)
        {
            AdminValidation validator = new AdminValidation();
            ValidationResult result = validator.Validate(adminDto);
            if (result.IsValid)
            {
                await _adminService.UpdatePassword(adminDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }
        #endregion

        #region Delete Requests
        [HttpDelete]
        public async Task Delete(AdminDto adminDto, CancellationToken cancellationToken)
        {
            AdminValidation validator = new AdminValidation();
            ValidationResult result = validator.Validate(adminDto);
            if (result.IsValid)
            {
                await _adminService.Delete(adminDto, cancellationToken);
            }
            else
                throw new Exception("object didn't validate");
        }
        [HttpDelete]
        public async Task DeleteById(int adminId, CancellationToken cancellationToken)
        {
            await _adminService.Delete(adminId, cancellationToken);
        }
        #endregion

        #region Get Requests

        [HttpGet]
        public async Task<AdminDto> Get(int adminId)
        {
            return await _adminService.Get(adminId);
        }

        [HttpGet]
        public async Task<List<AdminDto>> GetAll()
        {
            return await _adminService.GetAll();
        }


        #endregion
    }
}
