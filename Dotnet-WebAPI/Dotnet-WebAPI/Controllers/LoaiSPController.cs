using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_WebAPI.Controllers
{
    [Route("api/LoaiSP")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        [HttpGet]
        public IActionResult listLoaiSP()
        {
            using(var db=new CarShopDbContext())
            {
                List<LoaiSP> dsloai = db.LoaiSPs.ToList();
                if (dsloai == null)
                    return null;
                return Ok(dsloai);
            }
        }
    }
}
