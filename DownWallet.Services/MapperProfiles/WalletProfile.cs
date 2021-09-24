using AutoMapper;
using DownWallet.Entities;
using DownWallet.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.MapperProfiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<Wallet, WalletDto>().ReverseMap();
        }
    }
}
