using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Common
{
    public class PagingRequestBase :RequestBase
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
