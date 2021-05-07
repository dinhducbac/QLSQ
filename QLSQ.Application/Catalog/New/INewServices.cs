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
        public Task<APIResult<bool>> Create(NewCreateRequest request);
        public Task<APIResult<NewDetailsViewModel>> Details(int NewID);
        public Task<APIResult<bool>> Edit(int NewID, NewUpdateRequest request);
    }
}
