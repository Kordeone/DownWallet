using DownWallet.Entities;
using DownWallet.Entities.Enums;
using DownWallet.Utilities;
using FluentEmail.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownWallet.DataAccess.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFluentEmail _fluentEmail;
        DbSet<Wallet> _entity;
        public WalletRepository(AppDbContext dbContext, IFluentEmail fluentEmail)
        {
            _appDbContext = dbContext;
            _fluentEmail = fluentEmail;
            _entity = dbContext.Set<Wallet>();
        }

        //Adding wallet must only be possible when submiting a new account

        public async Task Add(Wallet wallet, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (wallet == null)
            {
                throw new ArgumentNullException();
            }

            await _entity.AddAsync(wallet, cancellationToken);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Wallet> Get(int walletId)
        {
            return await _entity.FindAsync(walletId);
        }

        public async Task<Wallet> Get(string walletNumber)
        {
            if (walletNumber == null)
            {
                throw new ArgumentNullException();
            }
            return await _entity.Where(x => x.WalletNumber == walletNumber).FirstOrDefaultAsync();
        }
        public async Task<List<Wallet>> GetAll()
        {
            return await (from r in _appDbContext.Wallets select r).ToListAsync();
        }

        public double GetBalance(string walletNumber)
        {
            if (walletNumber == null)
            {
                throw new ArgumentNullException();
            }

            if (IsEnabled(walletNumber))
            {
                var wallet = _entity.Where(x => x.WalletNumber == walletNumber).SingleOrDefault();
                var transaction = new Transaction(Transacts.BalanceCheck);
                wallet.LatestTransactions.Add(transaction);
                _appDbContext.SaveChanges();
                return wallet.Balance;
            }
            throw new Exception("wallet is disbaled");
        }

        public async Task Update(Wallet wallet, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (wallet == null || wallet.Id == 0)
            {
                throw new ArgumentNullException();
            }
            _entity.Update(wallet);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeStatus(string walletNumber, Status status, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (walletNumber == null)
            {
                throw new ArgumentNullException();
            }
            var walletEntity = _entity.Where(x => x.WalletNumber == walletNumber).FirstOrDefaultAsync();
            if (walletEntity.Result.Status == status)
            {
                throw new Exception("Wallet was " + $"{status.ToString()}" + " before.");
            }

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int walletId, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (walletId == 0)
            {
                throw new ArgumentNullException();
            }

            _entity.Remove(_entity.Where(x => x.Id == walletId).SingleOrDefault());

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Deposit(string walletNumber, double value, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (value == 0 || walletNumber == null)
            {
                throw new ArgumentNullException();
            }

            if (!IsEnabled(walletNumber))
            {
                throw new Exception("wallet is disbaled");
            }

            var wallet = Get(walletNumber);
            wallet.Result.Balance += value;
            var transaction = new Transaction(Transacts.Deposit);
            wallet.Result.LatestTransactions.Add(transaction);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);

            var owner = GetWalletOwnerInfo(walletNumber);

            //var emailTemplate =
            // @" < h1 > Dear  + @Model.FirstName + , </ h1 > 
            //<p>New + @Model.Action +  transaction happened with your account! </p>
            //<p>The DownWallet Team.</p>";

            //var action = Transacts.Deposit.ToString();
            //var newEmail = _fluentEmail
            //    .To(owner.Email)
            //    .Subject("New Transaction")
            //    .UsingTemplate(emailTemplate, new { owner.FirstName, action });

            //await newEmail.SendAsync();

            await EmailHelper.SendSingleEmail(owner.FirstName, owner.Email, Transacts.Deposit.ToString());


        }

        public async Task Withdraw(string walletNumber, double value, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (value == 0 || walletNumber == null)
            {
                throw new ArgumentNullException();
            }

            if (!IsEnabled(walletNumber))
            {
                throw new Exception("wallet is disbaled");
            }

            var wallet = Get(walletNumber);
            wallet.Result.Balance -= value;
            var transaction = new Transaction(Transacts.Withrawl);
            wallet.Result.LatestTransactions.Add(transaction);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);

            var owner = GetWalletOwnerInfo(walletNumber);
            await EmailHelper.SendSingleEmail(owner.FirstName, owner.Email, Transacts.Deposit.ToString());
        }

        public async Task Transfer(string sourceNumber, string destinationNumber, double value, CancellationToken cancellationToken, bool saveNow = true)
        {
            if (value == 0 || sourceNumber == null || destinationNumber == null)
            {
                throw new ArgumentNullException();
            }

            if (Get(sourceNumber).Result.Balance < value || !IsEnabled(sourceNumber) || !IsEnabled(destinationNumber))
            {
                throw new Exception("There has been an error with the wallet.");
            }

            var sourceWallet = Get(sourceNumber);
            sourceWallet.Result.Balance -= value;
            var srcTransaction = new Transaction(Transacts.Transfer);
            srcTransaction.WalletNumber = sourceNumber;
            sourceWallet.Result.LatestTransactions.Add(srcTransaction);
            var destinationWallet = Get(destinationNumber);
            destinationWallet.Result.Balance += value;
            var dstTransaction = new Transaction(Transacts.Recieve);
            dstTransaction.WalletNumber = destinationNumber;
            destinationWallet.Result.LatestTransactions.Add(dstTransaction);

            if (saveNow)
                await _appDbContext.SaveChangesAsync(cancellationToken);


            var srcWalletOwner = GetWalletOwnerInfo(sourceNumber);
            var dstWalletOwner = GetWalletOwnerInfo(destinationNumber);

            await EmailHelper.SendMultipleEmail(
                    srcWalletOwner.FirstName, srcWalletOwner.Email, Transacts.Transfer.ToString(),
                    dstWalletOwner.FirstName, dstWalletOwner.Email, Transacts.Recieve.ToString());

        }

        public bool IsEnabled(string walletNumber)
        {
            var wallet = _entity.Where(w => w.WalletNumber == walletNumber).FirstOrDefault();
            if (wallet.Status == Status.Enabled)
            {
                return true;
            }
            return false;
        }
        public WalletOwner GetWalletOwnerInfo(string walletNumber)
        {
            return _appDbContext.WalletOwners.Where(x => x.WalletNumber == walletNumber).SingleOrDefault();
        }
    }
}
