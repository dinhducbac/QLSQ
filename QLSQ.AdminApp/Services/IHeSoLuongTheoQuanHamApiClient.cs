using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IHeSoLuongTheoQuanHamApiClient
    {
        public Task<APIResult<PageResult<HeSoLuongTheoQuanHamViewModel>>> GetAllWithPaging(GetPagingRequestHeSoLuongTheoQuanHam request);
    }
}
