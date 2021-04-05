using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QuanHam
{
    public class QuanHamServices : IQuanHamServices
    {
        private readonly QL_SiQuanDBContext _context;

        public QuanHamServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(QuanHamCreateRequest request)
        {
            if (!string.IsNullOrEmpty(request.TenQH))
            {
                var qh = new QLSQ.Data.Entities.QuanHam()
                {
                    TenQH = request.TenQH
                };
                _context.QuanHams.Add(qh);
                await _context.SaveChangesAsync();
                return new APISuccessedResult<bool>(true);
            }
            return new APIErrorResult<bool>("Thất bại");
        }

        public async Task<APIResult<bool>> Delete(int IDQH)
        {
            var qh = await _context.QuanHams.FirstOrDefaultAsync(x=>x.IDQH == IDQH);
            _context.QuanHams.Remove(qh);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<QuanHamViewModel>> Details(int IDQH)
        {
            var qh =  _context.QuanHams.FirstOrDefaultAsync(x=>x.IDQH == IDQH);
            var qhvm = new QuanHamViewModel()
            {
                IDQH = qh.Result.IDQH,
                TenQH = qh.Result.TenQH
            };
            return new APISuccessedResult<QuanHamViewModel>(qhvm);
        }

        public async Task<APIResult<bool>> Edit(int IDQH,QuanHamUpdateRequest request)
        {
            var qh = await _context.QuanHams.FirstOrDefaultAsync(x => x.IDQH == IDQH);
            qh.TenQH = request.TenQH;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);

        }

        public async Task<APIResult<PageResult<QuanHamViewModel>>> GetAllWithPaging(GetQuanHamPagingRequest request)
        {
            var query = from qh in _context.QuanHams select qh;
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.IDQH.ToString().Contains(request.keyword) || x.TenQH.Contains(request.keyword));
            }
            int totalrow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QuanHamViewModel()
                {
                    IDQH = x.IDQH,
                    TenQH = x.TenQH
                }).ToListAsync();
            var pageresult = new PageResult<QuanHamViewModel>()
            {
                TotalRecord = totalrow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QuanHamViewModel>>(pageresult);
        }
    }
}
