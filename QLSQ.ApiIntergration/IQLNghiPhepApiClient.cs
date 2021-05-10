using QLSQ.ViewModel.Catalogs.QLNghiPHep;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface IQLNghiPhepApiClient
    {
        public Task<APIResult<PageResult<QLNghiPhepViewModel>>> GetAllWithPaging(GetQLNghiPhepPagingRequest request);
        public Task<APIResult<bool>> Create(QLNghiPhepCreateRequest request);
        public Task<APIResult<QLNghiPhepViewModel>> Details(int IDNP);
        public Task<APIResult<bool>> Edit(int IDNP, QLNghiPhepUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDNP);
    }
}
