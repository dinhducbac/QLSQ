using Microsoft.AspNetCore.Http;
using QLSQ.ViewModel.Catalogs.NewImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.NewImage
{
    public interface INewImageServices
    {
        public Task<APIResult<PageResult<NewImageViewModel>>> GetAllWithPaging(GetNewImagePagingRequest request);
        public Task<APIResult<bool>> Create(NewImageCreateRequest request);
        public Task<string> SaveFile(IFormFile file);
        public Task<APIResult<string>> GetImagePathByNewID(int NewID);

        public Task<APIResult<bool>> DeleteNewImageByNewID(int NewID);
    }
}
