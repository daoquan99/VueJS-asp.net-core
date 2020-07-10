using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult dsSP()
        {
            using(var db=new CarShopDbContext())
            {
                List<SanPham> lstSanPham = db.SanPhams.ToList();
                if (lstSanPham == null)
                {
                    return null;
                }
                lstSanPham.ForEach(sp =>
                {
                    NhaCC ncc = db.NhaCCs.SingleOrDefault(x => x.MaNCC == sp.MaNCC);
                    LoaiSP lsp = db.LoaiSPs.SingleOrDefault(x => x.MaLoaiSP == sp.MaLoaiSP);
                    sp.NhaCC = ncc;
                    sp.LoaiSP = lsp;
                });
                return Ok(lstSanPham);
            }
        }
        [HttpGet("{id}")]
        public IActionResult SuaSP(int id)
        {
            using (var db = new CarShopDbContext())
            {
                SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSP == id);
                if (sp == null)
                {
                    return null;
                }
                NhaCC ncc = db.NhaCCs.SingleOrDefault(x => x.MaNCC == sp.MaNCC);
                LoaiSP lsp = db.LoaiSPs.SingleOrDefault(x => x.MaLoaiSP == sp.MaLoaiSP);
                sp.LoaiSP = lsp;
                sp.NhaCC = ncc;
                
                return Ok(sp);
            }
        }
        
        [HttpPost]
        public IActionResult ThemSP([FromBody]SanPham sp)
        {
            using (var db = new CarShopDbContext())
            {
                if(sp==null)
                {
                    return null;
                }
                if(sp.MaSP!=0)
                {
                    sp.MaSP = 0;
                }
                sp.LoaiSP = null;
                sp.NhaCC = null;
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return Ok(sp);
            }
        }
        [HttpPut("{id}")]
        public IActionResult updatSP(int id,[FromBody]SanPham sp)
        {
            if (sp.MaSP != id) return BadRequest("không phù hợp");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var db = new CarShopDbContext())
            {
                db.Entry(sp).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();   
                }
                catch(DbUpdateConcurrencyException duxEx)
                {
                    bool exists = db.SanPhams.Count(x => x.MaSP == id) > 0;
                    if(!exists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw duxEx;
                    }
                }
                return Ok(sp);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult XoaSP(int id)
        {
            using (var db = new CarShopDbContext())
            {
                SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSP == id);
                
                if (sp == null)
                {
                    return null;
                }

                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return Ok(sp);
            }
        }
    }
}
