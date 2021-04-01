using QLSQ.ViewModel.Catalogs.QLCongTac;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLCongTacApiClient
    {
        public Task<APIResult<PageResult<QLCongTacViewModel>>> GetAll(GetQLCongTacPagingRequest request);
        public Task<APIResult<bool>> Create(QLCongTacCreateRequest request);
        public Task<APIResult<QLCongTacViewModel>> Details(int IDCT);
        public Task<APIResult<bool>> Edit(int IDCT, QLCongTacUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDCT);
    }
}
