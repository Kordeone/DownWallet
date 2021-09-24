using AutoMapper;
using DownWallet.DataAccess.Repositories;
using DownWallet.Entities;
using DownWallet.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task Add(RoleDto roleDto, CancellationToken cancellationToken)
        {
            var roleEntity = _mapper.Map<Role>(roleDto);
            await _roleRepository.Add(roleEntity, cancellationToken);
        }
        public async Task<RoleDto> Get(int roleId)
        {
            return _mapper.Map<RoleDto>(await _roleRepository.Get(roleId));
        }
        public async Task<List<RoleDto>> GetAll()
        {
            return _mapper.Map<List<RoleDto>>(await _roleRepository.GetAll());
        }

        public async Task Update(RoleDto roleDto, CancellationToken cancellationToken)
        {
            var roleEntity = _mapper.Map<Role>(roleDto);
            await _roleRepository.Update(roleEntity, cancellationToken);
        }

        public async Task Delete(RoleDto roleDto, CancellationToken cancellationToken)
        {
            await Delete(roleDto.Id, cancellationToken);
        }
        public async Task Delete(int roleId, CancellationToken cancellationToken)
        {
            await _roleRepository.Delete(roleId, cancellationToken);
        }
    }
}
