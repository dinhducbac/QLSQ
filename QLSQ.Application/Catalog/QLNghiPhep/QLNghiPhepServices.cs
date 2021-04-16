using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLNghiPHep;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QLNghiPhep
{
    public class QLNghiPhepServices : IQLNghiPhepServices
    {
        public readonly QL_SiQuanDBContext _context;
        public QLNghiPhepServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(QLNghiPhepCreateRequest request)
        {
            if (DateTime.Compare(request.ThoiGianBDNP, request.ThoiGianKTNP) > 0)
            {
                return new APIErrorResult<bool>("Thất bại");
            }
            var qlnp = new QLSQ.Data.Entities.QLNghiPhep()
            {
                IDSQ = request.IDSQ,
                ThoiGianBDNP = request.ThoiGianBDNP,
                ThoiGianKTNP = request.ThoiGianKTNP
            };
            if (DateTime.Compare(request.ThoiGianKTNP, DateTime.Now) <0 )
            {
                qlnp.NghiPhepState = 0;
            }
            else
            {
                qlnp.NghiPhepState = 1;
            }
            _context.QLNghiPheps.Add(qlnp);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<QLNghiPhepViewModel>> Details(int IDNP)
        {
            var qlnpvm = await (from qlnp in _context.QLNghiPheps
                             join sq in _context.SiQuans
                             on qlnp.IDSQ equals sq.IDSQ
                             where qlnp.IDNP == IDNP
                             select new QLNghiPhepViewModel()
                             {
                                 IDNP = qlnp.IDNP,
                                 IDSQ = qlnp.IDSQ,
                                 HoTen = sq.HoTen,
                                 ThoiGianBDNP = qlnp.ThoiGianBDNP,
                                 ThoiGianKTNP = qlnp.ThoiGianKTNP,
                                 NghiPhepState = qlnp.NghiPhepState
                             }).FirstOrDefaultAsync();
            var qlnpViewModel = new QLNghiPhepViewModel()
            {
                IDNP = qlnpvm.IDNP,
                IDSQ = qlnpvm.IDSQ,
                HoTen = qlnpvm.HoTen,
                ThoiGianBDNP = qlnpvm.ThoiGianBDNP,
                ThoiGianKTNP = qlnpvm.ThoiGianKTNP,
                NghiPhepState = qlnpvm.NghiPhepState
            };
            return new APISuccessedResult<QLNghiPhepViewModel>(qlnpViewModel);
        }

        public async Task<APIResult<PageResult<QLNghiPhepViewModel>>> GetAllWithPaging(GetQLNghiPhepPagingRequest request)
        {
            var query = from qlnp in _context.QLNghiPheps
                        join sq in _context.SiQuans
                        on qlnp.IDSQ equals sq.IDSQ
                        select new QLNghiPhepViewModel() 
                        {
                            IDNP = qlnp.IDNP,
                            IDSQ = qlnp.IDSQ,
                            HoTen = sq.HoTen,
                            ThoiGianBDNP = qlnp.ThoiGianBDNP,
                            ThoiGianKTNP = qlnp.ThoiGianKTNP,
                            NghiPhepState = qlnp.NghiPhepState
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.IDSQ.ToString().Contains(request.keyword) || x.HoTen.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLNghiPhepViewModel()
                {
                    IDNP = x.IDNP,
                    IDSQ = x.IDSQ,
                    HoTen = x.HoTen,
                    ThoiGianBDNP = x.ThoiGianBDNP,
                    ThoiGianKTNP = x.ThoiGianKTNP,
                    NghiPhepState = x.NghiPhepState
                }).ToListAsync();
            var pageResult = new PageResult<QLNghiPhepViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLNghiPhepViewModel>>(pageResult);
        }
    }
}
