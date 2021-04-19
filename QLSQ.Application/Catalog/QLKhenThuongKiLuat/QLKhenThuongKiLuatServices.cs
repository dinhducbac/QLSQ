using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QLKhenThuongKiLuat
{
    public class QLKhenThuongKiLuatServices : IQLKhenThuongKiLuatServices
    {
        public readonly QL_SiQuanDBContext _context;
        public QLKhenThuongKiLuatServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }
        public async Task<APIResult<PageResult<QLKhenThuongKiLuatViewModel>>> GetAllWithPaging(GetQLKhenThuongKiLuatPagingRequest request)
        {
            var query = from qlktkl in _context.QLKhenThuongKiLuats
                        join sq in _context.SiQuans
                        on qlktkl.IDSQ equals sq.IDSQ
                        select new QLKhenThuongKiLuatViewModel()
                        {
                            IDKTKL = qlktkl.IDSQ,
                            IDSQ = qlktkl.IDSQ,
                            HoTen = sq.HoTen,
                            NgayThucHien = qlktkl.NgayThucHien,
                            LoaiKTKL = qlktkl.LoaiKTKL,
                            HinhThuc = qlktkl.HinhThuc,
                            DonViCap = qlktkl.DonViCap,
                            NoiDung = qlktkl.NoiDung
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x=>x.HoTen.Contains(request.keyword)||x.HinhThuc.Contains(request.keyword)||
                x.NoiDung.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLKhenThuongKiLuatViewModel
                {
                    IDKTKL = x.IDSQ,
                    IDSQ = x.IDSQ,
                    HoTen = x.HoTen,
                    NgayThucHien = x.NgayThucHien,
                    LoaiKTKL = x.LoaiKTKL,
                    HinhThuc = x.HinhThuc,
                    DonViCap = x.DonViCap,
                    NoiDung = x.NoiDung
                }).ToListAsync();
            var pageResult = new PageResult<QLKhenThuongKiLuatViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLKhenThuongKiLuatViewModel>>(pageResult);
        }
    }
}
