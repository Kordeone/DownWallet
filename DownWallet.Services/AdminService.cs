using AutoMapper;
using DownWallet.DataAccess.Repositories;
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
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        public async Task Add(AdminDto adminDto, CancellationToken cancellationToken)
        {
            adminDto.PasswordHash = PasswordHelper.Hash(adminDto.PasswordHash);
            var adminEntity = _mapper.Map<Entities.Admin>(adminDto);
            await _adminRepository.Add(adminEntity, cancellationToken);
        }
        public async Task<AdminDto> Get(int adminId)
        {
            return _mapper.Map<AdminDto>(await _adminRepository.Get(adminId));

        }
        public async Task<List<AdminDto>> GetAll()
        {
            return _mapper.Map<List<AdminDto>>(await _adminRepository.GetAll());
        }
        public async Task Update(AdminDto adminDto, CancellationToken cancellationToken)
        {
            var adminEntity = _mapper.Map<Entities.Admin>(adminDto);
            await _adminRepository.Update(adminEntity, cancellationToken);
        }
        public async Task UpdatePassword(AdminDto adminDto, CancellationToken cancellationToken)
        {
            adminDto.PasswordHash = PasswordHelper.Hash(adminDto.PasswordHash);
            await Update(adminDto, cancellationToken);
        }
        public async Task Delete(AdminDto adminDto, CancellationToken cancellationToken)
        {
            var adminEntity = _mapper.Map<Entities.Admin>(adminDto);
            await _adminRepository.Delete(adminEntity.Id, cancellationToken);
        }
        public async Task Delete(int adminId, CancellationToken cancellationToken)
        {
            await _adminRepository.Delete(adminId, cancellationToken);
        }
    }
}
