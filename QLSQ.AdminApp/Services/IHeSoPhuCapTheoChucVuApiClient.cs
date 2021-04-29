using QLSQ.Application.Catalog.HeSoPhuCapTHeoChucVu;
using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IHeSoPhuCapTheoChucVuApiClient
    {
        public Task<APIResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>> GetAllWithPaging(GetHeSoPhuCapPagingRequest request);
        public Task<APIResult<bool>> Create(HeSoPhuCapTheoChucVuCreateRequest request);
        public Task<APIResult<HeSoPhuCapTheoChucVuDetailsViewModel>> Details(int IDHeSoPhuCapCV);
        public Task<APIResult<bool>> Edit(int IDHeSoPhuCapCV, HeSoPhuCapTheoChucVuUpdateRequest request);
        public Task<APIResult<bool>> Delete(int IDHeSoPhuCapCV);
        public Task<APIResult<HeSoPhuCapTheoChucVuViewModel>> GetHeSoPhuCapByIDCV(int IDCV);

    }
}
