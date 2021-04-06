using QLSQ.ViewModel.Catalogs.ChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.ChucVu
{
    public interface IChucVuServices
    {
        public Task<APIResult<PageResult<ChucVuViewModel>>> GetAllWithPaging(GetChucVuPagingRequest request);
        public Task<APIResult<bool>> Create(ChucVuCreateRequest request);
    }
}
