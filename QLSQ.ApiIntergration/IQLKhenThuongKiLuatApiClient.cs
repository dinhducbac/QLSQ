using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Catalogs.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface IQLKhenThuongKiLuatApiClient
    {
        public Task<APIResult<PageResult<QLKhenThuongKiLuatViewModel>>> GetAllWithPaging(GetQLKhenThuongKiLuatPagingRequest request);
        public Task<APIResult<bool>> Create(QLKhenThuongKiLuatCreateRequest request);
        public Task<APIResult<QLKhenThuongKiLuatViewModel>> Details(int IDQLKTKL);
        public Task<APIResult<bool>> Edit(int IDQLKTKL, QLKhenThuongKiLuatUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDQLKTKL);

    }
}
