using DownWallet.Entities;
using DownWallet.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Services.MapperProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDto>().ReverseMap();
        }
    }
}
