using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLDangVien
    {
        public int IDQLDV { set; get; }
        public int IDSQ { set; get; }
        public DateTime NgayVaoDang { set; get; }
        public string NoiVaoDang { set; get; }
        public SiQuan SiQuan { set; get; }
    }
}
