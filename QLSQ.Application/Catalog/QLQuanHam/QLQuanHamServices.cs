using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QLQuanHam
{
    public class QLQuanHamServices : IQLQuanHamServices
    {
        public readonly QL_SiQuanDBContext _context;
        public QLQuanHamServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }
        public async Task<APIResult<PageResult<QLQuanHamViewModel>>> GetAllWithPaging(GetQLQuanHamPagingRequest request)
        {
            var query = from qlqh in _context.QLQuanHams
                        join qh in _context.QuanHams
                        on qlqh.IDQH equals qh.IDQH
                        join hsltqh in _context.HeSoLuongTheoQuanHams
                        on qlqh.IDHeSoLuongTheoQH equals hsltqh.IDHeSoLuongQH
                        join sq in _context.SiQuans
                        on qlqh.IDSQ equals sq.IDSQ
                        select new QLQuanHamViewModel()
                        {
                            IDQLQH = qlqh.IDQLQH,
                            IDSQ = qlqh.IDSQ,
                            HoTen = sq.HoTen,
                            TenQH = qh.TenQH,
                            TenHeSoLuongQH = hsltqh.TenHeSoLuongQH
                        };
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLQuanHamViewModel()
                {
                    IDQLQH = x.IDQLQH,
                    IDSQ = x.IDSQ,
                    HoTen = x.HoTen,
                    TenQH = x.TenQH,
                    TenHeSoLuongQH = x.TenHeSoLuongQH
                }).ToListAsync();
            var pageResult = new PageResult<QLQuanHamViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLQuanHamViewModel>>(pageResult);
        }
    }
}
