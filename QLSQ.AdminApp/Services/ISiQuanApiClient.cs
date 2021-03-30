﻿using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface ISiQuanApiClient
    {
        public Task<APIResult<PageResult<SiQuanViewModel>>> GetAllManagePaging(GetManageSiQuanPagingRequest request);
        public Task<APIResult<int>> Create(SiQuanCreateRequest request);
        public Task<APIResult<SiQuanViewModel>> GetByID(int IDSQ);
        public Task<APIResult<bool>> Update(int IDSQ,SiQuanUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDSQ, SiQuanDeleteRequest request);
    }
}