using QLSQ.ViewModel.Catalogs.New;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface INewApiClient
    {
        public Task<APIResult<PageResult<NewViewModel>>> GetAllWithPaging(GetNewPagingRequest request);
        public Task<APIResult<List<NewViewModel>>> GetListNewAutoComplete(string prefix);
        public Task<APIResult<bool>> Create(NewCreateRequest request);
        public Task<APIResult<NewDetailsViewModel>> Details(int NewID);
        public Task<APIResult<bool>> Edit(int NewID, NewUpdateRequest request);
        public Task<APIResult<bool>> Delete(int NewID);
        public Task<APIResult<List<NewDetailsViewModel>>> GetLastestNew();
        public Task<APIResult<List<NewDetailsViewModel>>> GetMostViewNew();
        public Task<APIResult<List<NewDetailsViewModel>>> GetKHCNNewInIndex();
        public Task<APIResult<List<NewDetailsViewModel>>> GetTuyenSinhViewInIndex();
    }
}
