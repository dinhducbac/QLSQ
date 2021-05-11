using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.NewCatetory
{
    public class NewCatetoryCreateRequest
    {
        [Display(Name ="Tên thể loại tin tức")]
        public string NewCatetoryName { get; set; } 
    }
}
