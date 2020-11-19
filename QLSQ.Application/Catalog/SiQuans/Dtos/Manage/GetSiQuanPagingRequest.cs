using QLSQ.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Application.Catalog.SiQuans.Dtos.Manage
{
    public class GetSiQuanPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> IDSQ { get; set; }
    }
}
