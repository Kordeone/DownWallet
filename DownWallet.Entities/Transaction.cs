using DownWallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string WalletNumber { get; set; }
        public Transacts Action { get; set; }
        public DateTime Time { get; set; }
        public Transaction(Transacts action)
        {
            Action = action;
            Time = DateTime.Now;
        }
    }
}
