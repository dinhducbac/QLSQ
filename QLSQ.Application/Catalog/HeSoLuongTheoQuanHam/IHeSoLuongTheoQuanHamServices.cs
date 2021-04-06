using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Catalogs.QuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.HeSoLuongTheoQuanHam
{
    public interface IHeSoLuongTheoQuanHamServices
    {
        public Task<APIResult<PageResult<HeSoLuongTheoQuanHamViewModel>>> GetAllWithPaging(GetPagingRequestHeSoLuongTheoQuanHam request);
        public Task<APIResult<bool>> Create(HeSoLuongTheoQuanHamCreateRequest request);
        public Task<APIResult<HeSoLuongTheoQuanHamViewModel>> Details(int IDHeSoLuongQH);
    }
}
