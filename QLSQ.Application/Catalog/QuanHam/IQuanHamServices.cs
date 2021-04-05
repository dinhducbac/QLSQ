﻿using QLSQ.ViewModel.Catalogs.QuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QuanHam
{
    public interface IQuanHamServices
    {
        public Task<APIResult<PageResult<QuanHamViewModel>>> GetAllWithPaging(GetQuanHamPagingRequest request);
        public Task<APIResult<QuanHamViewModel>> Details(int IDQH);
    }
}