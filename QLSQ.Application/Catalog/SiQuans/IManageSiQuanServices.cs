﻿using Microsoft.AspNetCore.Http;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Catalogs.SiQuan.Manage;
using QLSQ.ViewModel.Catalogs.SiQuanImage.Manage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuans
{
    public interface IManageSiQuanServices
    {
        Task<int> Create(SiQuanCreateRequest request);

        Task<int> Update(SiQuanUpdateRequest request);
        Task<int> Detele(int SiQuanID);

        Task<PageResult<SiQuanViewModel>> GetAllPaging(GetSiQuanPagingRequest request);
        Task<int> AddImages(int SiQuanID, SiQuanImageCreateRequest request);
        Task<int> RemoveImages(int ImageID);
        Task<int> UpdateImages(int ImageID, SiQuanImageUpdateRequest request);
        Task<List<SiQuanImageViewModel>> GetListImage(int SiQuanID);
    }
}
