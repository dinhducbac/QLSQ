using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.LuongCoBan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.LuongCoBan
{
    public class LuongCoBanServices : ILuongCoBanServices
    {
        public readonly QL_SiQuanDBContext _context;
        public LuongCoBanServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<LuongCoBanViewModel>> Details(int IDLuongCB)
        {
            var lcbvm = await (from lcb in _context.LuongCoBans select lcb).FirstOrDefaultAsync();
            var lcbDetails = new LuongCoBanViewModel()
            {
                IDLuongCB = lcbvm.IDLuongCB,
                LuongCB = lcbvm.LuongCB
            };
            return new APISuccessedResult<LuongCoBanViewModel>(lcbDetails);
        }

        public async Task<APIResult<PageResult<LuongCoBanViewModel>>> GetALLWithPaging(GetLuongCoBanPagingRequest request)
        {
            var query = from lcb in _context.LuongCoBans select lcb;
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new LuongCoBanViewModel
                {
                    IDLuongCB = x.IDLuongCB,
                    LuongCB = x.LuongCB
                }).ToListAsync();
            var pageResult = new PageResult<LuongCoBanViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<LuongCoBanViewModel>>(pageResult);
        }
    }
}
