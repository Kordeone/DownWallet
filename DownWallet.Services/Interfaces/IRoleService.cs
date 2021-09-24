using DownWallet.Services.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Services
{
    public interface IRoleService
    {
        Task Add(RoleDto roleDto, CancellationToken cancellationToken);
        Task Delete(int roleId, CancellationToken cancellationToken);
        Task Delete(RoleDto roleDto, CancellationToken cancellationToken);
        Task<RoleDto> Get(int roleId);
        Task<List<RoleDto>> GetAll();
        Task Update(RoleDto roleDto, CancellationToken cancellationToken);
    }
}