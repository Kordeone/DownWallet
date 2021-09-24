using DownWallet.Services.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.Services
{
    public interface IAdminService
    {
        Task Add(AdminDto adminDto, CancellationToken cancellationToken);
        Task Delete(AdminDto adminDto, CancellationToken cancellationToken);
        Task Delete(int adminId, CancellationToken cancellationToken);
        Task<AdminDto> Get(int adminId);
        Task<List<AdminDto>> GetAll();
        Task Update(AdminDto adminDto, CancellationToken cancellationToken);
        Task UpdatePassword(AdminDto adminDto, CancellationToken cancellationToken);
    }
}