using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DownWallet.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;

namespace DownWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<Shipper> ShipperGet()
        {
            
            
        }
    }
}