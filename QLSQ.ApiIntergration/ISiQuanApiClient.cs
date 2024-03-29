﻿using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface ISiQuanApiClient
    {
        public Task<APIResult<PageResult<SiQuanViewModel>>> GetAllManagePaging(GetManageSiQuanPagingRequest request);
        public Task<APIResult<int>> Create(SiQuanCreateRequest request);
        public Task<APIResult<SiQuanViewModel>> GetByID(int IDSQ);
        public Task<APIResult<bool>> Update(int IDSQ, SiQuanUpdateRequest request);
        public Task<APIResult<string>> Delete(int IDSQ);
        public Task<APIResult<List<SiQuanViewModel>>> GetListSiQuanNotInQLDangVienAutoComplete(string prefix);
        public Task<APIResult<List<SiQuanViewModel>>> GetAllWithoutPaging();
        public Task<APIResult<List<SiQuanInQLLuongViewModel>>> GetListSiQuanAutocomplete(string preconfix);
        public Task<APIResult<List<SiQuanViewModel>>> GetFullListSiQuanAutocomplete(string preconfix);
        public Task<APIResult<List<SiQuanViewModel>>> GetListSiQuanNotInQLChucVuAutocomplete(string prefix);
        public Task<APIResult<List<SiQuanViewModel>>> GetListSiQuanNotInQLQuanHamAutocomplete(string prefix);
        public Task<APIResult<ProfileViewModel>> GetProfileByUserName(string UserName);
        public Task<APIResult<InfoOfJobOfSiQuanViewModel>> GetInfoOfJobOfSiQuan(int IDSQ);
    }
}
