
using QLSQ.Application.Catalog.SiQuans;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuan
{
    public interface IPublicSiQuanServices
    {
        public Task<PageResult<SiQuanViewModel>> GetAllBySiQuanId(GetPublicSiQuanPagingRequest request);
        public Task<List<SiQuanViewModel>> GetAll();

        public Task<APIResult<ProfileViewModel>> GetProfileByUsername(string UserName);
        public Task<APIResult<InfoOfJobOfSiQuanViewModel>> GetInfoOfJobOfSiQuan(int IDSQ);
    }
}

