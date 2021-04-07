using QLSQ.ViewModel.Catalogs.ChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IChucVuApiClient
    {
        public Task<APIResult<PageResult<ChucVuViewModel>>> GetAllWithPaging(GetChucVuPagingRequest request);
        public Task<APIResult<bool>> Create(ChucVuCreateRequest request);
        public Task<APIResult<ChucVuDetailsViewModel>> Details(int IDCV);
        public Task<APIResult<bool>> Edit(int IDCV, ChucVuUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDCV);

    }
}
