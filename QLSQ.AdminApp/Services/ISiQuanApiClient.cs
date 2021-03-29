using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface ISiQuanApiClient
    {
        public Task<APIResult<PageResult<SiQuanViewModel>>> GetAllManagePaging(GetManageSiQuanPagingRequest request);
    }
}
