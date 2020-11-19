using QLSQ.Application.Catalog.SiQuans.Dtos;
using QLSQ.Application.Catalog.SiQuans.Dtos.Manage;
using QLSQ.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuans
{
    public interface IManageSiQuanServices
    {
        Task<int> Create(SiQuanCreateRequest request);

        Task<int> Update(SiQuanUpdateRequest request);
        Task<int> Detele(int SiQuanID);

        Task<List<SiQuanViewModel>> GetAll();
        Task<PageResult<SiQuanViewModel>> GetAllPaging(GetSiQuanPagingRequest request);
    }
}
