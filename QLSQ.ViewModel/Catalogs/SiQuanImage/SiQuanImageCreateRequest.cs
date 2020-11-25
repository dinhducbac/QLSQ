using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuanImage
{
    public class SiQuanImageCreateRequest
    {
        public string Caption { get; set; }
        public bool IsDefault { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}
