using QLSQ.ViewModel.Catalogs.NewImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface INewImageApiClient
    {
        public Task<APIResult<PageResult<NewImageViewModel>>> GetAllWithPaging(GetNewImagePagingRequest request);
        public Task<APIResult<bool>> Create(NewImageCreateRequest request);
        public Task<APIResult<NewImageDetailsModel>> Details(int NewImageID);
        public Task<APIResult<bool>> Edit(int NewImageID, NewImageUpdateRequest request);
        public Task<APIResult<bool>> Delete(int NewImageID);
    }
}
