using QLSQ.ViewModel.Catalogs.QLDangVien;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IQLDangVienAPIClient
    {
        public Task<APIResult<PageResult<QLDangVienViewModel>>> GetAllQLDangVien(GetQLDangVienPagingRequest request);
        public Task<APIResult<bool>> Create(QLDangVienCreateRequest request);
        public Task<APIResult<QLDangVienViewModel>> GetByID(int IDQLDV);
        public Task<APIResult<bool>> Edit(int IDQLDV, QLDangVienUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDQLDV);
    }
}
