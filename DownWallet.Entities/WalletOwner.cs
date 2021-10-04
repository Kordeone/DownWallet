using DownWallet.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Entities
{
    public class WalletOwner : User
    {
        public WalletOwner()
        {
            Status = Status.Enabled;
        }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string NationalId { get; set; }
        [Required]
        public string WalletNumber { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
