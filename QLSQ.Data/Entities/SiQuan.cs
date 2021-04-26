using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class SiQuan
    {
        public int IDSQ { get; set; }
        public Guid UserId { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SDT { get; set; }

        public AppUser AppUser {  get; set; }
        public QLLuong QLLuongs { set; get; }
        public List<QLDangVien> QLDangViens { set; get; }
        public List<QLChucVu> QLChucVus { set; get; }
        public List<QLQuanHam> QLQuanHams { set; get; }
        public List<QLCongTac> QLCongTacs { set; get; }
        public List<QLNghiPhep> QLNghiPheps { set; get; }
        public List<SiQuanImage> SiQuanImages { set; get; }
        public List<QLKhenThuongKiLuat> QLKhenThuongKiLuats { get; set; }
        public List<QLQuaTrinhDaoTao> QLQuaTrinhDaoTaos { get; set; }
        public List<QLGiaDinhSQ> QLGiaDinhSQs { get; set; }
    }
}
