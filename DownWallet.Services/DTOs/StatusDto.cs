using DownWallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.DTOs
{
    public class StatusDto
    {
        public string Walletnumber { get; set; }
        public Status Status { get; set; }
    }
}
