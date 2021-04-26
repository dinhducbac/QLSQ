using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLQuanHam
{
    public class GetQLQuanHamPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> IDSQ { get; set; }
    }
}
