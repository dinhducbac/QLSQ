﻿using QLSQ.ViewModel.Catalogs.QLLuong;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QLLuong
{
    public interface IQLLuongServices
    {
        public Task<APIResult<PageResult<QLLuongViewModel>>> GetAllWithPaging(GetQLLuongPagingRequest request);
        public Task<APIResult<bool>> Create(QLLuongCreateRequest request);
        public Task<APIResult<QLLuongDetailsViewModel>> Details(int IDLuong);
        public Task<APIResult<bool>> Delete(int IDLuong);
    }
}
