using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam
{
    public class GetPagingRequestHeSoLuongTheoQuanHam : PagingRequestBase
    {
        public List<int> IDQH { get; set; }
        public string keyword { get; set; }
    }
}
