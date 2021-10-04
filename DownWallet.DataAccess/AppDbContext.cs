using Microsoft.EntityFrameworkCore;
using DownWallet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<WalletOwner> WalletOwners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
