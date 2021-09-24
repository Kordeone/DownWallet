using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DownWallet.Entities.Enums
{
    public enum Status
    {
        [Display(Name = "فعال")]
        Enabled,
        [Display(Name = "غیرفعال")]
        Disabled
    }
}
