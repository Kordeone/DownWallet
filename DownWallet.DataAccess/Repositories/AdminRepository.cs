using DownWallet.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _appDbContext;
        DbSet<Admin> _entity;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entity = appDbContext.Set<Admin>();
        }

        public async Task Add(Admin admin, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (admin == null)
            {
                throw new ArgumentNullException();
            }

            await _entity.AddAsync(admin, cancellationToken);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Admin> Get(int adminId)
        {
            return await _entity.FindAsync(adminId);
        }

        public async Task<List<Admin>> GetAll()
        {
            return await (from r in _appDbContext.Admins select r).ToListAsync();
        }

        public async Task Update(Admin admin, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (admin == null || admin.Id == 0)
            {
                throw new ArgumentNullException();
            }
            _entity.Update(admin);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int adminId, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (adminId == 0)
            {
                throw new ArgumentNullException();
            }

            _entity.Remove(_entity.Where(x => x.Id == adminId).SingleOrDefault());

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
