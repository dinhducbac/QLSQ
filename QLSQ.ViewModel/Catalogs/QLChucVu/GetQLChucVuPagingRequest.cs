using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLChucVu
{
    public class GetQLChucVuPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> IDSQ { get; set; }
        public List<int> IDCV { get; set; }
        public List<int> IDQH { get; set; }
    }
}
