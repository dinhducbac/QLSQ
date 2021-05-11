using QLSQ.ViewModel.Catalogs.NewCatetory;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface INewCatetoryApiClient
    {
        public Task<APIResult<PageResult<NewCatetoryViewModel>>> GetAllWithPaging(GetNewCatetoryPagingRequest request);
        public Task<APIResult<bool>> Create(NewCatetoryCreateRequest request);
        public Task<APIResult<NewCatetoryViewModel>> Details(int NewCatetoryID);
        public Task<APIResult<bool>> Edit(int NewCatetoryID, NewCatetoryUpdateRequest request);
        public Task<APIResult<bool>> Delete(int NewCatetoryID);
    }
}
