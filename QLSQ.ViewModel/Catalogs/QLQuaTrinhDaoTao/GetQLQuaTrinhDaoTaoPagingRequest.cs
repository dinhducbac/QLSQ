using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao
{
    public class GetQLQuaTrinhDaoTaoPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> IDSQ { get; set; }
    }
}
