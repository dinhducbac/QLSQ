using Microsoft.EntityFrameworkCore;
using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.BoPhan
{
    public class BoPhanServices : IBoPhanServices
    {
        public readonly QL_SiQuanDBContext _context;
        public BoPhanServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(BoPhanCreateRequest request)
        {
            var bp = new QLSQ.Data.Entities.BoPhan()
            {
                TenBP = request.TenBP
            };
            _context.BoPhans.Add(bp);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<BoPhanViewModel>> Details(int IDBP)
        {
            var bp = await _context.BoPhans.FirstOrDefaultAsync(x=>x.IDBP == IDBP);
            var bpmd = new BoPhanViewModel()
            {
                IDBP = bp.IDBP,
                TenBP = bp.TenBP
            };
            return new APISuccessedResult<BoPhanViewModel>(bpmd);
        }

        public async Task<APIResult<PageResult<BoPhanViewModel>>> GetAllWithPaging(GetBoPhanPagingRequest request)
        {
            var query = from bp in _context.BoPhans select bp;
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.TenBP.Contains(request.keyword));
            }
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new BoPhanViewModel
                {
                    IDBP = x.IDBP,
                    TenBP = x.TenBP
                }).ToListAsync();
            var pageResult = new PageResult<BoPhanViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<BoPhanViewModel>>(pageResult); 
        }
    }
}
