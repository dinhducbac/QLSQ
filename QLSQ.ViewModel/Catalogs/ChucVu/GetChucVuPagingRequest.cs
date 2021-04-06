using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.ChucVu
{
    public class GetChucVuPagingRequest : PagingRequestBase
    {
        public string keword { get; set; }
        public List<int> IDBP { get; set; }
    }
}
