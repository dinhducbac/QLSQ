using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan.Public
{
    public class GetSiQuanPagingRequest : PagingRequestBase
    {
        public int? IDSQ { get; set; }
    }
}
