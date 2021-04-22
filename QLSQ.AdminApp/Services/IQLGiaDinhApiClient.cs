using Microsoft.AspNetCore.Mvc;
using QLSQ.ViewModel.Catalogs.QLGiaDinhSQ;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLGiaDinhApiClient
    {
        public Task<APIResult<PageResult<QLGiaDinhSQViewModel>>> GetAllWithPaging(GetQLGiaDinhSQPagingRequest request);
        public Task<APIResult<QLGiaDinhSQViewModel>> Details(int IDQLGDSQ);
        public Task<APIResult<bool>> Edit(int IDQLGDSQ, QLGiaDinhSQUpdateRequest request); 
    }
}
