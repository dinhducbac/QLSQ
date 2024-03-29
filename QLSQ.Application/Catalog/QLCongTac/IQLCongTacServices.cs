﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSQ.ViewModel.Catalogs.QLCongTac;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QLCongTac
{
    public interface IQLCongTacServices
    {
        public Task<APIResult<PageResult<QLCongTacViewModel>>> GetAll(GetQLCongTacPagingRequest request);
        public Task<APIResult<bool>> Create(QLCongTacCreateRequest request);
        public Task<APIResult<QLCongTacViewModel>> Details(int IDCT);
        public Task<APIResult<bool>> Edit(int IDCT, QLCongTacUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDCT);
    }
}
