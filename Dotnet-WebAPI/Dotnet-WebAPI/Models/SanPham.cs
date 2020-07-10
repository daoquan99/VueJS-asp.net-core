using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_WebAPI.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public string MoTa { get; set; }
        public int MaNCC { get; set; }
        public int MaLoaiSP { get; set; }
        public string TenLoai
        {
            get
            {
                if (LoaiSP == null)
                {
                    return "";
                }
                else
                {
                    return LoaiSP.TenLoai;
                }
            }     
        }
        public string TenNCC
        {
            get
            {
                if (NhaCC == null)
                {
                    return "";
                }
                else
                {
                    return NhaCC.TenNCC;
                }
            }
        }
        [ForeignKey("MaLoaiSP")]
        public virtual LoaiSP LoaiSP { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NhaCC NhaCC { get; set; }
        
    }
}
