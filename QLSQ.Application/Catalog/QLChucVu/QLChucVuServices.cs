using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QLChucVu
{
    public class QLChucVuServices : IQLChucVuServices
    {
        public readonly QL_SiQuanDBContext _context;
        public QLChucVuServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(QLChucVuCreateRequest request)
        {
            var qlcv = new QLSQ.Data.Entities.QLChucVu()
            {
                IDSQ = request.IDSQ,
                IDQH = request.IDQH,
                IDCV = request.IDCV
            };
            _context.QLChucVus.Add(qlcv);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<QLChucVuViewModel>>> GetAllWithPaging(GetQLChucVuPagingRequest request)
        {
            var query = from qlcv in _context.QLChucVus
                        join sq in _context.SiQuans
                        on qlcv.IDSQ equals sq.IDSQ
                        join cv in _context.ChucVus
                        on qlcv.IDCV equals cv.IDCV
                        join qh in _context.QuanHams
                        on qlcv.IDQH equals qh.IDQH
                        select new QLChucVuViewModel
                        {
                            IDQLCV = qlcv.IDQLCV,
                            IDSQ = sq.IDSQ,
                            HoTenSQ = sq.HoTen,
                            IDQH = qh.IDQH,
                            TenQH = qh.TenQH,
                            IDCV = cv.IDCV,
                            TenCV = cv.TenCV                    
                        };
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.HoTenSQ.Contains(request.keyword) || x.TenQH.Contains(request.keyword) ||
                x.TenCV.Contains(request.keyword));
            }
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLChucVuViewModel
                {
                    IDQLCV = x.IDQLCV,
                    IDSQ = x.IDSQ,
                    HoTenSQ = x.HoTenSQ,
                    IDQH = x.IDQH,
                    TenQH = x.TenQH,
                    IDCV = x.IDCV,
                    TenCV = x.TenCV
                }).ToListAsync();
            var pageresult = new PageResult<QLChucVuViewModel>() 
            { 
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items =  data
            };
            var s = data;
            return new APISuccessedResult<PageResult<QLChucVuViewModel>>(pageresult);

        }
    }
}
