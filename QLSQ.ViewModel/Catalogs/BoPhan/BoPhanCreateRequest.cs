using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.BoPhan
{
    public class BoPhanCreateRequest
    {
        [Display(Name = "Tên bộ phận")]
        public string TenBP { get; set; }
    }
}
