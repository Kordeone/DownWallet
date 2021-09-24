using DownWallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Entities
{
    public class Transaction
    {
        
        public Transacts Action { get; set; }
        public DateTime Time { get; set; }
        public Transaction(Transacts transacts)
        {
            Action = transacts;
            Time = DateTime.Now;
        }
    }
}
