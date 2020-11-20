using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuanImage.Manage
{
    public class SiQuanImageUpdateRequest
    {
        public int IDImage { get; set; }
        public int IDSQ { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public long FileSize { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
