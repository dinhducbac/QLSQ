using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLNghiPHep
{
    public class GetQLNghiPhepPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> IDSQ { get; set; }
    }
}
