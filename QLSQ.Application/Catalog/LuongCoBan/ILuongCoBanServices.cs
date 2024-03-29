﻿using QLSQ.ViewModel.Catalogs.LuongCoBan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.LuongCoBan
{
    public interface ILuongCoBanServices
    {
        public Task<APIResult<PageResult<LuongCoBanViewModel>>> GetALLWithPaging(GetLuongCoBanPagingRequest request);
        public Task<APIResult<LuongCoBanViewModel>> Details(int IDLuongCB);
        public Task<APIResult<bool>> Edit(int IDLuongCB, LuongCoBanUpdateRequest request);
    }
}
