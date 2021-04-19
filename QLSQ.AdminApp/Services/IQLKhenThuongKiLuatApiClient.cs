using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLKhenThuongKiLuatApiClient
    {
        public Task<APIResult<PageResult<QLKhenThuongKiLuatViewModel>>> GetAllWithPaging(GetQLKhenThuongKiLuatPagingRequest request);
    }
}
