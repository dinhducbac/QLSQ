using QLSQ.ViewModel.Catalogs.QLQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QLQuanHam
{
    public interface IQLQuanHamServices
    {
        public Task<APIResult<PageResult<QLQuanHamViewModel>>> GetAllWithPaging(GetQLQuanHamPagingRequest request);
        public Task<APIResult<bool>> Create(QLQuanHamCreateRequest request);
        public Task<APIResult<QLQuanHamDetailsModel>> Details(int IDQLQH);
        public Task<APIResult<bool>> Edit(int IDQLQH, QLQuanHamUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDQLQH);

    }
}
