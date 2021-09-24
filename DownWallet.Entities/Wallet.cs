using DownWallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Entities
{
    public class Wallet
    {
        public Wallet()
        {
            Status = Status.Enabled;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string WalletNumber { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public List<Transaction> LatestTransactions { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public double Balance { get; set; }
    }
}
