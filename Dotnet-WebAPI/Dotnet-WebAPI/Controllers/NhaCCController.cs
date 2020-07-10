using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_WebAPI.Controllers
{
    [Route("api/NhaCC")]
    [ApiController]
    public class NhaCCController : ControllerBase
    {
        [HttpGet]
        public IActionResult listLoaiSP()
        {
            using (var db = new CarShopDbContext())
            {
                List<NhaCC> dsNCC = db.NhaCCs.ToList();
                if (dsNCC == null)
                    return null;
                return Ok(dsNCC);
            }
        }
    }
}
