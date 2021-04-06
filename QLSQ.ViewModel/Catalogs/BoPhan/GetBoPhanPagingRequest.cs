using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.BoPhan
{
    public class GetBoPhanPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}
