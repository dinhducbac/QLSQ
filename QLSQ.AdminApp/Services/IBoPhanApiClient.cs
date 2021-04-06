using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IBoPhanApiClient
    {
        public Task<APIResult<PageResult<BoPhanViewModel>>> GetAllWithPaging(GetBoPhanPagingRequest request);
        public Task<APIResult<bool>> Create(BoPhanCreateRequest request);
        public Task<APIResult<BoPhanViewModel>> Details(int IDBP);
        public Task<APIResult<bool>> Edit(int IDBP, BoPhanUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDBP);
    }
}
