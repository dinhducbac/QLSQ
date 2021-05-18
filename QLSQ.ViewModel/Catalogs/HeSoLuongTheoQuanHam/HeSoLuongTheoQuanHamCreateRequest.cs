using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam
{
    public class HeSoLuongTheoQuanHamCreateRequest
    {
        [Display(Name = "ID quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Tên hệ số lương")]
        public string TenHeSoLuongQH { get; set; }
        [Display(Name = "Hệ số lương")]    
        [DataType(DataType.Currency,ErrorMessage ="Hệ số lương phải là chữ số")]
        public float HeSoLuong { get; set; }
        public List<QuanHamViewModel> quanHamViewModels { get; set; }
    }
}
