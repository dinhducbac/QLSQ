﻿using QLSQ.ViewModel.Catalogs.QLNghiPHep;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QLNghiPhep
{
    public interface IQLNghiPhepServices
    {
        public Task<APIResult<PageResult<QLNghiPhepViewModel>>> GetAllWithPaging(GetQLNghiPhepPagingRequest request);
        public Task<APIResult<bool>> Create(QLNghiPhepCreateRequest request);
    }
}