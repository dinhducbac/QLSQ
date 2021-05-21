using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.ChucVu
{
    public class GetChucVuPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> IDBP { get; set; }
    }
}
