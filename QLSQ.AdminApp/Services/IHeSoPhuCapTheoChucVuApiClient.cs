using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IHeSoPhuCapTheoChucVuApiClient
    {
        public Task<APIResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>> GetAllWithPaging(GetHeSoPhuCapPagingRequest request);
    }
}
