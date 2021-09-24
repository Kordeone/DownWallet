using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DownWallet.Entities.Enums
{
    public enum Transacts
    {
        [Display(Name = " برداشت وجه")]
        Withrawl,
        [Display(Name = "واریز وجه")]
        Deposit,
        [Display(Name = "انتقال وجه")]
        Transfer, 
        [Display(Name = "دریافت وجه")]
        Recieve,
        [Display(Name = "اعلام موجودی")]
        BalanceCheck

    }
}
