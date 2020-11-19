using QLSQ.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Application.Catalog.SiQuans.Dtos.Public
{
    public class GetSiQuanPagingRequest : PagingRequestBase
    {
        public int? IDSQ { get; set; }
    }
}
