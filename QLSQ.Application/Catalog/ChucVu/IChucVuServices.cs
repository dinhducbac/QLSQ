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
        public Task<APIResult<ChucVuDetailsViewModel>> Details(int IDCV);
        public Task<APIResult<bool>> Edit(int IDCV, ChucVuUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDCV);
        public Task<APIResult<List<ChucVuViewModel>>> GetChucVuWithIDBP(int IDBP);
        public Task<APIResult<List<ChucVuViewModel>>> GetListChucVuByIDBPNotInHSPC(int IDBP);
    }
}
