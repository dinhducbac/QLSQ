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
                IDCV = request.IDCV,
                NgayNhan = request.NgayNhan
            };
            _context.QLChucVus.Add(qlcv);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDQLCV)
        {
            var qlcv = await _context.QLChucVus.FirstOrDefaultAsync(x => x.IDQLCV == IDQLCV);
            _context.QLChucVus.Remove(qlcv);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<QLChucVuDetailsViewModel>> Details(int IDQLCVS)
        {
            var query =  await (from qlcv in _context.QLChucVus
                        join cv in _context.ChucVus
                        on qlcv.IDCV equals cv.IDCV
                        join bp in _context.BoPhans
                        on cv.IDBP equals bp.IDBP
                        join hspccv in _context.HeSoPhuCapTheoChucVus
                        on cv.IDCV equals hspccv.IDCV
                        join sq in _context.SiQuans
                        on qlcv.IDSQ equals sq.IDSQ                       
                        where qlcv.IDQLCV == IDQLCVS
                        select new QLChucVuDetailsViewModel 
                        {
                            IDQLCV = qlcv.IDQLCV,
                            IDSQ = qlcv.IDSQ,
                            HoTen = sq.HoTen,                      
                            IDBP = bp.IDBP,
                            TenBP = bp.TenBP,
                            IDCV = qlcv.IDCV,
                            TenCV = cv.TenCV,
                            NgayNhan = qlcv.NgayNhan,
                            HeSoPhuCap = hspccv.HeSoPhuCap
                        }).FirstOrDefaultAsync(); 
            return new APISuccessedResult<QLChucVuDetailsViewModel>(query);
        }

        public async Task<APIResult<bool>> Edit(int IDQLCV, QLChucVuUpdateRequest request)
        {
            var qlcv = await _context.QLChucVus.FirstOrDefaultAsync(x => x.IDQLCV == IDQLCV);          
            qlcv.IDCV = request.IDCV;
            qlcv.NgayNhan = request.NgayNhan;
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
                        
                        select new QLChucVuViewModel
                        {
                            IDQLCV = qlcv.IDQLCV,
                            IDSQ = sq.IDSQ,
                            HoTenSQ = sq.HoTen,               
                            IDCV = cv.IDCV,
                            TenCV = cv.TenCV,
                            NgayNhan = qlcv.NgayNhan
                        };
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.HoTenSQ.Contains(request.keyword) ||
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
                    IDCV = x.IDCV,
                    TenCV = x.TenCV,
                    NgayNhan = x.NgayNhan
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
