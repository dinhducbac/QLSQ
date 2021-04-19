using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QLKhenThuongKiLuat
{
    public interface IQLKhenThuongKiLuatServices
    {
        public Task<APIResult<PageResult<QLKhenThuongKiLuatViewModel>>> GetAllWithPaging(GetQLKhenThuongKiLuatPagingRequest request);
    }
}
