using QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLQuaTrinhDaoTaoApiClient
    {
        public Task<APIResult<PageResult<QLQuaTrinhDaoTaoViewModel>>> GetAllWithPaging(GetQLQuaTrinhDaoTaoPagingRequest request);
        public Task<APIResult<bool>> Create(QLQuaTrinhDaoTaoCreateRequest request);
        public Task<APIResult<QLQuaTrinhDaoTaoViewModel>> Details(int IDQLQTDT);
        public Task<APIResult<bool>> Edit(int IDQLQTDT, QLQuaTrinhDaoTaoUpdateRequest request);

    }
}
