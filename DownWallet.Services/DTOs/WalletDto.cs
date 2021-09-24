using DownWallet.Entities;
using DownWallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.DTOs
{
    public class WalletDto
    {
        public WalletDto(int ownerId, string walletNumber)
        {
            OwnerId = ownerId;
            WalletNumber = walletNumber;
            Balance = 30000;
        }
        public int Id { get; set; }
        public string WalletNumber { get; set; }
        public Status Status { get; set; }
        public List<Transaction> LatestTransactions { get; set; }
        public int OwnerId { get; set; }
        public double Balance { get; set; }
    }
}
