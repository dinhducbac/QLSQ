using QLSQ.ViewModel.Catalogs.QLGiaDinhSQ;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QLGiaDinhSQ
{
    public interface IQLGiaDinhSQServices
    {
        public Task<APIResult<PageResult<QLGiaDinhSQViewModel>>> GetAllWithPaging(GetQLGiaDinhSQPagingRequest request);
    }
}
