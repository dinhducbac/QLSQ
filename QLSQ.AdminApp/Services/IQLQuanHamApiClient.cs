using QLSQ.ViewModel.Catalogs.QLQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLQuanHamApiClient
    {
        public Task<APIResult<PageResult<QLQuanHamViewModel>>> GetAllWithPaging(GetQLQuanHamPagingRequest request);
    }
}
