using QLSQ.ViewModel.Catalogs.QLChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLChucVuApiClient
    {
        public Task<APIResult<PageResult<QLChucVuViewModel>>> GetAllWithPaging(GetQLChucVuPagingRequest request);
        public Task<APIResult<bool>> Create(QLChucVuCreateRequest request);

    }
}
