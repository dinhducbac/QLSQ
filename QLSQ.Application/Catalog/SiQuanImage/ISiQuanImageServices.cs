using QLSQ.ViewModel.Catalogs.SiQuanImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuanImage
{
    public interface ISiQuanImageServices
    {
        public Task<APIResult<PageResult<SiQuanImageViewModel>>> GetAllWithPaging(GetSiQuanImagePagingRequest request);
        public Task<APIResult<bool>> Create(SiQuanImageCreateRequest request);
        public Task<APIResult<SiQuanImageViewModel>> Details(int IDImage);
        public Task<APIResult<bool>> Edit(int IDImage, SiQuanImageUpdateRequest request);

    }
}
