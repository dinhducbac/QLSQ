using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QLQuaTrinhDaoTao
{
    public class QLQuaTrinhDaoTaoServices : IQLQuaTrinhDaoTaoServices
    {
        public readonly QL_SiQuanDBContext _context;
        public QLQuaTrinhDaoTaoServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }
        public async Task<APIResult<PageResult<QLQuaTrinhDaoTaoViewModel>>> GetAllWithPaging(GetQLQuaTrinhDaoTaoPagingRequest request)
        {
            var query = from qlqtdt in _context.QLQuaTrinhDaoTaos
                        join sq in _context.SiQuans
                        on qlqtdt.IDSQ equals sq.IDSQ
                        select new QLQuaTrinhDaoTaoViewModel() 
                        {
                            IDQLQTDT = qlqtdt.IDQLQTDT,
                            IDSQ = qlqtdt.IDSQ,
                            HoTen = sq.HoTen,
                            TenTruong = qlqtdt.TenTruong,
                            NganhHoc = qlqtdt.NganhHoc,
                            ThoiGianBDDT = qlqtdt.ThoiGianBDDT,
                            ThoiGianKTDT = qlqtdt.ThoiGianKTDT,
                            HinhThucDT = qlqtdt.HinhThucDT,
                            VanBang = qlqtdt.VanBang
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x=>x.HoTen.Contains(request.keyword) || x.TenTruong.Contains(request.keyword)||
                x.NganhHoc.Contains(request.keyword)|| x.HinhThucDT.Contains(request.keyword)|| x.VanBang.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLQuaTrinhDaoTaoViewModel()
                {
                    IDQLQTDT = x.IDQLQTDT,
                    IDSQ = x.IDSQ,
                    HoTen = x.HoTen,
                    TenTruong = x.TenTruong,
                    NganhHoc = x.NganhHoc,
                    ThoiGianBDDT = x.ThoiGianBDDT,
                    ThoiGianKTDT = x.ThoiGianKTDT,
                    HinhThucDT = x.HinhThucDT,
                    VanBang = x.VanBang
                }).ToListAsync();
            var pageResult = new PageResult<QLQuaTrinhDaoTaoViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLQuaTrinhDaoTaoViewModel>>(pageResult);
        }
    }
}
