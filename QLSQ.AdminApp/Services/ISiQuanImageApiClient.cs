using QLSQ.ViewModel.Catalogs.SiQuanImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface ISiQuanImageApiClient
    {
        public Task<APIResult<PageResult<SiQuanImageViewModel>>> GetAllWithPaging(GetSiQuanImagePagingRequest request);
        public Task<APIResult<bool>> Create(SiQuanImageCreateRequest request);
        public Task<APIResult<SiQuanImageViewModel>> Details(int IDImage);
        public Task<APIResult<bool>> Edit(int IDImage, SiQuanImageUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDImage);
    }
}
