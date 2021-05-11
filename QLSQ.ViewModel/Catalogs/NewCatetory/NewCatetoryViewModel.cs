using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.NewCatetory
{
    public class NewCatetoryViewModel
    {
        [Display(Name ="ID loại tin tức")]
        public int NewCatetoryID { get; set; }
        [Display(Name = "Tên loại tin tức")]
        public string NewCatetoryName { get; set; }
    }
}
