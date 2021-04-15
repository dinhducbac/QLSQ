using QLSQ.ViewModel.Catalogs.QLNghiPHep;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLNghiPhepApiClient
    {
        public Task<APIResult<PageResult<QLNghiPhepViewModel>>> GetAllWithPaging(GetQLNghiPhepPagingRequest request);
    }
}
