using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSQ.ViewModel.Catalogs.QuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQuanHamApiClient
    {
        public Task<APIResult<PageResult<QuanHamViewModel>>> GetAllWithPaging(GetQuanHamPagingRequest request);
        public Task<APIResult<QuanHamViewModel>> Details(int IDQH);
        public Task<APIResult<bool>> Create(QuanHamCreateRequest request);
        public Task<APIResult<bool>> Edit(int IDQH,QuanHamUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDQH, QuanHamDeleteRequest request);
        public Task<APIResult<List<QuanHamViewModel>>> GetListQuanHamNotInHeSoLuong();
    }
}
