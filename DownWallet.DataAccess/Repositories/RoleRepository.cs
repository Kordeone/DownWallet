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
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _appDbContext;
        DbSet<Role> _entity;

        public RoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entity = appDbContext.Set<Role>();
        }

        public async Task Add(Role role, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (role == null)
            {
                throw new ArgumentNullException();
            }

            await _entity.AddAsync(role, cancellationToken);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Role> Get(int roleId)
        {
            return await _entity.FindAsync(roleId);
        }

        public async Task<List<Role>> GetAll()
        {
            return await (from r in _appDbContext.Roles select r).ToListAsync();
        }
        public async Task Update(Role role, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (role == null || role.Id == 0)
            {
                throw new ArgumentNullException();
            }
            _entity.Update(role);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task Delete(int roleId, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (roleId == 0)
            {
                throw new ArgumentNullException();
            }

            _entity.Remove(_entity.Where(x => x.Id == roleId).SingleOrDefault());

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
