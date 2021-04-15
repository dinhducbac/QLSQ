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
        public Task<APIResult<int>> Create(SiQuanCreateRequest request);

        public Task<APIResult<bool>> Update(int IDSQ, SiQuanUpdateRequest request);
        public Task<APIResult<string>> Detele(int IDSQ);

        public Task<APIResult<SiQuanViewModel>> GetById(int IDSQ);

        public Task<APIResult<PageResult<SiQuanViewModel>>> GetAllPaging(GetManageSiQuanPagingRequest request);
        public Task<APIResult<List<SiQuanViewModel>>> GetAllWithoutPaging();
        public Task<APIResult<List<SiQuanViewModel>>> GetSiQuanNotInQLDangVien();
        public Task<int> AddImages(int SiQuanID, SiQuanImageCreateRequest request);
        public Task<int> RemoveImages(int ImageID);
        public Task<int> UpdateImages(int ImageID, SiQuanImageUpdateRequest request);
        public Task<SiQuanImageViewModel> GetImageByID(int SiQuanImageID);
        public Task<List<SiQuanImageViewModel>> GetListImage(int SiQuanID);
        public Task<APIResult<List<SiQuanInQLLuongViewModel>>> GetListSiQuanAutocomplete(string preconfix);
        public Task<APIResult<List<SiQuanViewModel>>> GetFullListSiQuanAutocomplete(string preconfix);
        public Task<APIResult<List<SiQuanViewModel>>> GetListSiQuanNotInQLChucVuAutocomplete(string prefix);
    }
}
