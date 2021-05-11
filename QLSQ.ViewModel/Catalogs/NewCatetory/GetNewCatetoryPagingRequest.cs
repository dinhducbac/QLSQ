using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.NewCatetory
{
    public class GetNewCatetoryPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}
