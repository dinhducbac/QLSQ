﻿using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QuanHam
{
    public class GetQuanHamPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}
