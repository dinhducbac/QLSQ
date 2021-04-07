using QLSQ.Data.EF;
using QLSQ.Data.Entities;
using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.HeSoPhuCapTHeoChucVu
{
    public class HeSoPhuCapTheoChucVuServices : IHeSoPhuCapTheoChucVuServices
    {
        public readonly QL_SiQuanDBContext _context;
        public HeSoPhuCapTheoChucVuServices (QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(HeSoPhuCapTheoChucVuCreateRequest request)
        {
            var hspc = new QLSQ.Data.Entities.HeSoPhuCapTheoChucVu()
            {
                IDCV = request.IDCV,
                HeSoPhuCap = request.HeSoPhuCap
            };
            _context.HeSoPhuCapTheoChucVus.Add(hspc);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<HeSoPhuCapTheoChucVuDetailsViewModel>> Details(int IDHeSoPhuCapCV)
        {
            var query = await (from bp in _context.BoPhans
                         join cv in _context.ChucVus
                         on bp.IDBP equals cv.IDBP
                         join hspc in _context.HeSoPhuCapTheoChucVus
                         on cv.IDCV equals hspc.IDCV
                         where hspc.IDHeSoPhuCapCV == IDHeSoPhuCapCV
                         select new HeSoPhuCapTheoChucVuDetailsViewModel 
                         {
                            IDHeSoPhuCapCV = IDHeSoPhuCapCV,
                            IDBP = cv.IDBP,
                            TenBP = bp.TenBP,
                            IDCV = cv.IDCV,
                            TenCV = cv.TenCV,
                            HeSoPhuCap = hspc.HeSoPhuCap
                         }).FirstOrDefaultAsync();
            var hspcDetailsViewModel = new HeSoPhuCapTheoChucVuDetailsViewModel()
            {
                IDHeSoPhuCapCV = query.IDHeSoPhuCapCV,
                IDBP = query.IDBP,
                TenBP = query.TenBP,
                IDCV = query.IDCV,
                TenCV = query.TenCV,
                HeSoPhuCap = query.HeSoPhuCap
            };
            return new APISuccessedResult<HeSoPhuCapTheoChucVuDetailsViewModel>(hspcDetailsViewModel);
        }

        public async Task<APIResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>> GetAllWithPaging(GetHeSoPhuCapPagingRequest request)
        {
            var query = from cv in _context.ChucVus
                        join hspc in _context.HeSoPhuCapTheoChucVus
                        on cv.IDCV equals hspc.IDCV
                        select new HeSoPhuCapTheoChucVuViewModel 
                        { 
                            IDHeSoPhuCapCV = hspc.IDHeSoPhuCapCV,
                            IDCV = cv.IDCV,
                            TenCV = cv.TenCV,
                            HeSoPhuCap = hspc.HeSoPhuCap
                        };
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new HeSoPhuCapTheoChucVuViewModel
                {
                    IDHeSoPhuCapCV = x.IDHeSoPhuCapCV,
                    IDCV = x.IDCV,
                    TenCV = x.TenCV,
                    HeSoPhuCap = x.HeSoPhuCap
                }).ToListAsync();
            var pageResult = new PageResult<HeSoPhuCapTheoChucVuViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>(pageResult);
        }
    }
}
