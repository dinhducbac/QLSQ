using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu
{
    public class GetHeSoPhuCapPagingRequest : PagedResultBase
    {
        public string keyword { get; set; }
        public List<int> IDCV { get; set; }
    }
}
