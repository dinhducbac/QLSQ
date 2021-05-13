using QLSQ.Data.Entities;
using QLSQ.ViewModel.Catalogs.New;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.New
{
    public interface INewServices
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
        public Task<APIResult<List<NewDetailsViewModel>>> GetTuyenSinhNewInIndex();
        public Task<APIResult<List<NewDetailsViewModel>>> GetListKHCNNew();
        public Task<APIResult<NewDetailsViewModel>> DetailNew(int NewID);
        public Task<APIResult<List<NewDetailsViewModel>>> GetRelatedNew(int NewCatetoryID);

    }
}
