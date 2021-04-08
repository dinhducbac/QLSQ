using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.HeSoPhuCapTHeoChucVu
{
    public interface IHeSoPhuCapTheoChucVuServices
    {
        public Task<APIResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>> GetAllWithPaging(GetHeSoPhuCapPagingRequest request);
        public Task<APIResult<bool>> Create(HeSoPhuCapTheoChucVuCreateRequest request);
        public Task<APIResult<HeSoPhuCapTheoChucVuDetailsViewModel>> Details(int IDHeSoPhuCapCV);
        public Task<APIResult<bool>> Edit(int IDHeSoPhuCapCV, HeSoPhuCapTheoChucVuUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDHeSoPhuCapCV);
    }
}
