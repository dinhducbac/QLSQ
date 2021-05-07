using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.New
{
    public class GetNewPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}
