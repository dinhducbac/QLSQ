﻿using QLSQ.ViewModel.Catalogs.LuongCoBan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface ILuongCoBanApiClient
    {
        public Task<APIResult<PageResult<LuongCoBanViewModel>>> GetAllWithPaging(GetLuongCoBanPagingRequest request);
        public Task<APIResult<LuongCoBanViewModel>> Details(int IDLuongCB);
        public Task<APIResult<bool>> Edit(int IDLuongCB, LuongCoBanUpdateRequest request);
    }
}
