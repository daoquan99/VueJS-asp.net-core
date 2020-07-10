using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_WebAPI.Controllers
{
    [Route("api/TimKiemSP")]
    [ApiController]
    public class TimKiemSPController : ControllerBase
    {
        [HttpGet("{tensp}")]
        public IActionResult timKiem(string tensp)
        {
            using (var db = new CarShopDbContext())
            {
                List<SanPham> lstsp = db.SanPhams.Where(x => x.TenSP.Contains(tensp)).ToList();
                lstsp.ForEach(sp =>
                {
                    NhaCC ncc = db.NhaCCs.SingleOrDefault(x => x.MaNCC == sp.MaNCC);
                    LoaiSP lsp = db.LoaiSPs.SingleOrDefault(x => x.MaLoaiSP == sp.MaLoaiSP);
                    sp.NhaCC = ncc;
                    sp.LoaiSP = lsp;
                });
                if (lstsp == null)
                {
                    return null;
                }
                return Ok(lstsp);
            }
        }
    }
}
