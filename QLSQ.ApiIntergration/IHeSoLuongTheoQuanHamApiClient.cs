﻿using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface IHeSoLuongTheoQuanHamApiClient
    {
        public Task<APIResult<PageResult<HeSoLuongTheoQuanHamViewModel>>> GetAllWithPaging(GetPagingRequestHeSoLuongTheoQuanHam request);
        public Task<APIResult<bool>> Create(HeSoLuongTheoQuanHamCreateRequest request);
        public Task<APIResult<HeSoLuongTheoQuanHamViewModel>> Details(int IDHeSoLuongQH);
        public Task<APIResult<bool>> Edit(int IDHeSoLuongQH, HeSoLuongTheoQuanHamUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDHeSoLuongQH);
        public Task<APIResult<bool>> CheckNameHeSoLuongInCreate(string name);
        public Task<APIResult<List<HeSoLuongTheoQuanHamViewModel>>> GetHeSoLuongTheoQHByIDQH(int IDQH);
        public Task<APIResult<HeSoLuongTheoQuanHamViewModel>> GetHeSoLuongTheoQHByIDHeSoLuongQH(int IDHeSoLuongQH);
    }
}
