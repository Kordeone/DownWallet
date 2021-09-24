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
    public class WalletOwnerRepository : IWalletOwnerRepository
    {
        private readonly AppDbContext _appDbContext;
        DbSet<WalletOwner> _entity;
        public WalletOwnerRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
            _entity = dbContext.Set<WalletOwner>();
        }

        public async Task Add(WalletOwner walletOwner, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (walletOwner == null)
            {
                throw new ArgumentNullException();
            }

            await _entity.AddAsync(walletOwner, cancellationToken);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<WalletOwner> Get(int userId)
        {
            return await _entity.FindAsync(userId);
        }

        public async Task<List<WalletOwner>> GetAll()
        {
            return await (from r in _appDbContext.WalletOwners select r).ToListAsync();
        }

        public async Task Update(WalletOwner walletOwner, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (walletOwner == null || walletOwner.Id == 0)
            {
                throw new ArgumentNullException();
            }
            _entity.Update(walletOwner);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int walletOwnerId, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (walletOwnerId == 0)
            {
                throw new ArgumentNullException();
            }

            _entity.Remove(_entity.Where(x => x.Id == walletOwnerId).SingleOrDefault());

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
