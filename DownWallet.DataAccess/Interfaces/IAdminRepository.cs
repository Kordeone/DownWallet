using DownWallet.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.DataAccess.Repositories
{
    public interface IAdminRepository
    {
        Task Add(Admin admin, CancellationToken cancellationToken, bool saveNow = true);
        Task Delete(int adminId, CancellationToken cancellationToken, bool saveNow = true);
        Task<Admin> Get(int adminId);
        Task<List<Admin>> GetAll();
        Task Update(Admin admin, CancellationToken cancellationToken, bool saveNow = true);
    }
}