using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_WebAPI.Models
{
    public class CarShopDbContext:DbContext
    {

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSP> LoaiSPs { get; set; }
        public DbSet<NhaCC> NhaCCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-7MQ60DF\\SQLEXPRESS01; Database=CarShop;Integrated Security=True;");
            }
        }
    }
}
