using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan
{
    public class GetPublicSiQuanPagingRequest : PagingRequestBase
    {
        public int? IDSQ { get; set; }
    }
}
