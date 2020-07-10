using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_WebAPI.Models
{
    [Table("LoaiSP")]
    public class LoaiSP
    {
        [Key]
        public int MaLoaiSP { get; set; }
        public string TenLoai { get; set; }
    }
}
