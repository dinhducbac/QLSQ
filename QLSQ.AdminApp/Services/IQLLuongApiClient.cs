using QLSQ.ViewModel.Catalogs.QLLuong;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLLuongApiClient
    {
        public Task<APIResult<PageResult<QLLuongViewModel>>> GetAllWithPaging(GetQLLuongPagingRequest request);
        public Task<APIResult<bool>> Create(QLLuongCreateRequest request);
        public Task<APIResult<QLLuongDetailsViewModel>> Details(int IDLuong);
      
    }
}
