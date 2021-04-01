using QLSQ.ViewModel.Catalogs.QLCongTac;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLCongTacApiClient
    {
        public Task<APIResult<PageResult<QLCongTacViewModel>>> GetAll(GetQLCongTacPagingRequest request);
    }
}
