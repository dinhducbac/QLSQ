using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLGiaDinhSQ;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QLGiaDinhSQ
{
    public class QLGiaDinhServices : IQLGiaDinhSQServices
    {
        public readonly QL_SiQuanDBContext _context;
        public QLGiaDinhServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<QLGiaDinhSQViewModel>> Details(int IDQLGDSQ)
        {
            var getqlgdsq = await (from qlgdsq in _context.QLGiaDinhSQs
                                   join sq in _context.SiQuans
                                   on qlgdsq.IDSQ equals sq.IDSQ
                                   where qlgdsq.IDQLGDSQ == IDQLGDSQ
                                   select new QLGiaDinhSQViewModel()
                                   {
                                       IDQLGDSQ = qlgdsq.IDQLGDSQ,
                                       IDSQ = qlgdsq.IDSQ,
                                       HoTenSQ = sq.HoTen,
                                       QuanHe = qlgdsq.QuanHe,
                                       HoTen = qlgdsq.HoTen,
                                       NgaySinh = qlgdsq.NgaySinh,
                                       GhiChu = qlgdsq.GhiChu
                                   }).FirstOrDefaultAsync();
            return new APISuccessedResult<QLGiaDinhSQViewModel>(getqlgdsq);
        }

        public async Task<APIResult<bool>> Edit(int IDQLGDSQ, QLGiaDinhSQUpdateRequest request)
        {
            var qlgdsq = await _context.QLGiaDinhSQs.FirstOrDefaultAsync(x => x.IDQLGDSQ == IDQLGDSQ);
            qlgdsq.QuanHe = request.QuanHe;
            qlgdsq.HoTen = request.HoTen;
            qlgdsq.NgaySinh = request.NgaySinh;
            qlgdsq.GhiChu = request.GhiChu;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<QLGiaDinhSQViewModel>>> GetAllWithPaging(GetQLGiaDinhSQPagingRequest request)
        {
            var query = from qlgdsq in _context.QLGiaDinhSQs
                        join sq in _context.SiQuans 
                        on qlgdsq.IDSQ equals sq.IDSQ
                        select new QLGiaDinhSQViewModel() 
                        {
                            IDQLGDSQ = qlgdsq.IDQLGDSQ,
                            IDSQ = qlgdsq.IDSQ,
                            HoTenSQ = sq.HoTen,
                            QuanHe = qlgdsq.QuanHe,
                            HoTen = qlgdsq.HoTen,
                            NgaySinh = qlgdsq.NgaySinh,
                            GhiChu = qlgdsq.GhiChu
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x=>x.HoTenSQ.Contains(request.keyword) || x.QuanHe.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLGiaDinhSQViewModel()
                {
                    IDQLGDSQ = x.IDQLGDSQ,
                    IDSQ = x.IDSQ,
                    HoTenSQ = x.HoTenSQ,
                    QuanHe = x.QuanHe,
                    HoTen = x.HoTen,
                    NgaySinh = x.NgaySinh,
                    GhiChu = x.GhiChu
                }).ToListAsync();
            var pageResult = new PageResult<QLGiaDinhSQViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLGiaDinhSQViewModel>>(pageResult);
        }
    }
}
