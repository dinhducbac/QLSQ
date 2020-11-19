
using QLSQ.Application.Catalog.SiQuans.Dtos;
using QLSQ.Application.Catalog.SiQuans.Dtos.Public;
using QLSQ.Application.Dtos;
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

