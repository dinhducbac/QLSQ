
using QLSQ.Application.Catalog.SiQuans;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Catalogs.SiQuan.Public;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuan
{
    public interface IPublicSiQuanServices
    {
        public Task<PageResult<SiQuanViewModel>> GetAllBySiQuanId(GetSiQuanPagingRequest request);
    }
}

