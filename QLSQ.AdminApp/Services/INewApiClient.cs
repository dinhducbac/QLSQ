using QLSQ.ViewModel.Catalogs.New;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface INewApiClient
    {
        public Task<APIResult<PageResult<NewViewModel>>> GetAllWithPaging(GetNewPagingRequest request);
        public Task<APIResult<bool>> Create(NewCreateRequest request);
        public Task<APIResult<NewDetailsViewModel>> Details(int NewID);
        public Task<APIResult<bool>> Edit(int NewID, NewUpdateRequest request);
    }
}
