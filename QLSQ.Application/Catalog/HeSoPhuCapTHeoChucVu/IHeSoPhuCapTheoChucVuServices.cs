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
    }
}
