using DownWallet.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        Task Add(Role role, CancellationToken cancellationToken, bool saveNow = true);
        Task Delete(int roleId, CancellationToken cancellationToken, bool saveNow = true);
        Task<Role> Get(int roleId);
        Task<List<Role>> GetAll();
        Task Update(Role role, CancellationToken cancellationToken, bool saveNow = true);
    }
}