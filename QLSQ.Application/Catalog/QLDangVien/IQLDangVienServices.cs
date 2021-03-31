using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSQ.ViewModel.Catalogs.QLDangVien;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.QLDangVien
{
    public interface IQLDangVienServices
    {
        public Task<APIResult<PageResult<QLDangVienViewModel>>> GetAllQLDangVien(GetQLDangVienPagingRequest request);
        public Task<APIResult<bool>> Create(QLDangVienCreateRequest request);
    }
}
