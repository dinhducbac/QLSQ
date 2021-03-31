using Microsoft.AspNetCore.Http;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Catalogs.SiQuanImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuans
{
    public interface IManageSiQuanServices
    {
        Task<APIResult<int>> Create(SiQuanCreateRequest request);

        Task<APIResult<bool>> Update(int IDSQ, SiQuanUpdateRequest request);
        Task<APIResult<string>> Detele(int IDSQ);

        Task<APIResult<SiQuanViewModel>> GetById(int IDSQ);

        Task<APIResult<PageResult<SiQuanViewModel>>> GetAllPaging(GetManageSiQuanPagingRequest request);
        Task<APIResult<List<SiQuanViewModel>>> GetSiQuanNotInQLDangVien();
        Task<int> AddImages(int SiQuanID, SiQuanImageCreateRequest request);
        Task<int> RemoveImages(int ImageID);
        Task<int> UpdateImages(int ImageID, SiQuanImageUpdateRequest request);
        Task<SiQuanImageViewModel> GetImageByID(int SiQuanImageID);
        Task<List<SiQuanImageViewModel>> GetListImage(int SiQuanID);
    }
}
