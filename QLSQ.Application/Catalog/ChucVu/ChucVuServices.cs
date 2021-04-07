using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.ChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.ChucVu
{
    public class ChucVuServices : IChucVuServices
    {
        public readonly QL_SiQuanDBContext _context;
        public ChucVuServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(ChucVuCreateRequest request)
        {
            var cv = new QLSQ.Data.Entities.ChucVu()
            {
                TenCV = request.TenCV,
                IDBP = request.IDBP
            };
            _context.ChucVus.Add(cv);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDCV)
        {
            var cv = await _context.ChucVus.FirstOrDefaultAsync(x => x.IDCV == IDCV);
            _context.ChucVus.Remove(cv);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<ChucVuDetailsViewModel>> Details(int IDCV)
        {
            var query = await (from bp in _context.BoPhans
                        join cv in _context.ChucVus
                        on bp.IDBP equals cv.IDBP
                        where cv.IDCV == IDCV
                        select new ChucVuDetailsViewModel 
                        { 
                            IDBP = cv.IDBP,
                            TenBP = bp.TenBP,
                            IDCV = cv.IDCV,
                            TenCV = cv.TenCV
                        }).FirstOrDefaultAsync();
            var cvViewModel = new ChucVuDetailsViewModel()
            {
                IDBP = query.IDBP,
                IDCV = query.IDCV,
                TenBP = query.TenBP,
                TenCV = query.TenCV
            };
            return new APISuccessedResult<ChucVuDetailsViewModel>(cvViewModel);
        }

        public async Task<APIResult<bool>> Edit(int IDCV, ChucVuUpdateRequest request)
        {
            var cv = await _context.ChucVus.FirstOrDefaultAsync(x=>x.IDCV == IDCV);
            cv.IDBP = request.IDBP;
            cv.TenCV = request.TenCV;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<ChucVuViewModel>>> GetAllWithPaging(GetChucVuPagingRequest request)
        {
            var query = from bp in _context.BoPhans
                        join cv in _context.ChucVus
                        on bp.IDBP equals cv.IDBP
                        select new ChucVuViewModel
                        {
                            TenBP = bp.TenBP,
                            IDCV = cv.IDCV,
                            TenCV = cv.TenCV
                        };
            if (!string.IsNullOrEmpty(request.keword))
            {
                query = query.Where(x => x.TenBP.Contains(request.keword) || x.TenCV.Contains(request.keword));
            }
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ChucVuViewModel
                {
                    TenBP = x.TenBP,
                    IDCV = x.IDCV,
                    TenCV = x.TenCV
                }).ToListAsync();
            var pageResult = new PageResult<ChucVuViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<ChucVuViewModel>>(pageResult);
        }
    }
}
