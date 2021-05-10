using QLSQ.ViewModel.Catalogs.QLChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface IQLChucVuApiClient
    {
        public Task<APIResult<PageResult<QLChucVuViewModel>>> GetAllWithPaging(GetQLChucVuPagingRequest request);
        public Task<APIResult<bool>> Create(QLChucVuCreateRequest request);
        public Task<APIResult<QLChucVuDetailsViewModel>> Details(int IDQLCV);
        public Task<APIResult<bool>> Edit(int IDQLCV, QLChucVuUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDQLCV);


    }
}
