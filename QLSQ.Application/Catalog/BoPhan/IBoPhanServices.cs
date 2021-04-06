using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.BoPhan
{
    public interface IBoPhanServices
    {
        public Task<APIResult<PageResult<BoPhanViewModel>>> GetAllWithPaging(GetBoPhanPagingRequest request);
    }
}
