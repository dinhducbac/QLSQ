using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Application.Catalog.SiQuans.Dtos.Manage
{
    public class SiQuanCreateRequest
    {
        public Guid UserId { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SDT { get; set; }
    }
}
